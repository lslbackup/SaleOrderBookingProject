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
    /// Summary description for EditOrder
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
       [System.Web.Script.Services.ScriptService]
    public class EditOrder : System.Web.Services.WebService
    {
		[ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
		[WebMethod]
		public void Getorddatt(string ORDNUM,string UNITNUM)
		{
			string cs = ConfigurationManager.ConnectionStrings["CN"].ConnectionString;
			List<ORDNN> ordno = new List<ORDNN>();
			using (SqlConnection con = new SqlConnection(cs))
			{

				//SqlCommand cmd = new SqlCommand("SELECT ORDMAN.COMP,ORDMAN.UNIT,ORDMAN.DCOD,ORDT,ORDN,TRCD,QNTY,ICOD,RATE,ARAT,FINITMMST.NAME AS ITEM,GRDMST.GRAD AS GRADE FROM ORDMAN LEFT JOIN FINITMMST ON ORDMAN.COMP = FINITMMST.COMP AND ORDMAN.UNIT = FINITMMST.UNIT AND ORDMAN.DCOD = FINITMMST.DVCD AND ORDMAN.ICOD = FINITMMST.CODE LEFT JOIN GRDMST ON ORDMAN.TRCD = GRDMST.CODE  WHERE ORDMAN.COMP = '0001' AND ORDMAN.UNIT='" + UNIT + "' AND ORDMAN.ORDN ='" + ORDN + "' ", con);
				//SqlCommand cmd = new SqlCommand("SELECT ORDN,FINITMMST.NAME AS ITEM FROM ORDMAN LEFT JOIN FINITMMST ON ORDMAN.COMP = FINITMMST.COMP AND ORDMAN.UNIT = FINITMMST.UNIT AND ORDMAN.DCOD = FINITMMST.DVCD AND ORDMAN.ICOD = FINITMMST.CODE WHERE ORDMAN.COMP = '0001' AND ORDN ='" + ORDNUM + "' and ORDMAN.UNIT ='" + UNITNUM + "' ", con);

				SqlCommand cmd = new SqlCommand("SELECT ORDMAN.COMP,ORDMAN.UNIT,ORDMAN.DCOD,DBCD,PCOD,BRCD,TXCD,DCODE,ADDR,ORDT,ORDN,PORD,TRCD,QNTY,ICOD,ORDMAN.RATE AS RATE,ARAT,FINITMMST.NAME AS ITEM,GRDMST.GRAD AS GRADE FROM ORDMAN LEFT JOIN FINITMMST ON ORDMAN.COMP = FINITMMST.COMP AND ORDMAN.UNIT = FINITMMST.UNIT AND ORDMAN.DCOD = FINITMMST.DVCD AND ORDMAN.ICOD = FINITMMST.CODE LEFT JOIN GRDMST ON ORDMAN.TRCD = GRDMST.CODE  WHERE ORDMAN.COMP = '0001' AND ORDMAN.UNIT='" + UNITNUM + "' AND ORDMAN.ORDN ='" + ORDNUM + "' ", con);

				cmd.CommandType = CommandType.Text;

				con.Open();
				SqlDataReader rdr = cmd.ExecuteReader();
				while (rdr.Read())
				{
					ORDNN ordnn = new ORDNN();
					ordnn.ORDN = rdr["ORDN"].ToString();
					ordnn.ITEM = rdr["ITEM"].ToString();
                    ordnn.ORDT = Convert.ToDateTime(rdr["ORDT"]);
					ordnn.ORDN = rdr["ORDN"].ToString();
					ordnn.ITEM = rdr["ITEM"].ToString();
					ordnn.ICOD = rdr["ICOD"].ToString();
					ordnn.TRCD = rdr["TRCD"].ToString();
					ordnn.QNTY = Convert.ToInt32(rdr["QNTY"]);
					ordnn.GRADE = rdr["GRADE"].ToString();
					ordnn.RATE = Convert.ToInt32(rdr["RATE"]);
					ordnn.ARAT = Convert.ToInt32(rdr["ARAT"]);
					ordnn.PCOD = rdr["PCOD"].ToString();
					ordnn.BRCD = rdr["BRCD"].ToString();
					ordnn.TXCD = rdr["TXCD"].ToString();
					ordnn.DCOD = rdr["DCOD"].ToString();
					ordnn.ADDR = rdr["ADDR"].ToString();
					ordnn.UNIT = rdr["UNIT"].ToString();
					ordnn.DCODE = rdr["DCODE"].ToString();
					ordnn.DBCD = rdr["DBCD"].ToString();
					ordnn.PORD = rdr["PORD"].ToString();

					ordno.Add(ordnn);
				}

			}
		
			JavaScriptSerializer jst = new JavaScriptSerializer();
             Context.Response.Write(jst.Serialize(ordno));
			
		}


		
		[WebMethod]
        public void Getorddata(string ORDN, string UNIT)

		{
			string cs = ConfigurationManager.ConnectionStrings["CN"].ConnectionString;
			List<ORDMANT> orderno = new List<ORDMANT>();
			using (SqlConnection con = new SqlConnection(cs))
			{

				SqlCommand cmd = new SqlCommand("SELECT ORDN,FINITMMST.NAME AS ITEM FROM ORDMAN LEFT JOIN FINITMMST ON ORDMAN.COMP = FINITMMST.COMP AND ORDMAN.UNIT = FINITMMST.UNIT AND ORDMAN.DCOD = FINITMMST.DVCD AND ORDMAN.ICOD = FINITMMST.CODE WHERE ORDMAN.COMP = '0001' AND ORDMAN.UNIT='"+ UNIT +"' AND ORDMAN.ORDN ='"+ ORDN +"' ", con);
				
				cmd.CommandType = CommandType.Text;

				con.Open();
				SqlDataReader rdr = cmd.ExecuteReader();
				while (rdr.Read())
				{
					ORDMANT ordn = new ORDMANT();
				
					ordn.ORDN = rdr["ORDN"].ToString();
					ordn.ITEM = rdr["ITEM"].ToString();
					
					

					orderno.Add(ordn);
				}

			}

			JavaScriptSerializer aas = new JavaScriptSerializer();
			Context.Response.Write(aas.Serialize(orderno));
		}
	}
}
