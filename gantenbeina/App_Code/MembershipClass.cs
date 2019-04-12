using System.Collections.Generic;
using System.Linq;
using System.Web.Security;
using System.Configuration.Provider;
using System.Collections.Specialized;
using System;
using System.Data;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Configuration;
using System.Diagnostics;
using System.Web;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using System.Web.Configuration;

namespace UWPCS3870
{
    public class AlphaMembershipProvider : MembershipProvider
    {
        //Private Const ConStr As String = "Data Source=Alpha;Initial Catalog=UWPCS3870;Persist Security Info=True;User ID=MSCS;Password=MasterInCS"
        private System.Data.SqlClient.SqlDataAdapter alphaAdapter;
        private System.Data.SqlClient.SqlDataAdapter alphaBuilder;
        private System.Data.SqlClient.SqlCommand alphaCmd = new System.Data.SqlClient.SqlCommand();
        private System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection();
        private System.Data.DataTable tblUsers = new System.Data.DataTable("User");

        //Global generated password length, generic exception message, event log info. 
        private int newPasswordLength = 8;
        private string eventSource = "OdbcMembershipProvider";
        private string eventLog = "Application";
        private string exceptionMessage = "An exception occurred. Please check the Event Log.";
        private string connectionString;

        //System.Web.Security.MembershipProvider properties. 
        private string pApplicationName;
        private bool pEnablePasswordReset;
        private bool pEnablePasswordRetrieval;
        private bool pRequiresQuestionAndAnswer;
        private bool pRequiresUniqueEmail;
        private int pMaxInvalidPasswordAttempts;
        private int pPasswordAttemptWindow;
        private MembershipPasswordFormat pPasswordFormat;
        private int pMinRequiredNonAlphanumericCharacters;
        private int pMinRequiredPasswordLength;
        private string pPasswordStrengthRegularExpression;

        //Used when determining encryption key values. 
        private MachineKeySection machineKey;

        //If False, exceptions are thrown to the caller. If True, 
        //exceptions are written to the event log. 
        private bool pWriteExceptionsToEventLog;

        public bool WriteExceptionsToEventLog
        {
            get
            {
                return pWriteExceptionsToEventLog;
            }
            set
            {
                pWriteExceptionsToEventLog = value;
            }
        }

        public override void Initialize(string name, NameValueCollection config)
        {
            if (config == null)
                throw new ArgumentNullException("config");

            if (name == null || name.Length == 0)
                name = "AlphaMembershipProvider";

            if (string.IsNullOrEmpty(config["description"]))
            {
                config.Remove("description");
                config.Add("description", "Membership provider on Alpha");
            }

            //Initialize the abstract base class
            base.Initialize(name, config);

            pApplicationName = GetConfigValue(config["applicationName"],
                                            System.Web.Hosting.HostingEnvironment.ApplicationVirtualPath);

            pMaxInvalidPasswordAttempts = Convert.ToInt32(GetConfigValue(config["maxInvalidPasswordAttempts"], "5"));
            pPasswordAttemptWindow = Convert.ToInt32(GetConfigValue(config["passwordAttemptWindow"], "10"));
            pMinRequiredNonAlphanumericCharacters = Convert.ToInt32(GetConfigValue(config["minRequiredAlphaNumericCharacters"], "1"));
            pMinRequiredPasswordLength = Convert.ToInt32(GetConfigValue(config["minRequiredPasswordLength"], "7"));
            pPasswordStrengthRegularExpression = Convert.ToString(GetConfigValue(config["passwordStrengthRegularExpression"], ""));
            pEnablePasswordReset = Convert.ToBoolean(GetConfigValue(config["enablePasswordReset"], "False"));
            pEnablePasswordRetrieval = Convert.ToBoolean(GetConfigValue(config["enablePasswordRetrieval"], "False"));
            pRequiresQuestionAndAnswer = Convert.ToBoolean(GetConfigValue(config["requiresQuestionAndAnswer"], "False"));
            pRequiresUniqueEmail = Convert.ToBoolean(GetConfigValue(config["requiresUniqueEmail"], "false"));
            pWriteExceptionsToEventLog = Convert.ToBoolean(GetConfigValue(config["writeExceptionsToEventLog"], "False"));

            string temp_format = config["passwordFormat"];
            if (temp_format == null)
                temp_format = "Hashed";

            switch (temp_format)
            {
                case "Hashed":
                    pPasswordFormat = MembershipPasswordFormat.Hashed; break;
                case "Encrypted":
                    pPasswordFormat = MembershipPasswordFormat.Encrypted; break;
                case "Clear":
                    pPasswordFormat = MembershipPasswordFormat.Clear; break;
                default:
                    throw new ProviderException("password format not supported.");
            }

            //Initialize AlphaConnection
            ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings[config["connectionStringName"]];
            if (connectionStringSettings == null || connectionStringSettings.ConnectionString.Trim() == "")
                throw new ProviderException("Connection string cannot be blank.");

            connectionString = connectionStringSettings.ConnectionString;

            //Added
            alphaCmd.CommandType = CommandType.Text;
            conn.ConnectionString = connectionString;
            alphaCmd.Connection = conn;

            //Get encryption and decryption key information from the configuration. 
            System.Configuration.Configuration cfg
                = WebConfigurationManager.OpenWebConfiguration(System.Web.Hosting.HostingEnvironment.ApplicationVirtualPath);
            machineKey = (MachineKeySection)(cfg.GetSection("system.web/machineKey"));

            if (machineKey.ValidationKey.Contains("AutoGenerate"))
            {
                if (PasswordFormat != MembershipPasswordFormat.Clear)
                {
                    throw new ProviderException("Hashed or Encrypted passwords " +
                                               "are not supported with auto-generated keys.");
                }
            }
        }

