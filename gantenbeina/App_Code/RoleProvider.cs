using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Configuration.Provider;
using System.Collections.Specialized;
using System.Data;
using System.Data.Odbc;
using System.Configuration;
using System.Diagnostics;
using System.Globalization;
using Microsoft.VisualBasic;


//This provider works with the following schema for the tables of role data. 

//CREATE TABLE Roles 
//( 
//  Rolename Text (128) NOT NULL, 
//  ApplicationName Text (255) NOT NULL, 
//    CONSTRAINT PKRoles PRIMARY KEY (Rolename, ApplicationName) 
//) 

//CREATE TABLE UsersInRoles 
//( 
//  Username Text (128) NOT NULL, 
//  Rolename Text (128) NOT NULL, 
//  ApplicationName Text (128) NOT NULL, 
//    CONSTRAINT PKUsersInRoles PRIMARY KEY (Username, Rolename, ApplicationName) 
//)

namespace UWPCS3870
{
    public class AlphaRoleProvider : RoleProvider
    {

        //Global OdbcConnection, generated password length, generic exception message, event log info. 

        private System.Data.SqlClient.SqlDataAdapter alphaAdapter;
        private System.Data.SqlClient.SqlDataAdapter alphaBuilder;
        private System.Data.SqlClient.SqlCommand alphaCmd = new System.Data.SqlClient.SqlCommand();
        private System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection();
        private System.Data.DataTable tblRoles = new System.Data.DataTable("Roles");

        //Private eventSource As String = "OdbcRoleProvider"
        //Private eventLog As String = "Application"
        //Private exceptionMessage As String = "An exception occurred. Please check the Event Log."

        private ConnectionStringSettings pConnectionStringSettings;
        private string connectionString;

        //If false, exceptions are Thrown to the caller. If true, 
        //exceptions are written to the event log. 
        private bool pWriteExceptionsToEventLog = false;

        public void SetConnection()
        {
            connectionString = pConnectionStringSettings.ConnectionString;//WARNING:Is this null?

            //Added
            alphaCmd.CommandType = CommandType.Text;
            conn.ConnectionString = connectionString;
            alphaCmd.Connection = conn;
        }

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

        //System.Configuration.Provider.ProviderBase.Initialize Method
        public override void Initialize(string name, NameValueCollection config)
        {
            if (config == null)
                throw new ArgumentNullException("config");

            if (name == null || name.Length == 0)
                name = "OdbcRoleProvider";

            if (string.IsNullOrEmpty(config["description"]))
            {
                config.Remove("description");
                config.Add("description", "Sample ODBC Role provider");
            }

            base.Initialize(name, config);

            if (config["applicationName"] == null || config["applicationName"].Trim() == "")
                pApplicationName = System.Web.Hosting.HostingEnvironment.ApplicationVirtualPath;
            else
                pApplicationName = config["applicationName"];

            //If Not config("writeExceptionsToEventLog") Is Nothing Then
            //   If config("writeExceptionsToEventLog").ToUpper() = "TRUE" Then
            //      pWriteExceptionsToEventLog = True
            //   End If
            //End If

            //Initialize OdbcConnection.
            pConnectionStringSettings = ConfigurationManager.ConnectionStrings[config["connectionStringName"]];

            if (pConnectionStringSettings == null || pConnectionStringSettings.ConnectionString.Trim() == "")
                throw new ProviderException("Connection string cannot be blank.");

            connectionString = pConnectionStringSettings.ConnectionString;

            //Added
            alphaCmd.CommandType = CommandType.Text;
            conn.ConnectionString = connectionString;
            alphaCmd.Connection = conn;
        }

        //System.Web.Security.RoleProvider properties.
        private string pApplicationName;

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

        // 
        //System.Web.Security.RoleProvider methods. 
        //
        //RoleProvider.AddUsersToRoles 
        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            foreach (var rolename in roleNames)
                if (!RoleExists(rolename))
                    throw new ProviderException("Role name not found.");

            foreach (var username in usernames)
            {
                if (username.Contains(","))
                    throw new ArgumentException("Usernames cannot contain commas.");

                foreach (var rolename in roleNames)
                    if (IsUserInRole(username, rolename))
                        throw new ProviderException("User is already in role.");
            }

            System.Data.SqlClient.SqlTransaction tran = null;

