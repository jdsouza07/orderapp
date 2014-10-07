using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using connection;
using System.Data.SqlClient;


public partial class Default3 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            connect c = new connect();
            SqlCommand command = new SqlCommand();
            command.CommandText = "select tax_rate from tax";
            command.Connection = c.connecttosql();

            double tax = (double)command.ExecuteScalar();
            TextBox3.Text = tax.ToString(); 

           
            




        }
        catch (Exception ex)
        {

            Response.Write(ex.Message);
        }
        finally
        {


        }
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        TextBox1.Text = GridView1.SelectedRow.Cells[0].Text;
        
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        using (Database1Entities2 db = new Database1Entities2())
        {
            try
            {
                int id = Convert.ToInt32(TextBox1.Text);
                string status = DropDownList1.Text.ToString();
                var ord_status = (from o in db.Orders
                                  where o.order_id == id
                                  select o).Single();
                ord_status.status = status;
                ord_status.status_date = DateTime.Now;
                db.SaveChanges();
                Label3.Text = "updated status at " + DateTime.Now;

            }
            catch (Exception ex)
            {

                Response.Write(ex.Message);
            }
            finally
            {

                GridView1.DataBind();
            }
          
        
        }
        

    }


    protected void Button3_Click(object sender, EventArgs e)
    {
        try
        {
                connect c = new connect();
                SqlCommand command = new SqlCommand();
                command.CommandText = "update tax set tax_rate=@tax";
                command.Connection = c.connecttosql();
                command.Parameters.Add("@tax", TextBox3.Text);
                command.ExecuteNonQuery();
                Label3.Text = "updated tax rate at " + DateTime.Now;

                    

            
        }
        catch (Exception ex)
        {

            Response.Write(ex.Message);
        }
        finally
        {

            
        }
          
        
    }
}