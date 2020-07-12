using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppTest
{
    public partial class Registration : System.Web.UI.Page
    {

        MySql.Data.MySqlClient.MySqlConnection conn;
        MySql.Data.MySqlClient.MySqlCommand cmd;
        MySql.Data.MySqlClient.MySqlDataReader reader;

        String querystr;

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void registerEventMethod(object sender, EventArgs e)
        {
            String connstr = System.Configuration.ConfigurationManager.ConnectionStrings["WebAppConnString"].ToString();
            conn = new MySql.Data.MySqlClient.MySqlConnection(connstr);
            conn.Open();
            querystr = "";
            Regex regex = new Regex(@"^[0-9]*$");
            Match match = regex.Match(customerid.Text);

            if (!String.IsNullOrEmpty(customerid.Text) && !String.IsNullOrEmpty(last_name.Text) && !String.IsNullOrEmpty(first_name.Text) && !String.IsNullOrEmpty(address.Text) && !String.IsNullOrEmpty(email.Text))
            {
                if (match.Success)
                {
                    querystr = "INSERT INTO hw4.customer(customerid, last_name, first_name, address, email)" +
                        "VALUES('" + customerid.Text + "','" + last_name.Text + "','" + first_name.Text + "','" + address.Text +
                        "','" + email.Text + "')";

                    cmd = new MySql.Data.MySqlClient.MySqlCommand(querystr, conn);
                    cmd.ExecuteReader();
                    conn.Close();
                    Response.Redirect("Default.aspx");
                }
                else
                {
                    placeholder2.Controls.Add(new Literal { Text = "ID填入數字" });
                }
            }
            else
            {
                placeholder2.Controls.Add(new Literal { Text = "未填寫完成" });
            }
        }
    }
      
}