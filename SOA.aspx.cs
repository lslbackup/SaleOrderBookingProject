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
    public partial class SOA : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
			fillSALMAN();
			fillParty();
			FILLDDAGENT();
		}

		private void fillSALMAN()
		{
			string connectionString = ConfigurationManager.ConnectionStrings["CN"].ConnectionString;
			using (SqlConnection sqlConnection = new SqlConnection(connectionString))
			{
				SqlCommand sqlCommand = new SqlCommand();
				sqlCommand.CommandText = "SELECT * FROM SALMANMST";
				sqlCommand.Connection = sqlConnection;
				sqlConnection.Open();
				DDSALMAN.DataSource = sqlCommand.ExecuteReader();
				DDSALMAN.DataTextField = "NAME";
				DDSALMAN.DataValueField = "CODE";
				DDSALMAN.DataBind();
			}
		}

		private void fillParty()
		{

			string connectionString = ConfigurationManager.ConnectionStrings["CN"].ConnectionString;
			using (SqlConnection sqlConnection = new SqlConnection(connectionString))
			{
				SqlCommand sqlCommand = new SqlCommand();
				sqlCommand.CommandText = "SELECT * FROM ACCMST WHERE DRCR='D'  ORDER BY NAME ";
				sqlCommand.Connection = sqlConnection;
				sqlConnection.Open();
			//	TXTPCOD.DataSource = sqlCommand.ExecuteReader();
			//	TXTPCOD.DataTextField = "NAME";
			//	TXTPCOD.DataValueField = "CODE";

			//	TXTPCOD.DataBind();

			}

		}
		private void FILLDDAGENT()
		{
			string connectionString = ConfigurationManager.ConnectionStrings["CN"].ConnectionString;
			using (SqlConnection sqlConnection = new SqlConnection(connectionString))
			{
				SqlCommand sqlCommand = new SqlCommand();
				sqlCommand.CommandText = "SELECT * FROM REFMST WHERE CATA ='B'";
				sqlCommand.Connection = sqlConnection;
				sqlConnection.Open();
			//	TXTAGCD.DataSource = sqlCommand.ExecuteReader();
			//	TXTAGCD.DataTextField = "NAME";
			//	TXTAGCD.DataValueField = "CODE";
			//	TXTAGCD.DataBind();
			}
		}


		[WebMethod]
		public static string UpdateOrder(string ordnn, string dbcd)
				
		{
            string connectionString = ConfigurationManager.ConnectionStrings["CN"].ConnectionString;
			using (SqlConnection sqlConnection = new SqlConnection(connectionString))
			{
				SqlCommand delcmd = new SqlCommand();
				//delcmd.CommandText = "UPDATE FROM ORDMAN WHERE COMP ='0001' AND UNIT ='000001' AND ORDN ='" + ordnn + "' AND DBCD ='" + dbcd + "' ";
				delcmd.CommandText = "UPDATE FROM ORDMAN WHERE COMP ='0001' AND UNIT ='000001'  ";
				delcmd.Connection = sqlConnection;
		        sqlConnection.Open();
				delcmd.ExecuteNonQuery();
		        sqlConnection.Close();

				return "First data will delete then after save";
            }
		}


		
		[WebMethod]
		//public static string UpdateOrder(string ordnn, string dbcd
				public static string UpdateOrderd()
		{
           
				return "a";
           
		}


	}
}