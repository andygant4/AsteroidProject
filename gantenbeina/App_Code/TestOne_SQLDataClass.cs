using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for TestOne_SQLDataClass
/// </summary>
public class TestOne_SQLDataClass
{
    private const string ConStr = "Data Source=Alpha;" +
         "Initial Catalog = UWPCS3870; Persist Security Info=True;" +
         "User ID = MSCS; Password=MasterInCS";

    private static System.Data.SqlClient.SqlDataAdapter empAdapter;
    private static System.Data.SqlClient.SqlCommand empCmd
                 = new System.Data.SqlClient.SqlCommand();
    private static System.Data.SqlClient.SqlConnection con
                 = new System.Data.SqlClient.SqlConnection();

    public static System.Data.DataTable tblEmployee
                 = new System.Data.DataTable("Employee");
    public TestOne_SQLDataClass()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public static void setupEmpAdapter()
    {
        con.ConnectionString = ConStr;

        empCmd.Connection = con;
        empCmd.CommandType = System.Data.CommandType.Text;
        empCmd.CommandText = "Select * from Employee order by EmpID";

        empAdapter = new System.Data.SqlClient.SqlDataAdapter(empCmd);

        empAdapter.FillSchema(tblEmployee, System.Data.SchemaType.Source);
    }

    public static void getAllEmployees()
    {
        if (empAdapter == null)
            setupEmpAdapter();

        empCmd.CommandText = "Select * from Employee order by EmpID";

        try
        {
            if (!(tblEmployee == null))
                tblEmployee.Clear();
            empAdapter.Fill(tblEmployee);
        }
        catch (Exception e)
        {
            throw e;
        }
        finally
        {
            con.Close();
        }
    }

    public static void InsertEmployee(string theID,
                         string firstName, string lastName, string hireDate, string pos)
    {
        empCmd.CommandText = "Insert Into Employee Values('"
                              + theID + "', '" + firstName + "', '" + lastName +
                              "', '" + hireDate + "', '" +
                              pos + "');";

        try
        {
            con.Open();
            empCmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        finally
        {
            con.Close();
        }
    }

    public static void DeleteEmployee(string theID)
    {
        empCmd.CommandText = "Delete from Employee where EmpID = '"
                              + theID + "';";


        //Delete From Product
        //Where ProductID = ‘theID’;


        try
        {
            con.Open();
            empCmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        finally
        {
            con.Close();
        }
    }
}