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
    public partial class UnitSelection : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["CN"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadunit();
            }
        }

        private void loadunit()
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                if (Session["comp_path"] != null)
                {
                    string query = "select CODE,NAME from UNTMST WHERE COMP ='" + Session["comp_path"] + "' ";
                    SqlCommand cmd = new SqlCommand(query, con);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        ListItem li = new ListItem(rdr["NAME"].ToString(), rdr["CODE"].ToString());
                        DDUNITSELECT.Items.Add(li);


                    }
                }
                else
                {
                    
                }

            }
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            Response.Redirect("NEWSALORDER.aspx");
        }
    }
}