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
    public partial class POAppr : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
			fillPOTYPE();

		}

		private void fillPOTYPE()
		{
			string connectionString = ConfigurationManager.ConnectionStrings["CN"].ConnectionString;
			using (SqlConnection sqlConnection = new SqlConnection(connectionString))
			{
				SqlCommand sqlCommand = new SqlCommand();
				sqlCommand.CommandText = "SELECT CODE,NAME FROM POMASTER WHERE COMP ='0001' AND UNIT ='000001'";
				sqlCommand.Connection = sqlConnection;
				sqlConnection.Open();
				DDPOTYPE.DataSource = sqlCommand.ExecuteReader();
				DDPOTYPE.DataTextField = "NAME";
				DDPOTYPE.DataValueField = "CODE";
				DDPOTYPE.DataBind();
			}
		}

	}
}