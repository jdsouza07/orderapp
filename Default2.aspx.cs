using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using connection;
using System.Data.SqlClient;
using System.Data;


public partial class Default2 : System.Web.UI.Page
{
    //DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
       
      //  dt.Columns.AddRange(new DataColumn[4] {
       //         new DataColumn("Product Name"), new DataColumn("Qty"), new DataColumn("Price"), new DataColumn("Total") });

        //TextBox2.Text=price.ToString();
        //command1.Dispose();
        fillordergrid();
        TextBox2.Text=previousbalance().ToString();
        
    }

   public Decimal previousbalance()
   {

       connect c = new connect();
       SqlCommand command1 = new SqlCommand();
       command1.CommandText="select sum(total) from orders";
       command1.Connection=c.connecttosql();

        decimal amount= (decimal) command1.ExecuteScalar();


        return amount;
   }


    public void fillordergrid()
    {   
    
        connect c = new connect();
        SqlDataAdapter sa = new SqlDataAdapter("select * from orders", c.connecttosql());
        DataTable d = new DataTable();
        sa.Fill(d);

        GridView3.DataSource = d;
        GridView3.DataBind();

    
    
    
    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        


            //double price;
            //if (TextBox2.Text == string.Empty)
            //{
            //    price = 0.00;
            //    TextBox2.Text = Convert.ToString(findtotal(price));
            //}
            //else
            //{
            //    double newprice = double.Parse(TextBox2.Text);

            //    TextBox2.Text = Convert.ToString(findtotal(newprice));
            //}


         string selected_text = DropDownList1.Text;
        try
        {
            connect c = new connect();
            SqlCommand command1 = new SqlCommand();
            command1.Connection = c.connecttosql();
            command1.CommandText = "Procedure2";
            command1.Parameters.AddWithValue("@param1", Convert.ToInt32(DropDownList2.Text));
            command1.CommandType = CommandType.StoredProcedure;
            decimal price = (decimal)command1.ExecuteScalar();
            decimal pricetotalunits = (price * (Convert.ToDecimal(TextBox1.Text)));
            //TextBox2.Text=price.ToString();
            command1.Dispose();



            SqlCommand command2 = new SqlCommand();
            command2.Connection = c.connecttosql();
            command2.CommandText = "select tax_rate from tax";
            //command1.Parameters.AddWithValue("@param1", Convert.ToInt32(DropDownList2.Text));
            //command1.CommandType = CommandType.StoredProcedure;
            double taxrate = (double)command2.ExecuteScalar();
            decimal tax_amt = (pricetotalunits * Convert.ToDecimal((taxrate / 100)));
            decimal sub_total = pricetotalunits; ;
            decimal total = sub_total + tax_amt;

            //TextBox3.Text = tax_amt.ToString();
            //TextBox4.Text = sub_total.ToString();
            //TextBox5.Text = total.ToString();
            //command2.Dispose();

            TextBox3.Text = DropDownList2.SelectedItem.Value;
            TextBox4.Text = TextBox1.Text;
            TextBox5.Text = price.ToString();
            TextBox6.Text = tax_amt.ToString();
            TextBox7.Text = total.ToString();

            

            
            

            









        }
        catch (Exception ex)
        {

            Response.Write(ex.Message);

        }
    }


    //public Double findtotal(double price)
    //{
    //    double total = price;        
    //    total = total + 0.5;
    //    return total;
    //}


    protected void DropDownList1_SelectedIndexChanged1(object sender, EventArgs e)
    {
        string selected_text = DropDownList1.Text;
        try
        {
            connect c = new connect();
            SqlCommand command1 = new SqlCommand();
            command1.Connection = c.connecttosql();
            command1.CommandText = "Procedure1";
            command1.Parameters.AddWithValue("@param1", Convert.ToInt32(DropDownList1.Text));
            command1.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter1 = new SqlDataAdapter(command1);


            DataTable datatable1 = new DataTable();

            adapter1.Fill(datatable1);

           DropDownList2.DataSource = datatable1;

            DropDownList2.DataTextField = "prod_name";
            DropDownList2.DataValueField = "prod_id";
            DropDownList2.DataBind();

            adapter1.Dispose();
            c.closesqlconnection();
            // TextBox1.Text = DropDownList1.SelectedItem.Text;
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);

        }
    }

    //public void dropbox1()
    //{

    //    connect c = new connect();
    //    SqlCommand command1 = new SqlCommand();
    //    command1.Connection = c.connecttosql();
    //    command1.CommandText = "select cat_id, cat_name from categories";

    //    SqlDataAdapter adapter1 = new SqlDataAdapter(command1);

    //   DataTable datatable1 = new DataTable();

    //    adapter1.Fill(datatable1);



    //    DropDownList1.DataSource = datatable1;

    //    DropDownList1.DataTextField = "cat_name";
    //    DropDownList1.DataValueField = "cat_id";
    //    DropDownList1.DataBind();

    //}


    //protected void Button1_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        connect c = new connect();
    //        SqlCommand command1 = new SqlCommand();
    //        command1.Connection = c.connecttosql();
    //        command1.CommandText = "select * from orders";
    //        SqlDataAdapter adapter1 = new SqlDataAdapter(command1);

    //        DataTable datatable1 = new DataTable();

    //        adapter1.Fill(datatable1);



    //        GridView1.DataSource = datatable1;

    //       GridView1.DataBind();

    //        adapter1.Dispose();
    //        c.closesqlconnection();
    //    }
    //    catch (Exception ex)
    //    {
    //        Response.Write(ex.Message);

    //    }
    //}


    protected void Button2_Click(object sender, EventArgs e)
    {
        
        try
        {
            connect c = new connect();
            //SqlCommand command1 = new SqlCommand();
            //command1.Connection = c.connecttosql();
            //command1.CommandText = "Procedure2";
            //command1.Parameters.AddWithValue("@param1", Convert.ToInt32(DropDownList2.Text));
            //command1.CommandType = CommandType.StoredProcedure;
            //decimal price = (decimal)command1.ExecuteScalar();
            //decimal pricetotalunits = (price * (Convert.ToDecimal(TextBox1.Text)));
            ////TextBox2.Text=price.ToString();
            //command1.Dispose();



            //SqlCommand command2 = new SqlCommand();
            //command2.Connection = c.connecttosql();
            //command2.CommandText = "select tax_rate from tax";
            ////command1.Parameters.AddWithValue("@param1", Convert.ToInt32(DropDownList2.Text));
            ////command1.CommandType = CommandType.StoredProcedure;
            //double taxrate = (double)command2.ExecuteScalar();
            //decimal tax_amt = (pricetotalunits * Convert.ToDecimal((taxrate / 100)));
            //decimal sub_total = pricetotalunits; ;
            //decimal total = sub_total + tax_amt;

            //TextBox3.Text = tax_amt.ToString();
            //TextBox4.Text = sub_total.ToString();
            //TextBox5.Text = total.ToString();
            //command2.Dispose();


            SqlCommand command3 = new SqlCommand();
            command3.Connection = c.connecttosql();
            command3.CommandText = "select count(order_id) from orders";
            int orders = (int)(command3.ExecuteScalar());
            int orderid;
            command3.Dispose();
            if (orders > 0)
            {
                command3.CommandText = "select max(order_id) from orders";
                orderid = (int)(command3.ExecuteScalar());
                orderid++;
            }
            else
            {
                orderid = 1;

            }
            
            int productid = Convert.ToInt32(DropDownList2.SelectedValue);

            SqlCommand command4 = new SqlCommand();
            command4.Connection = c.connecttosql();
            command4.CommandText = "insert into orders values (@order_id,@prod_id,@tax_amt,@total,@qty,@status,@status_date,@unitprice,@username)";
            command4.Parameters.AddWithValue("@order_id", orderid);
            command4.Parameters.AddWithValue("@prod_id", productid);
            command4.Parameters.AddWithValue("@tax_amt", Convert.ToDecimal(TextBox6.Text));
            command4.Parameters.AddWithValue("@total",Convert.ToDecimal(TextBox7.Text));
            command4.Parameters.AddWithValue("@qty", Convert.ToInt32(TextBox4.Text));
            command4.Parameters.AddWithValue("@status","");
            command4.Parameters.AddWithValue("@status_date", "");
            command4.Parameters.AddWithValue("@unitprice", Convert.ToDecimal(TextBox5.Text));
            command4.Parameters.AddWithValue("@username", "");
            command4.ExecuteNonQuery();
            // TextBox2.Text = price.ToString();
            // command1.Dispose();
            fillordergrid();
            TextBox2.Text = previousbalance().ToString();




        }
        catch (Exception ex)
        {
           Label5.Text=ex.Message;

        }
    }
}