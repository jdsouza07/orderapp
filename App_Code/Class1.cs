using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for Class1
/// </summary>
namespace connection
{
        public class connect
            {
	
		//
		// TODO: Add constructor logic here
           SqlConnection getconnected = null;
       

                public SqlConnection connecttosql()
                {
                    getconnected = new SqlConnection(ConfigurationManager.ConnectionStrings["Database1ConnectionString"].ConnectionString);
                    getconnected.Open();
                    return getconnected;  
             
                }
                public SqlConnection closesqlconnection()
                {
                    getconnected.Close();
                    return getconnected;



        }

        
		//
	}
}
