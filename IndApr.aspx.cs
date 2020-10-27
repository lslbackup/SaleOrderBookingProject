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
using Microsoft.SqlServer.Server;
using System.EnterpriseServices;

namespace SaleOrderBooking
{
    public partial class IndApr : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                fillIndList();
                fillDept();
            }
           
          
        }

        private void fillDept()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["CN"].ConnectionString;
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = "SELECT * FROM DEPT_MST WHERE  UNIT ='000001' ";


                sqlCommand.Connection = sqlConnection;
                sqlConnection.Open();
                ddlDept.DataSource = sqlCommand.ExecuteReader();
                ddlDept.DataTextField = "NAME";
                ddlDept.DataValueField = "CODE";
                ddlDept.DataBind();
            }
        }

        private void fillIndList()

        {

            string connectionString = ConfigurationManager.ConnectionStrings["CN"].ConnectionString;
            string sql = "Select *,IDT_MST.DPCD,ITMMST.NAME AS ITEMNAME,DEPT_MST.NAME AS DEPARTMENT From IDT_TRN INNER JOIN IDT_MST ON IDT_MST.COMP=IDT_TRN.COMP AND IDT_MST.INDNO=IDT_TRN.INDNO INNER JOIN  ITMMST ON IDT_TRN.ICOD =ITMMST.CODE LEFT JOIN DEPT_MST ON IDT_MST.COMP =DEPT_MST.COMP AND IDT_MST.UNIT =DEPT_MST.UNIT AND IDT_MST.DPCD =DEPT_MST.CODE WHERE (ITEMSTATUS='N' OR ITEMSTATUS='H') AND IDT_TRN.COMP='0001' AND IDT_TRN.UNIT ='000001' AND IDT_TRN.RECSTAT <> 'D'";

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {

                using (SqlCommand cmd = new SqlCommand(sql))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = sqlConnection;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            GridList.DataSource = dt;
                            GridList.DataBind();
                            GridList.HeaderRow.TableSection = TableRowSection.TableHeader;
                        }
                    }
                }

            }
        }

        protected void GridList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlDept_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}