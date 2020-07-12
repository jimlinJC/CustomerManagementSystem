using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppTest
{
    public partial class Default : System.Web.UI.Page
    {
        MySql.Data.MySqlClient.MySqlConnection conn;
        MySql.Data.MySqlClient.MySqlCommand cmd;



        protected void Page_Load(object sender, EventArgs e)
        {
            MySql.Data.MySqlClient.MySqlDataReader reader;
            StringBuilder table = new StringBuilder();
            String querystr;
            String connstr = System.Configuration.ConfigurationManager.ConnectionStrings["WebAppConnString"].ToString();
            conn = new MySql.Data.MySqlClient.MySqlConnection(connstr);
            conn.Open();
            querystr = "";
            //querystr = "SELECT * FROM webapp.userregistration WHERE username='"+usernameTextBox.Text+"'AND password='"+passwordTextBox.Text+"'";
            querystr = "SELECT * FROM hw4.customer";

            cmd = new MySql.Data.MySqlClient.MySqlCommand(querystr, conn);
            reader = cmd.ExecuteReader();

            table.Append("<table border ='1'>");
            table.Append("<tr><th>Last Name</th><th>First Name</th><th>Address</th><th>Email</th></tr>");

            while (reader.HasRows && reader.Read())
            {
                table.Append("<tr>");
                table.Append("<td><center>" + reader[1] + "</center></td>");
                table.Append("<td><center>" + reader[2] + "</center></td>");
                table.Append("<td><center>" + reader[3] + "</center></td>");
                table.Append("<td><center>" + reader[4] + "</center></td>");
                table.Append("<td><center><a href='Update.aspx?customerid=" + reader[0] + "&email="+reader[4]+"'>編輯</a></center></td>");
                table.Append("<td><center><a href='Delete.aspx?customerid=" + reader[0] + "'>刪除</a></center></td>");
                table.Append("</tr>");
                //<form action=Update.aspx method='post'><input type = 'hidden' name = 'customerid' value = "+ reader[0] + " /><button>編輯</button></form>"
            }
            table.Append("</table>");
            placeholder.Controls.Add(new Literal { Text = table.ToString() });
            reader.Close();
            conn.Close();
        }

        protected void registerEventMethod(object sender, EventArgs e)
        {
            MySql.Data.MySqlClient.MySqlDataReader reader;
            Boolean same = false;
            String querystr = "";
            String addQuerystr = "";
            String connstr = System.Configuration.ConfigurationManager.ConnectionStrings["WebAppConnString"].ToString();
            conn = new MySql.Data.MySqlClient.MySqlConnection(connstr);
            conn.Open();
            querystr = "SELECT * FROM hw4.customer";
            //Regex regex = new Regex(@"^[0-9]*$");
            //Match match = regex.Match(customerid.Text);
            //cmd = new MySql.Data.MySqlClient.MySqlCommand(querystr, conn);
            //reader = cmd.ExecuteReader();
            cmd = new MySql.Data.MySqlClient.MySqlCommand(querystr, conn);
            reader = cmd.ExecuteReader();
            while (reader.HasRows && reader.Read())
            {
                if (email.Text == reader[4].ToString())
                {
                    same = true;
                }
            }
            if (!String.IsNullOrEmpty(last_name.Text) && !String.IsNullOrEmpty(first_name.Text) && !String.IsNullOrEmpty(address.Text) && !String.IsNullOrEmpty(email.Text))
            {
                if (same == false)
                {
                    reader.Close();
                    addQuerystr = "INSERT INTO hw4.customer(last_name, first_name, address, email)" +
                        "VALUES('" + last_name.Text + "','" + first_name.Text + "','" + address.Text +
                        "','" + email.Text + "')";
                    cmd = new MySql.Data.MySqlClient.MySqlCommand(addQuerystr, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    Response.Redirect("Default.aspx");
                }
                else
                {
                    placeholder2.Controls.Add(new Literal { Text = "已有相同Email" });
                }

            }
            else
            {
                placeholder2.Controls.Add(new Literal { Text = "未填寫完成" });
            }




        }



    }
}