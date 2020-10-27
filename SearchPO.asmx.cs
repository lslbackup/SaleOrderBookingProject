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
    /// Summary description for SearchPO
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
     [System.Web.Script.Services.ScriptService]
    public class SearchPO : System.Web.Services.WebService
    {
		[ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
		[WebMethod]
		public void POSearch()
		{
			string cs = ConfigurationManager.ConnectionStrings["CN"].ConnectionString;
			List<PO> ordno = new List<PO>();
			using (SqlConnection con = new SqlConnection(cs))
			{

				SqlCommand cmd = new SqlCommand("Select PO_TRN.*,PO_MST.PODATE,PO_MST.REMARKS,PO_TRN.DPCD AS DPCD,accmst.name as PARTY,ITMMST.NAME AS ITEM,DEPT_MST.NAME AS DEPARTMENT,PO_MST.ORCR,PO_MST.CRAT From PO_TRN LEFT JOIN PO_MST ON PO_MST.PONO = PO_TRN.PONO AND PO_MST.COMP = PO_TRN.COMP AND PO_MST.UNIT = PO_TRN.UNIT AND PO_MST.DBCD = PO_TRN.DBCD AND PO_MST.RECSTAT = PO_TRN.RECSTAT LEFT JOIN ACCMST ON ACCMST.CODE = PO_MST.PCOD LEFT JOIN ITMMST ON PO_TRN.ICOD =ITMMST.CODE  LEFT JOIN DEPT_MST ON PO_MST.COMP=DEPT_MST.COMP AND PO_MST.UNIT =DEPT_MST.UNIT AND PO_MST.DPCD=DEPT_MST.CODE  WHERE POSTAT IS NULL AND POSTATUS = 'P' AND PO_TRN.COMP = '0001' AND PO_TRN.UNIT = '000001'  AND PO_TRN.RECSTAT <> 'D' ORDER BY PO_TRN.PONO, PO_TRN.ICOD ", con);
				
				cmd.CommandType = CommandType.Text;


				con.Open();

				SqlDataReader rdr = cmd.ExecuteReader();
				while (rdr.Read())
				{
					PO PONUM = new PO();
					PONUM.PONO = rdr["PONO"].ToString();
					PONUM.ITEM = rdr["ITEM"].ToString();
					PONUM.PODATE = Convert.ToDateTime(rdr["PODATE"]);
					PONUM.DEPARTMENT = rdr["DEPARTMENT"].ToString();
					PONUM.ICOD = rdr["ICOD"].ToString();
					PONUM.QTY = Convert.ToInt32(rdr["QTY"]);
					PONUM.PARTY = rdr["PARTY"].ToString();
					PONUM.RATE = Convert.ToInt32(rdr["RATE"]);
					PONUM.REMARKS = rdr["REMARKS"].ToString();
				    PONUM.DBCD = rdr["DBCD"].ToString();
					PONUM.UNIT = rdr["UNIT"].ToString();
					
					ordno.Add(PONUM);
				}

			}

			JavaScriptSerializer jso = new JavaScriptSerializer();
			Context.Response.Write(jso.Serialize(ordno));

		}

	}
}