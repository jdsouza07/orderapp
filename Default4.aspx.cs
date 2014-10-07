using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using connection;
using System.Data.OleDb;

class TestObject
{
    public string OneValue { get; set; }
  
}


public partial class Default4 : System.Web.UI.Page
{






    private void releaseObject(object obj)
    {
        try
        {
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
            obj = null;
        }
        catch (Exception ex)
        {
            obj = null;
            //MessageBox.Show("Unable to release the Object " + ex.ToString());
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "msg", "alert('Unable to release the Object')", true);
        }
        finally
        {
            GC.Collect();
        }
    }
    DataTable table = new DataTable();

    static string excelfilepath="";
    protected void Button1_Click1(object sender, EventArgs e)
    {
        try
        {
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
         

            xlApp = new Excel.ApplicationClass();
          

            int intFileSizeLimit = 10;
            string path = Server.MapPath("~/");           
            string strFileNameWithPath = FileUpload1.PostedFile.FileName;           
            string strExtensionName = System.IO.Path.GetExtension(strFileNameWithPath);         
            string strFileName = System.IO.Path.GetFileName(strFileNameWithPath);         
            excelfilepath=strFileNameWithPath;
             int intFileSize = FileUpload1.PostedFile.ContentLength / 1024; 
            strExtensionName = strExtensionName.ToLower();
            if (strExtensionName.Equals(".xls"))
            {  // Rstrict the File Size 
                if (intFileSize < intFileSizeLimit)
                {
                  
                    xlWorkBook = xlApp.Workbooks.Open(strFileNameWithPath, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);

                    xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                    Microsoft.Office.Interop.Excel.Range range;
                    List<String> list1 = new List<String>();
                    table.TableName = "Products";
                        
                    table.Columns.Add("prod_name");
                    table.Columns.Add("prod_mfg");
                    range = xlWorkSheet.UsedRange;
                    int rowcount = range.Rows.Count;
                    int colcount = range.Columns.Count;


                    for (int rows = 2; rows <= rowcount; rows++)
                    {
                        DataRow datarow = table.NewRow();


                        for (int cols = 1; cols <= colcount; cols++)
                        {

                            datarow[cols - 1] = (range.Cells[rows, cols] as Excel.Range).Value2.ToString();

                        }
                        table.Rows.Add(datarow);
                        table.AcceptChanges();


                    }

                   
                    //SqlCommand command = new SqlCommand();
                    //command.Connection = c.connecttosql();
                    //command.CommandText = "insert into products(prod_name,prod_mfg) values(@prod,@company)";
                    //command.Parameters.Add("@prod", SqlDbType.VarChar, 50);
                    //command.Parameters.Add("@company", SqlDbType.VarChar, 50);
                    //SqlDataAdapter sa = new SqlDataAdapter();
                    
                    //sa.InsertCommand = command;
                    //sa.Update(table);

                  
                    
                   
                                       // sa.Fill(table);

                    GridView1.DataSource = table;
                    GridView1.DataBind();


                    xlWorkBook.Close(true, null, null);
                    xlApp.Quit();

                    releaseObject(xlWorkSheet);
                    releaseObject(xlWorkBook);
                    releaseObject(xlApp);
                    Label1.Text = "Uploaded file details " + "<br />" + "  <hr />" +
                        "File path on your Computer: " + path + strFileNameWithPath + "<br />" +
                        "File Name: " + strFileName + "<br />" +
                        "File Extension Name: " + strExtensionName + "<br />" +
                        "File Size: " + intFileSize.ToString();
                }
                else
                {
                    Label1.Text = "File size exceeded than limit " + intFileSizeLimit + " KB, Please upload smaller file.";
                }
            }
            else
            {
                Label1.Text = "Only .xls files are allowed, please try again!";
                Label1.ForeColor = System.Drawing.Color.Red;
            }

        }

        catch (Exception ex)
        {
            Response.Redirect(ex.Message);
        }
    }
    string ssqltable = "products";
   string sexcelconnectionstring = @"provider=microsoft.jet.oledb.4.0;data source=" + excelfilepath + ";extended properties=" + "\"excel 8.0;hdr=yes;\"";

    protected void Button2_Click1(object sender, EventArgs e)
    {
        try
        {
            string myexceldataquery = "SELECT prod_name, prod_mfg FROM [sheet1$]";

            connect c = new connect();
            if (GridView1.Rows.Count > 1)
            {
                OleDbConnection oledb = new OleDbConnection(sexcelconnectionstring);
                OleDbCommand oledbcmd = new OleDbCommand(myexceldataquery, oledb);
                oledb.Open();
                OleDbDataReader dr = oledbcmd.ExecuteReader();
                SqlBulkCopy bulkcopy = new SqlBulkCopy(c.connecttosql());
                        bulkcopy.DestinationTableName = "products";
                      

                        while (dr.Read())
                            
                            {
                                  bulkcopy.WriteToServer(dr);
                             }
                

                              oledb.Close();
             }

           }
             //}
           // }
         catch (Exception ex)
        {

            Label1.Text=ex.Message;
        }    
           
        }


         
    }




    
    

    
