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
    public partial class CompSelection : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["CN"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            loadcompany();
        }

        private void loadcompany()
        {
            using (SqlConnection con = new SqlConnection(cs))
            {

                string query = "select COMP_PATH,COMP_NAME,COMP_ACID,COMP_ACFD from COMPMAST  ";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    ListItem li = new ListItem(rdr["COMP_NAME"].ToString(), rdr["COMP_PATH"].ToString());
                    DDCOMPSELECT.Items.Add(li);

                    Session["comp_path"] = rdr["COMP_PATH"];
                }


            }
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            Response.Redirect("UnitSelection.aspx");
        }
    }
}