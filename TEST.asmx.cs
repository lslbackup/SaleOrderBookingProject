﻿using System;
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
using System.Web.Script.Services;
using Microsoft.Ajax.Utilities;

namespace SaleOrderBooking
{
    /// <summary>
    /// Summary description for TEST
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
     [System.Web.Script.Services.ScriptService]
    public class TEST : System.Web.Services.WebService
    {

        [WebMethod]
       public string UpdateOrder(string ORDN, string DBCD)
				
		{
            string connectionString = ConfigurationManager.ConnectionStrings["CN"].ConnectionString;
			using (SqlConnection sqlConnection = new SqlConnection(connectionString))
			{
				SqlCommand delcmd = new SqlCommand();
               
                  delcmd.CommandText = "UPDATE ORDMAN SET FIN_APRV ='O' WHERE COMP ='0001' AND UNIT ='000001' AND ORDN ='" + ORDN + "' AND DBCD ='" + DBCD + "'  ";
            


				//delcmd.CommandText = "UPDATE FROM ORDMAN WHERE COMP ='0001' AND UNIT ='000001'  ";
				delcmd.Connection = sqlConnection;
		        sqlConnection.Open();
				delcmd.ExecuteNonQuery();
		        sqlConnection.Close();

				return "First data will delete then after save";
            }
		}
    }
}
