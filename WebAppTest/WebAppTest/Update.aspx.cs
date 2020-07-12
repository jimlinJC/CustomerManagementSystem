using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppTest
{
    public partial class Update : System.Web.UI.Page
    {
        MySql.Data.MySqlClient.MySqlConnection conn;
        MySql.Data.MySqlClient.MySqlCommand cmd;
        MySql.Data.MySqlClient.MySqlDataReader reader;
        String customerId;
        String queremail;
        protected void Page_Load(object sender, EventArgs e)
        {
            customerId = Request.QueryString["customerid"].ToString();
            queremail = Request.QueryString["email"].ToString();
            String querystr;
            String connstr = System.Configuration.ConfigurationManager.ConnectionStrings["WebAppConnString"].ToString();
            conn = new MySql.Data.MySqlClient.MySqlConnection(connstr);
            conn.Open();
            querystr = "";
            //querystr = "SELECT * FROM webapp.userregistration WHERE username='"+usernameTextBox.Text+"'AND password='"+passwordTextBox.Text+"'";
            querystr = "SELECT * FROM hw4.customer WHERE customerid='" + customerId + "'";
            cmd = new MySql.Data.MySqlClient.MySqlCommand(querystr, conn);
            reader = cmd.ExecuteReader();

            while (reader.HasRows && reader.Read())
            {
                last_name.Attributes.Add("Value", reader[1].ToString());
                first_name.Attributes.Add("Value", reader[2].ToString());
                address.Attributes.Add("Value", reader[3].ToString());
                email.Attributes.Add("Value", reader[4].ToString());
            }
            conn.Close();
        }
        protected void updateEventMethod(object sender, EventArgs e)
        {
            String updateQuerystr = "";
            String querystr = "";
            Boolean same = false;
            String connstr = System.Configuration.ConfigurationManager.ConnectionStrings["WebAppConnString"].ToString();
            conn = new MySql.Data.MySqlClient.MySqlConnection(connstr);
            conn.Open();
            
            querystr = "SELECT * FROM hw4.customer WHERE email <>'" + queremail + "';";
            cmd = new MySql.Data.MySqlClient.MySqlCommand(querystr, conn);
            reader = cmd.ExecuteReader();
            while (reader.HasRows && reader.Read())
            {
                if (email.Text == reader[4].ToString())
                {
                    same = true;
                }
            }
            if (same == false)
            {
                reader.Close();
                updateQuerystr = "UPDATE hw4.customer SET last_name='" + last_name.Text + "',first_name='" + first_name.Text + "',address='" + address.Text +
                        "',email='" + email.Text + "' WHERE customerid='" + customerId + "'";
                cmd = new MySql.Data.MySqlClient.MySqlCommand(updateQuerystr, conn);
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.ExecuteReader();
                conn.Close();
                Response.Redirect("Default.aspx");
            }
            else
            {
                placeholder2.Controls.Add(new Literal { Text = "已有相同Email" });
            }
        }


    }
}