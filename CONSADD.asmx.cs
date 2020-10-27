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
    /// Summary description for CONSADD
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
     [System.Web.Script.Services.ScriptService]
    public class CONSADD : System.Web.Services.WebService
    {

        [WebMethod]
        public void GetConsaddr(String CONCOD)
        {
            string cs = ConfigurationManager.ConnectionStrings["CN"].ConnectionString;
            List<CONS> CON = new List<CONS>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM PADDMST WHERE CODE =@CONSCOD", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@CONSCOD",CONCOD );
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    CONS cons = new CONS();
                    cons.ADDR = rdr["ADDR"].ToString();
                    cons.SRNO = rdr["SRNO"].ToString();
                    cons.CONCOD = rdr["CODE"].ToString();
                    CON.Add(cons);
                }
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(CON));
        }

        [WebMethod]
        public void GetFinItem(String dvcd)
        {
            string cs = ConfigurationManager.ConnectionStrings["CN"].ConnectionString;
            List<FINITM> FINITEM = new List<FINITM>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM FINITMMST WHERE COMP ='0001' AND UNIT = '000001' AND DVCD =@DVCD", con);
                cmd.CommandType = CommandType.Text;
                
                cmd.Parameters.AddWithValue("@DVCD", dvcd);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    FINITM finitm = new FINITM();
                    finitm.CODE = rdr["CODE"].ToString();
                    finitm.NAME = rdr["NAME"].ToString();
                    finitm.DVCD = rdr["DVCD"].ToString();
                    finitm.UNIT = rdr["UNIT"].ToString();
                    FINITEM.Add(finitm);
                }
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(FINITEM));
        }

        [WebMethod]
        public void GetPartyInfo(String pcod)
        {
            string cs = ConfigurationManager.ConnectionStrings["CN"].ConnectionString;
            List<PCOD> PCODE = new List<PCOD>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("SELECT TAXMST.NAME AS TAXNAME, REFMST.NAME AS AGENT,ACCMST.TXCD AS TXCD,ACCMST.BRCD AS BRCD  FROM ACCMST LEFT JOIN TAXMST ON ACCMST.TXCD = TAXMST.CODE LEFT JOIN REFMST ON ACCMST.BRCD = REFMST.CODE WHERE ACCMST.CODE =@PCOD", con);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@PCOD", pcod);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    PCOD pcode = new PCOD();
                    pcode.TXCD = rdr["TXCD"].ToString();
                    pcode.BRCD = rdr["BRCD"].ToString();
                    
                    PCODE.Add(pcode);
                }
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(PCODE));
        }

        [WebMethod]
        public void GeNORDER(String pcod)
        {
            string cs = ConfigurationManager.ConnectionStrings["CN"].ConnectionString;
            List<PCOD> PCODE = new List<PCOD>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("SELECT TAXMST.NAME AS TAXNAME, REFMST.NAME AS AGENT,ACCMST.TXCD AS TXCD,ACCMST.BRCD AS BRCD  FROM ACCMST LEFT JOIN TAXMST ON ACCMST.TXCD = TAXMST.CODE LEFT JOIN REFMST ON ACCMST.BRCD = REFMST.CODE WHERE ACCMST.CODE =@PCOD", con);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@PCOD", pcod);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    PCOD pcode = new PCOD();
                    pcode.TXCD = rdr["TXCD"].ToString();
                    pcode.BRCD = rdr["BRCD"].ToString();

                    PCODE.Add(pcode);
                }
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(PCODE));
        }






    }

}
