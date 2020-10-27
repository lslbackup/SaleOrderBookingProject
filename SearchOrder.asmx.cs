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
using System.Web.Script.Services;
using Microsoft.Ajax.Utilities;

namespace SaleOrderBooking
{
	/// <summary>
	/// Summary description for SearchOrder
	/// </summary>
	[WebService(Namespace = "http://tempuri.org/")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	[System.ComponentModel.ToolboxItem(false)]
	// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
	[System.Web.Script.Services.ScriptService]

	public class SearchOrder : System.Web.Services.WebService
	{
		

		[ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
		[WebMethod]
		//public void OrderSearch(string SALMANDB, string PCOD,string AGCD)

		public void OrderSearch()
		{
			string cs = ConfigurationManager.ConnectionStrings["CN"].ConnectionString;
			List<ORDSRCH> ordno = new List<ORDSRCH>();
			using (SqlConnection con = new SqlConnection(cs))
			{
				    
					SqlCommand cmd = new SqlCommand("SELECT ORDMAN.UNIT,DCOD,ORDMAN.DBCD,PCOD,ORDMAN.BRCD,ORDMAN.TXCD,ORDT,ORDN,PORD,TRCD,QNTY,ICOD,ORDMAN.RATE AS RATE,ARAT,ACCMST.NAME AS PARTY,REFMST.NAME AS AGENT,FINITMMST.NAME AS ITEM,GRDMST.GRAD AS GRADE FROM ORDMAN LEFT JOIN ACCMST ON ORDMAN.PCOD = ACCMST.CODE LEFT JOIN REFMST ON ORDMAN.BRCD = REFMST.CODE LEFT JOIN FINITMMST ON ORDMAN.COMP = FINITMMST.COMP AND ORDMAN.UNIT = FINITMMST.UNIT AND ORDMAN.DCOD = FINITMMST.DVCD AND ORDMAN.ICOD = FINITMMST.CODE LEFT JOIN GRDMST ON ORDMAN.TRCD = GRDMST.CODE  WHERE ORDMAN.COMP = '0001' AND ORDMAN.UNIT ='000001' AND ISNULL(FIN_APRV,'')='N'  ORDER BY ORDMAN.ORDN ", con);
					cmd.CommandType = CommandType.Text;
				

				con.Open();
				
				SqlDataReader rdr = cmd.ExecuteReader();
				while (rdr.Read())
				{
					ORDSRCH ordnn = new ORDSRCH();
					ordnn.ORDN = rdr["ORDN"].ToString();
					ordnn.ITEM = rdr["ITEM"].ToString();
					ordnn.ORDT = Convert.ToDateTime(rdr["ORDT"]);
                    ordnn.ICOD = rdr["ICOD"].ToString();
					ordnn.PCOD = rdr["PCOD"].ToString();
					ordnn.TRCD = rdr["TRCD"].ToString();
					ordnn.QNTY = Convert.ToInt32(rdr["QNTY"]);
					ordnn.GRADE = rdr["GRADE"].ToString();
					ordnn.PARTY = rdr["PARTY"].ToString();
					ordnn.AGENT = rdr["AGENT"].ToString();
					ordnn.RATE = Convert.ToInt32(rdr["RATE"]);
		            ordnn.PCOD = rdr["PCOD"].ToString();
					ordnn.BRCD = rdr["BRCD"].ToString();
					ordnn.TXCD = rdr["TXCD"].ToString();
                    ordnn.DBCD = rdr["DBCD"].ToString();
					ordnn.PORD = rdr["PORD"].ToString();
					ordnn.UNIT = rdr["UNIT"].ToString();
					ordnn.DCOD = rdr["DCOD"].ToString();
					ordno.Add(ordnn);
				}

			}

			JavaScriptSerializer jso = new JavaScriptSerializer();
			Context.Response.Write(jso.Serialize(ordno));

		}


		[WebMethod]
		public void OrderSearchList(string SALMANDB, string PCOD, string AGCD)

		//public void OrderSearch()
		{
			string cs = ConfigurationManager.ConnectionStrings["CN"].ConnectionString;
			List<ORDSRCH> ordno = new List<ORDSRCH>();
			using (SqlConnection con = new SqlConnection(cs))
			{

				SqlCommand cmd = new SqlCommand("SELECT ORDMAN.UNIT,DCOD,ORDMAN.DBCD,PCOD,ORDMAN.BRCD,ORDMAN.TXCD,ORDT,ORDN,PORD,TRCD,QNTY,ICOD,ORDMAN.RATE AS RATE,ARAT,ACCMST.NAME AS PARTY,REFMST.NAME AS AGENT,FINITMMST.NAME AS ITEM,GRDMST.GRAD AS GRADE FROM ORDMAN LEFT JOIN ACCMST ON ORDMAN.PCOD = ACCMST.CODE LEFT JOIN REFMST ON ORDMAN.BRCD = REFMST.CODE LEFT JOIN FINITMMST ON ORDMAN.COMP = FINITMMST.COMP AND ORDMAN.UNIT = FINITMMST.UNIT AND ORDMAN.DCOD = FINITMMST.DVCD AND ORDMAN.ICOD = FINITMMST.CODE LEFT JOIN GRDMST ON ORDMAN.TRCD = GRDMST.CODE  WHERE ORDMAN.COMP = '0001' AND ORDMAN.UNIT ='000001' AND ORDMAN.DBCD ='" + SALMANDB + "' AND ORDMAN.PCOD ='" + PCOD +  "' AND AGCD ='" + AGCD  + "' AND ISNULL(FIN_APRV,'')='N'  ORDER BY ORDMAN.ORDN ", con);
				cmd.CommandType = CommandType.Text;


				con.Open();

				SqlDataReader rdr = cmd.ExecuteReader();
				while (rdr.Read())
				{
					ORDSRCH ordnn = new ORDSRCH();
					ordnn.ORDN = rdr["ORDN"].ToString();
					ordnn.ITEM = rdr["ITEM"].ToString();
					ordnn.ORDT = Convert.ToDateTime(rdr["ORDT"]);
					ordnn.ICOD = rdr["ICOD"].ToString();
					ordnn.PCOD = rdr["PCOD"].ToString();
					ordnn.TRCD = rdr["TRCD"].ToString();
					ordnn.QNTY = Convert.ToInt32(rdr["QNTY"]);
					ordnn.GRADE = rdr["GRADE"].ToString();
					ordnn.PARTY = rdr["PARTY"].ToString();
					ordnn.AGENT = rdr["AGENT"].ToString();
					ordnn.RATE = Convert.ToInt32(rdr["RATE"]);
					ordnn.PCOD = rdr["PCOD"].ToString();
					ordnn.BRCD = rdr["BRCD"].ToString();
					ordnn.TXCD = rdr["TXCD"].ToString();
					ordnn.DBCD = rdr["DBCD"].ToString();
					ordnn.PORD = rdr["PORD"].ToString();
					ordnn.UNIT = rdr["UNIT"].ToString();
					ordnn.DCOD = rdr["DCOD"].ToString();
					ordno.Add(ordnn);
				}

			}

			JavaScriptSerializer jso = new JavaScriptSerializer();
			Context.Response.Write(jso.Serialize(ordno));

		}

	}
}