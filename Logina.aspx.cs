using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;
using System.Runtime.Remoting.Messaging;
using System.Web.Script.Serialization;

namespace SaleOrderBooking
{
    public partial class Logina : System.Web.UI.Page
    {

        static string cs = ConfigurationManager.ConnectionStrings["CN"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }


       

        protected void Button1_Click1(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CN"].ConnectionString);
            string STR = "SELECT * FROM USERMAST WHERE UID = @UID  AND PASS = @PASS";

            SqlCommand CMD = new SqlCommand(STR, con);
            con.Open();
            CMD.Parameters.Add("@UID", SqlDbType.VarChar).Value = Username.Text;
            CMD.Parameters.Add("@PASS", SqlDbType.VarChar).Value = Password.Text;
            //  SqlDataAdapter da = new SqlDataAdapter(CMD);
            SqlDataAdapter da = new SqlDataAdapter(STR, con);

            DataSet ds = new DataSet();
            SqlDataReader dr = CMD.ExecuteReader();
            // da.Fill(ds);

            if (dr.Read())
            {
                Response.Redirect("FinancialYr.aspx");

            }
            else
            {
                Response.Write("Invalid attempt to login");
            }

        }
    }
}