        //A helper function to retrieve config values from the configuration file. 
        private string GetConfigValue(string configValue, string defaultValue)
        {
            if (string.IsNullOrEmpty(configValue))
                return defaultValue;
            return configValue;
        }

        public override string ApplicationName
        {
            get
            {
                return pApplicationName;
            }

            set
            {
                pApplicationName = value;
            }
        }

        public override bool EnablePasswordReset
        {
            get
            {
                return pEnablePasswordReset;
            }
        }

        public override bool EnablePasswordRetrieval
        {
            get
            {
                return pEnablePasswordRetrieval;
            }
        }

        public override bool RequiresQuestionAndAnswer
        {
            get
            {
                return pRequiresQuestionAndAnswer;
            }
        }

        public override bool RequiresUniqueEmail
        {
            get
            {
                return pRequiresUniqueEmail;
            }
        }

        public override int MaxInvalidPasswordAttempts
        {
            get
            {
                return pMaxInvalidPasswordAttempts;
            }
        }

        public override int PasswordAttemptWindow
        {
            get
            {
                return pPasswordAttemptWindow;
            }
        }

        public override MembershipPasswordFormat PasswordFormat
        {
            get
            {
                return pPasswordFormat;
            }
        }

        public override int MinRequiredNonAlphanumericCharacters
        {
            get
            {
                return pMinRequiredNonAlphanumericCharacters;
            }
        }

        public override int MinRequiredPasswordLength
        {
            get
            {
                return pMinRequiredPasswordLength;
            }
        }

        public override string PasswordStrengthRegularExpression
        {
            get
            {
                return pPasswordStrengthRegularExpression;
            }
        }

        //
        // System.Web.Security.MembershipProvider methods. 
        //

        //MembershipProvider.ChangePassword: Do Not change password 
        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            return false;
        }

        //MembershipProvider.ChangePasswordQuestionAndAnswer: We do Not change it.
        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
        {
            return false;
        }