            try
            {
                conn.Open();
                tran = conn.BeginTransaction();
                alphaCmd.Transaction = tran;

                foreach (var username in usernames)
                {
                    foreach (var rolename in roleNames)
                    {
                        alphaCmd.CommandText = " INSERT INTO UsersInRoles " +
                                        " (Username, Rolename, ApplicationName) " +
                                        " Values('" + username + "', '" + rolename + "', '" + ApplicationName + "')";

                        alphaCmd.ExecuteNonQuery();
                    }
                }
                tran.Commit();
            }
            catch (Exception ex)
            {
                try
                {
                    tran.Rollback();
                }
                catch (Exception ex2) { }
            }
            finally
            {
                conn.Close();
            }
        }

        //RoleProvider.CreateRole
        public override void CreateRole(string rolename)
        {
            if (rolename.Contains(","))
                throw new ArgumentException("Role names cannot contain commas.");

            if (RoleExists(rolename))
                throw new ProviderException("Role name already exists.");

            alphaCmd.CommandText = " INSERT INTO Roles " +
                               " (Rolename, ApplicationName) " +
                               " Values('" + rolename + "', '" + ApplicationName + "')";

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
        }

        //RoleProvider.DeleteRole 
        public override bool DeleteRole(string rolename, bool throwOnPopulatedRole)
        {
            if (!RoleExists(rolename))
                throw new ProviderException("Role does not exist.");

            //If throwOnPopulatedRole AndAlso GetUsersInRole(rolename).Length > 0 Then
            //  Throw New ProviderException("Cannot delete a populated role.")
            //End If

            alphaCmd.CommandText = " DELETE FROM Roles " +
                                " WHERE Rolename = '" + rolename + "' and ApplicationName = '" + ApplicationName + "' ";

            var cmd2 = new System.Data.SqlClient.SqlCommand();
            cmd2.Connection = conn;
            cmd2.CommandType = CommandType.Text;
            cmd2.CommandText = " DELETE FROM UsersInRoles " +
                            " WHERE Rolename = '" + rolename + "' and ApplicationName = '" + ApplicationName + "' ";

            System.Data.SqlClient.SqlTransaction tran = null;

            try
            {
                conn.Open();
                tran = conn.BeginTransaction();
                alphaCmd.Transaction = tran;
                cmd2.Transaction = tran;

                cmd2.ExecuteNonQuery();
                alphaCmd.ExecuteNonQuery();

                tran.Commit();
            }
            catch (Exception ex)
            {
                try
                {
                    tran.Rollback();
                }
                catch (Exception ex2) { }

                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return true;
        }

        //RoleProvider.GetAllRoles
        public override string[] GetAllRoles()
        {
            string tmpRoleNames = "";

            alphaCmd.CommandText = " SELECT Rolename FROM Roles " +
                                " WHERE ApplicationName = '" + ApplicationName + "'";

            System.Data.SqlClient.SqlDataReader reader = null;

            try
            {
                conn.Open();

                reader = alphaCmd.ExecuteReader();

                while (reader.Read())
                    tmpRoleNames += reader.GetString(0).Trim() + ",";//WARNING: This may not work.
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (reader != null)
                    conn.Close();
            }

            if (tmpRoleNames.Length > 0)
            {
                //Remove trailing comma.
                tmpRoleNames = tmpRoleNames.Substring(0, tmpRoleNames.Length - 1);
                return tmpRoleNames.Split(',');//WARNING: CChar used instead of ','
            }

            return tmpRoleNames.Split(',');
        }

        public override string[] GetRolesForUser(string username)
        {
            string tmpRoleNames = "";
            username = username.PadRight(128);

            alphaCmd.CommandText = " SELECT Rolename FROM UsersInRoles " +
                                   " WHERE Username = '" + username + "' " +
                                   "   and ApplicationName = '" + ApplicationName + "'";

            System.Data.SqlClient.SqlDataReader reader = null;

            try
            {
                conn.Open();

                reader = alphaCmd.ExecuteReader();

                while (reader.Read())
                    tmpRoleNames += reader.GetString(0).Trim() + ",";
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

            if (tmpRoleNames.Length > 0)
            {
                //Remove trailing comma.
                tmpRoleNames = tmpRoleNames.Substring(0, tmpRoleNames.Length - 1);
                return tmpRoleNames.Split(',');
            }
            return new string[] { };
        }

        public override string[] GetUsersInRole(string rolename)
        {
            string tmpUserNames = "";

            rolename = rolename.PadRight(128);

            alphaCmd.CommandText = " SELECT Username FROM UsersInRoles " +
                        " WHERE Rolename = '" + rolename + "' " +
                        "   And ApplicationName = '" + ApplicationName + "' ";

            System.Data.SqlClient.SqlDataReader reader = null;

            try
            {
                conn.Open();

                reader = alphaCmd.ExecuteReader();

                while (reader.Read())
                    tmpUserNames += reader.GetString(0).Trim() + ",";
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

            if (tmpUserNames.Length > 0)
            {
                //Remove trailing comma.
                tmpUserNames = tmpUserNames.Substring(0, tmpUserNames.Length - 1);
                return tmpUserNames.Split(',');
            }

            return new string[] { };
        }

        //RoleProvider.IsUserInRole 
        public override bool IsUserInRole(string username, string rolename)
        {
            bool userIsInRole = false;

            username = username.PadRight(128);
            rolename = rolename.PadRight(128);

            alphaCmd.CommandText = " SELECT COUNT(*) " +
                       " FROM UsersInRoles " +
                       " WHERE Username = '" + username + "' " +
                       "   And Rolename = '" + rolename + "' " +
                       "   And ApplicationName = '" + ApplicationName + "' ";

            try
            {
                conn.Open();

                int numRecs = (int)alphaCmd.ExecuteScalar();

                if (numRecs > 0)
                    userIsInRole = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return userIsInRole;
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] rolenames)
        {
            foreach (string rolename in rolenames)
                if (!RoleExists(rolename))
                    throw new ProviderException("Role name not found.");

            foreach (string username in usernames)
                foreach (string rolename in rolenames)
                    if (!IsUserInRole(username, rolename))
                        throw new ProviderException("User is not in role.");

            System.Data.SqlClient.SqlTransaction tran = null;

            try
            {
                conn.Open();
                tran = conn.BeginTransaction();
                alphaCmd.Transaction = tran;

                foreach (string username in usernames)
                {
                    foreach (string rolename in rolenames)
                    {
                        alphaCmd.CommandText = " DELETE FROM UsersInRoles " +
                                               " WHERE Username = '" + username + "' " +
                                               "   And Rolename = '" + rolename + "' " +
                                               "   And ApplicationName = '" + ApplicationName + "' ";

                        alphaCmd.ExecuteNonQuery();
                    }
                }

                tran.Commit();
            }
            catch (Exception ex)
            {
                try
                {
                    tran.Rollback();
                }
                catch (Exception ex2) { }

                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        //RoleProvider.RoleExists
        public override bool RoleExists(string rolename)
        {
            bool exists = false;

            alphaCmd.CommandText = " SELECT COUNT(*) FROM Roles " +
                                  " WHERE Rolename = '" + rolename + "' " +
                                  "   And ApplicationName = '" + ApplicationName + "' ";

            try
            {
                conn.Open();

                int numRecs = (int)alphaCmd.ExecuteScalar();

                if (numRecs > 0)
                    exists = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return exists;
        }

        //RoleProvider.FindUsersInRole
        public override string[] FindUsersInRole(string rolename, string usernameToMatch)
        {
            rolename = rolename.PadRight(128);

            alphaCmd.CommandText = " SELECT Username FROM UsersInRoles  " +
                                   " WHERE Username Like '%" + usernameToMatch + "%' " +
                                   "   And RoleName = '" + rolename + "' " +
                                   "   And ApplicationName = '" + "' ";

            string tmpUserNames = "";
            System.Data.SqlClient.SqlDataReader reader = null;

            try
            {
                conn.Open();

                reader = alphaCmd.ExecuteReader();

                while (reader.Read())
                    tmpUserNames += reader.GetString(0).Trim() + ",";
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

            if (tmpUserNames.Length > 0)
            {
                //RemoveUsersFromRoles trailing comma.
                tmpUserNames = tmpUserNames.Substring(0, tmpUserNames.Length - 1);
                return tmpUserNames.Split(',');
            }

            return new string[] { };
        }
    }
}
