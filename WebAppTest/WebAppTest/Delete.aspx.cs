using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppTest
{
    public partial class Delete : System.Web.UI.Page
    {
        MySql.Data.MySqlClient.MySqlConnection conn;
        MySql.Data.MySqlClient.MySqlCommand cmd;
        MySql.Data.MySqlClient.MySqlDataReader reader;
        protected void Page_Load(object sender, EventArgs e)
        {
            var customerId = Request.QueryString["customerid"].ToString();

            String delQuerystr;
            String connstr = System.Configuration.ConfigurationManager.ConnectionStrings["WebAppConnString"].ToString();
            conn = new MySql.Data.MySqlClient.MySqlConnection(connstr);
            conn.Open();
            delQuerystr = "";

            delQuerystr = @"DELETE FROM customer WHERE customerid='" + customerId + "'";
            cmd = new MySql.Data.MySqlClient.MySqlCommand(delQuerystr, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            Response.Redirect("Default.aspx");
        }
      
    }
}