        //MembershipProvider.CreateUser 
        public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {
            alphaCmd.CommandText = " Insert into [Users] ([Username], [ApplicationName], [Password]) "
                + "Values('" + username + "', '" + ApplicationName + "', '" + EncodePassword(password) + "') ";

            try
            {
                conn.Open();
                alphaCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            status = MembershipCreateStatus.Success;
            return null;
        }

        //MembershipProvider.DeleteUser
        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            alphaCmd.CommandText = " Delete From [UsersInRoles] "
                + " Where [Username] = '" + username + "' "
                + "   and [ApplicationName] = '" + ApplicationName + "'";

            try
            {
                conn.Open();
                alphaCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            alphaCmd.CommandText = " Delete From [Users] "
                + " Where [Username] = '" + username + "' "
                + "   and [ApplicationName] = '" + ApplicationName + "'";

            var rowsAffected = 0;

            try
            {
                conn.Open();
                rowsAffected = alphaCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            if (rowsAffected > 0)
                return true;
            else
                return false;
        }

        //MembershipProvider.GetAllUsers: may not need it
        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            var users = new MembershipUserCollection();

            alphaCmd.CommandText = " SELECT * FROM Users "
                + " where ApplicationName = '" + ApplicationName + "' ";

            System.Data.SqlClient.SqlDataReader reader = null;

            try
            {
                conn.Open();
                reader = alphaCmd.ExecuteReader();

                while (reader.Read())
                {
                    var u = GetUserFromReader(reader);
                    users.Add(u);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (reader != null)
                    reader.Close();
                conn.Close();
            }
            totalRecords = users.Count;
            return users;
        }

        //MembershipProvider.GetNumberOfUsersOnline: not need for now
        public override int GetNumberOfUsersOnline()
        {
            return 0;
        }

        //MembershipProvider.GetPassword: not needed
        public override string GetPassword(string username, string answer)
        {
            return "";
        }

        //MembershipProvider.GetUser(String, Boolean): not needed
        public override MembershipUser GetUser(string username, bool userIsOnline)
        {
            return null;
        }

        //MembershipProvider.GetUser(Object, Boolean): not needed
        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            return null;
        }

        //GetUserFromReader 
        //A helper function that takes the current row from the OdbcDataReader 
        //and hydrates a MembershiUser from the values. Called by the  
        //MembershipUser.GetUser implementation. 
        private MembershipUser GetUserFromReader(System.Data.SqlClient.SqlDataReader reader)
        {
            object providerUserKey = reader.GetValue(1);
            string username = reader.GetString(0);
            //Additional comments on following lines have been removed.  See the original VB file.
            string email = "email";
            string passwordQuestion = "";
            string comment = "";
            bool isApproved = true;
            bool isLockedOut = false;
            DateTime creationDate = new DateTime();
            DateTime lastLoginDate = new DateTime();
            DateTime lastActivityDate = new DateTime();
            DateTime lastPasswordChangedDate = new DateTime();
            DateTime lastLockedOutDate = new DateTime();

            var u = new MembershipUser(this.Name,
                username,
                providerUserKey,
                email,
                passwordQuestion,
                comment,
                isApproved,
                isLockedOut,
                creationDate,
                lastLoginDate,
                lastActivityDate,
                lastPasswordChangedDate,
                lastLockedOutDate);

            return u;
        }

        //MembershipProvider.UnlockUser: not needed
        public override bool UnlockUser(string userName)
        {
            return false;
        }

        //MembershipProvider.GetUserNameByEmail: not needed
        public override string GetUserNameByEmail(string email)
        {
            return "";
        }

        //MembershipProvider.ResetPassword: not needed
        public override string ResetPassword(string username, string answer)
        {
            return "";
        }

        //MembershipProvider.UpdateUser: not needed
        public override void UpdateUser(MembershipUser user)
        {
            int x = 0;
            x += 1;
        }

        //MembershipProvider.ValidateUser 
        public override bool ValidateUser(string username, string password)
        {
            bool isValid = false;
            int counter = 0;

            password = EncodePassword(password);
            alphaCmd.CommandText = " Select * From [Users] "
                + " Where [Username] = '" + username + "' "
                + "  and  [Password] = '" + password + "' "
                + "  and  [ApplicationName] = '" + ApplicationName + "'";

            try
            {
                System.Data.SqlClient.SqlDataReader reader;

                conn.Open();
                reader = alphaCmd.ExecuteReader();

                while (reader.Read())
                    counter += 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            if (counter == 1)
                isValid = true;
            else
                isValid = false;

            return isValid;
        }

        //UpdateFailureCount 
        //A helper method that performs the checks and updates associated with 
        //password failure tracking: not needed
        private void UpdateFailureCount(string username, string failureType)
        {
            //Not Implemented
        }

        //CheckPassword 
        //Compares password values based on the MembershipPasswordFormat: not needed
        private bool CheckPassword(string password, string dbpassword)
        {
            return true;
        }

        //EncodePassword 
        //Encrypts, Hashes, or leaves the password clear based on the PasswordFormat. 
        private string EncodePassword(string password)
        {
            string encodedPassword = password;

            switch (PasswordFormat)
            {
                case MembershipPasswordFormat.Clear:
                    break;
                case MembershipPasswordFormat.Encrypted:
                    encodedPassword = Convert.ToBase64String(EncryptPassword(Encoding.Unicode.GetBytes(password)));
                    break;
                case MembershipPasswordFormat.Hashed:
                    HMACSHA1 hash = new HMACSHA1();
                    hash.Key = HexToByte(machineKey.ValidationKey);
                    encodedPassword = Convert.ToBase64String(hash.ComputeHash(Encoding.Unicode.GetBytes(password)));
                    break;
                default:
                    throw new ProviderException("Unsupported password format.");
            }

            return encodedPassword;
        }

        //UnEncodePassword 
        //Decrypts or leaves the password clear based on the PasswordFormat. 
        private string UnEncodePasword(string encodedPassword)
        {
            string password = encodedPassword;

            switch (PasswordFormat)
            {
                case MembershipPasswordFormat.Clear:
                    break;
                case MembershipPasswordFormat.Encrypted:
                    password = Encoding.Unicode.GetString(DecryptPassword(Convert.FromBase64String(password)));
                    break;
                case MembershipPasswordFormat.Hashed:
                    throw new ProviderException("Cannot unencode a hashed password.");
                default:
                    throw new ProviderException("Unsupported password format.");
            }

            return password;
        }

        //HexToByte 
        //Converts a hexadecimal string to a byte array. Used to convert encryption 
        //key values from the configuration. 
        private byte[] HexToByte(string hexString)
        {
            byte[] ReturnedBytes = new byte[(hexString.Length / 2)];
            for (int i = 0; i < ReturnedBytes.Length; i++)
                ReturnedBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            return ReturnedBytes;

            //The code above is different from that of vb, but it works the same.  Very odd.
            //Dim ReturnBytes((hexString.Length \ 2) -1) As Byte
            //For i As Integer = 0 To ReturnBytes.Length - 1
            //   ReturnBytes(i) = Convert.ToByte(hexString.Substring(i * 2, 2), 16)
            //Next
            //Return ReturnBytes
        }

        //MembershipProvider.FindUsersByName 
        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            var users = new MembershipUserCollection();
            totalRecords = 0;
            return users;
        }

        //MembershipProvider.FindUsersByEmail 
        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            var users = new MembershipUserCollection();
            totalRecords = 0;
            return users;
        }
    }
}