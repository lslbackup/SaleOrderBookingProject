using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using Newtonsoft.Json;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;
using System.Runtime.Remoting.Messaging;
using System.Web.Script.Serialization;

namespace SaleOrderBooking
{
    public partial class FinancialYr : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["CN"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadfinyr();
            }
        }
        private void loadfinyr()
        {
            using (SqlConnection con = new SqlConnection(cs))
            {

                string query = "Select  Distinct CONVERT(VARCHAR(10), STFY, 103) as STFYY,CONVERT(VARCHAR(10), ENFY, 103) as ENFYY,FYCD,ENFY,STFY  From SERIALMASTER ORDER BY ENFY DESC";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    ListItem li = new ListItem(rdr["STFYY"].ToString() + " To " + rdr["ENFYY"].ToString(), rdr["FYCD"].ToString());
                    DDFINYR.Items.Add(li);


                }


            }
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            Response.Redirect("CompSelection.aspx");
        }
    }
}