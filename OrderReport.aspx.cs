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

namespace SaleOrderBooking
{
    public partial class OrderReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
			fillSalman();
            fillORDList();


        }
            private void fillSalman()
			{
				string connectionString = ConfigurationManager.ConnectionStrings["CN"].ConnectionString;
				using (SqlConnection sqlConnection = new SqlConnection(connectionString))
				{
					SqlCommand sqlCommand = new SqlCommand();
					sqlCommand.CommandText = "SELECT * FROM SALMANMST  ";


					sqlCommand.Connection = sqlConnection;
					sqlConnection.Open();
					DDSALMAN.DataSource = sqlCommand.ExecuteReader();
					DDSALMAN.DataTextField = "NAME";
				    DDSALMAN.DataValueField = "CODE";
				    DDSALMAN.DataBind();
				}
			}

        private void fillORDList()

        {

            string connectionString = ConfigurationManager.ConnectionStrings["CN"].ConnectionString;
            string sql = "SELECT ORDMAN.UNIT,DCOD,ORDMAN.DBCD,PCOD,ORDMAN.BRCD,ORDMAN.TXCD,ORDT,ORDN,PORD,TRCD,QNTY,DISPATCHQTY,CANCELQTY,(QNTY-DISPATCHQTY-CANCELQTY) AS BALQTY,ICOD,ORDMAN.RATE AS RATE,ARAT,ACCMST.NAME AS PARTY,REFMST.NAME AS AGENT,FINITMMST.NAME AS ITEM,GRDMST.GRAD AS GRADE FROM ORDMAN LEFT JOIN ACCMST ON ORDMAN.PCOD = ACCMST.CODE LEFT JOIN REFMST ON ORDMAN.BRCD = REFMST.CODE LEFT JOIN FINITMMST ON ORDMAN.COMP = FINITMMST.COMP AND ORDMAN.UNIT = FINITMMST.UNIT AND ORDMAN.DCOD = FINITMMST.DVCD AND ORDMAN.ICOD = FINITMMST.CODE LEFT JOIN GRDMST ON ORDMAN.TRCD = GRDMST.CODE  WHERE ORDMAN.COMP = '0001' AND ORDMAN.UNIT ='000001' AND (QNTY-DISPATCHQTY-CANCELQTY) >.001";

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
                            OrderGrid.DataSource = dt;
                            OrderGrid.DataBind();

                        }
                    }
                }

            }
        }


    }
}