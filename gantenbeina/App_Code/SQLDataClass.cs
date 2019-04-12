using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SQLDataClass
/// </summary>
public class SQLDataClass
{
    private const string ConStr = "Data Source=Alpha;" +
         "Initial Catalog = UWPCS3870; Persist Security Info=True;" +
         "User ID = MSCS; Password=MasterInCS";

    private static System.Data.SqlClient.SqlDataAdapter prodAdapter;
    private static System.Data.SqlClient.SqlCommand prodCmd
                 = new System.Data.SqlClient.SqlCommand();
    private static System.Data.SqlClient.SqlConnection con
                 = new System.Data.SqlClient.SqlConnection();

    public static System.Data.DataTable tblProduct
                 = new System.Data.DataTable("Product");
    public SQLDataClass()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public static void setupProdAdapter()
    {
        con.ConnectionString = ConStr;

        prodCmd.Connection = con;
        prodCmd.CommandType = System.Data.CommandType.Text;
        prodCmd.CommandText = "Select * from Product order by ProductID";

        prodAdapter = new System.Data.SqlClient.SqlDataAdapter(prodCmd);

        prodAdapter.FillSchema(tblProduct, System.Data.SchemaType.Source);
    }

    public static void getAllProducts()
    {
        if (prodAdapter == null)
            setupProdAdapter();

        prodCmd.CommandText = "Select * from Product order by ProductID";

        try
        {
            if (!(tblProduct == null))
                tblProduct.Clear();
            prodAdapter.Fill(tblProduct);
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

    // SQLDataClass
    public static void UpdateProduct(string theID,
                         string newName, double newPrice, string newDesc)
    {
        prodCmd.CommandText = "Update Product " +
                              "Set ProductName = '" + newName + "', " +
                              "UnitPrice = " + newPrice + ", " +
                              "Description = '" + newDesc + "' " +
                              "Where ProductID = '" + theID + "'";
        try
        {
            con.Open();
            prodCmd.ExecuteNonQuery();
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

    public static void InsertProduct(string theID,
                         string theName, double thePrice, string theDesc)
    {
        prodCmd.CommandText = "Insert into Product " +
                              "Values(‘" + theID + "’, ‘" + theName + "’, " + thePrice + ", ‘" + theDesc + "’)";
        ;
        try
        {
            con.Open();
            prodCmd.ExecuteNonQuery();
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