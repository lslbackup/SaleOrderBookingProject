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
	/// <summary>
	/// Summary description for SALORD
	/// </summary>
	[WebService(Namespace = "http://tempuri.org/")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	[System.ComponentModel.ToolboxItem(false)]
	// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
	[System.Web.Script.Services.ScriptService]

	public class SALORD : System.Web.Services.WebService
	{
		public SALORD()
		{

			//Uncomment the following line if using designed components 
			//InitializeComponent(); 
		}

		[WebMethod]
		//public static List<Employees> GetEmployee()
		public void GetOrderData()
		{
			string cs = ConfigurationManager.ConnectionStrings["CN"].ConnectionString;
			List<ORDMAN> order = new List<ORDMAN>();
			using (SqlConnection con = new SqlConnection(cs))
			{
				
		     SqlCommand cmd = new SqlCommand("SELECT ORDMAN.COMP,ORDMAN.UNIT,ORDMAN.DCOD,ORDMAN.DBCD,ORDMAN.BRCD,ORDMAN.PCOD,ORDMAN.TXCD,ORDMAN.DCODE,ORDMAN.ADDR,ORDT,ORDN,MAX(ORDMAN.PORD) AS PORD,ISNULL(SUM(ORDMAN.QNTY),0) AS QNTY,MAX(FINITMMST.NAME) AS ITEM,MAX(ACCMST.NAME) AS PARTY,MAX(TAXMST.NAME) AS TAXNAME ,MAX(REFMST.NAME) AS AGENT FROM ORDMAN LEFT JOIN FINITMMST ON ORDMAN.COMP = FINITMMST.COMP AND ORDMAN.UNIT = FINITMMST.UNIT AND ORDMAN.DCOD = FINITMMST.DVCD AND ORDMAN.ICOD = FINITMMST.CODE LEFT JOIN ACCMST ON ORDMAN.PCOD = ACCMST.CODE LEFT JOIN REFMST ON ORDMAN.BRCD = REFMST.CODE LEFT JOIN TAXMST ON ORDMAN.TXCD = TAXMST.CODE WHERE ORDMAN.COMP = '0001' AND FIN_APRV='N' GROUP BY ORDMAN.COMP, ORDMAN.UNIT, ORDMAN.DCOD, ORDT, ORDN,ORDMAN.DBCD,ORDMAN.BRCD,ORDMAN.PCOD,ORDMAN.TXCD,ORDMAN.DCODE,ORDMAN.ADDR", con);
				cmd.CommandType = CommandType.Text;

				con.Open();
				SqlDataReader rdr = cmd.ExecuteReader();
				while (rdr.Read())
				{
					ORDMAN ord = new ORDMAN();
					ord.ORDT = Convert.ToDateTime(rdr["ORDT"]);
					ord.ORDN = rdr["ORDN"].ToString();
					ord.PARTY = rdr["PARTY"].ToString();
					ord.QNTY = Convert.ToInt32(rdr["QNTY"]);
					ord.AGENT = rdr["AGENT"].ToString();
					ord.UNIT = rdr["UNIT"].ToString();
					ord.DCOD = rdr["DCOD"].ToString();
					ord.DBCD = rdr["DBCD"].ToString();
					ord.BRCD = rdr["BRCD"].ToString();
					ord.TXCD = rdr["TXCD"].ToString();
					ord.DCODE = rdr["DCODE"].ToString();
					ord.ADDR = rdr["ADDR"].ToString();
					ord.PORD = rdr["PORD"].ToString();
					ord.PCOD = rdr["PCOD"].ToString();
					//ord.QNTY = Convert.ToInt32(rdr["QNTY"]);

					order.Add(ord);
				}

			}

			JavaScriptSerializer js = new JavaScriptSerializer();
			Context.Response.Write(js.Serialize(order));
		}
	}
}


