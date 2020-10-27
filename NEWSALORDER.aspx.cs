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
	public partial class NEWSALORDER : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)

		{
			if (!IsPostBack)
			{
				fillDDUNIT();
				fillDDDVCD();
				fillSALMAN();
				fillParty();
				fillTax();
				FILLDDAGENT();
				FILLDDITEM();
				FILLDDGRAD();
				FILLCONSIGNEE();
				FILLCONSIGNEEADDR();
				genordn();
			}
		}

		private void fillDDUNIT()
		{
			string connectionString = ConfigurationManager.ConnectionStrings["CN"].ConnectionString;
			using (SqlConnection sqlConnection = new SqlConnection(connectionString))
			{
				SqlCommand sqlCommand = new SqlCommand();
				sqlCommand.CommandText = "SELECT * FROM UNTMST";
				sqlCommand.Connection = sqlConnection;
				sqlConnection.Open();
				DDUNIT.DataSource = sqlCommand.ExecuteReader();
				DDUNIT.DataTextField = "NAME";
				DDUNIT.DataValueField = "CODE";
				DDUNIT.DataBind();
			}
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

		private void fillDDDVCD()
		{
			string connectionString = ConfigurationManager.ConnectionStrings["CN"].ConnectionString;
			using (SqlConnection sqlConnection = new SqlConnection(connectionString))
			{
				SqlCommand sqlCommand = new SqlCommand();
				sqlCommand.CommandText = "SELECT * FROM DIVMST WHERE CODE <>'000001' AND UNIT ='" + DDUNIT.Value + "' ";

				//sqlCommand.Parameters.AddWithValue("@UNIT", DDUNIT.DataValueField);
				sqlCommand.Connection = sqlConnection;
				sqlConnection.Open();
				DDDVCD.DataSource = sqlCommand.ExecuteReader();
				DDDVCD.DataTextField = "NAME";
				DDDVCD.DataValueField = "CODE";
				DDDVCD.DataBind();
			}
		}

		private void fillParty()
		{

			string connectionString = ConfigurationManager.ConnectionStrings["CN"].ConnectionString;
			using (SqlConnection sqlConnection = new SqlConnection(connectionString))
			{
				SqlCommand sqlCommand = new SqlCommand();
				sqlCommand.CommandText = "SELECT * FROM ACCMST  ORDER BY NAME ";
				sqlCommand.Connection = sqlConnection;
				sqlConnection.Open();
				TXTPCOD.DataSource = sqlCommand.ExecuteReader();
				TXTPCOD.DataTextField = "NAME";
				TXTPCOD.DataValueField = "CODE";

				TXTPCOD.DataBind();

			}

		}
		private void fillTax()
		{
			string connectionString = ConfigurationManager.ConnectionStrings["CN"].ConnectionString;
			using (SqlConnection sqlConnection = new SqlConnection(connectionString))
			{
				SqlCommand sqlCommand = new SqlCommand();
				sqlCommand.CommandText = "SELECT * FROM TAXMST  ";
				//sqlCommand.Parameters.AddWithValue("@TXCD", TXTPCOD.DataValueField);
				sqlCommand.Connection = sqlConnection;
				sqlConnection.Open();
				TXTTXCD.DataSource = sqlCommand.ExecuteReader();
				TXTTXCD.DataTextField = "NAME";
				TXTTXCD.DataValueField = "CODE";
				TXTTXCD.DataBind();
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
				TXTAGCD.DataSource = sqlCommand.ExecuteReader();
				TXTAGCD.DataTextField = "NAME";
				TXTAGCD.DataValueField = "CODE";
				TXTAGCD.DataBind();
			}
		}

		private void FILLDDITEM()
		{
			string connectionString = ConfigurationManager.ConnectionStrings["CN"].ConnectionString;
			using (SqlConnection sqlConnection = new SqlConnection(connectionString))
			{
				SqlCommand sqlCommand = new SqlCommand();
				sqlCommand.CommandText = "SELECT * FROM FINITMMST WHERE DVCD = '" + DDDVCD.Value + "' AND UNIT ='" + DDUNIT.Value + "'";
				sqlCommand.Connection = sqlConnection;
				sqlConnection.Open();
				TXTICOD.DataSource = sqlCommand.ExecuteReader();
				TXTICOD.DataTextField = "NAME";
				TXTICOD.DataValueField = "CODE";
				TXTICOD.DataBind();
			}
		}

		private void FILLDDGRAD()
		{
			string connectionString = ConfigurationManager.ConnectionStrings["CN"].ConnectionString;
			using (SqlConnection sqlConnection = new SqlConnection(connectionString))
			{
				SqlCommand sqlCommand = new SqlCommand();
				sqlCommand.CommandText = "SELECT * FROM GRDMST ";
				sqlCommand.Connection = sqlConnection;
				sqlConnection.Open();
				TXTGRAD.DataSource = sqlCommand.ExecuteReader();
				TXTGRAD.DataTextField = "GRAD";
				TXTGRAD.DataValueField = "CODE";
				TXTGRAD.DataBind();
			}
		}

		private void FILLCONSIGNEE()
		{
			string connectionString = ConfigurationManager.ConnectionStrings["CN"].ConnectionString;
			using (SqlConnection sqlConnection = new SqlConnection(connectionString))
			{
				SqlCommand sqlCommand = new SqlCommand();
				sqlCommand.CommandText = "SELECT * FROM PADDMST ";
				sqlCommand.Connection = sqlConnection;
				sqlConnection.Open();
				TXTCONCOD.DataSource = sqlCommand.ExecuteReader();
				TXTCONCOD.DataTextField = "NAME";
				TXTCONCOD.DataValueField = "CODE";
				TXTCONCOD.DataBind();
			}
		}

		private void FILLCONSIGNEEADDR()
		{
			string connectionString = ConfigurationManager.ConnectionStrings["CN"].ConnectionString;
			using (SqlConnection sqlConnection = new SqlConnection(connectionString))
			{
				SqlCommand sqlCommand = new SqlCommand();
				sqlCommand.CommandText = "SELECT * FROM PADDMST WHERE CODE ='" + TXTCONCOD.Value + "' ";
				sqlCommand.Connection = sqlConnection;
				sqlConnection.Open();
				TXTCONADDR.DataSource = sqlCommand.ExecuteReader();
				TXTCONADDR.DataTextField = "ADDR";
				TXTCONADDR.DataValueField = "SRNO";
				TXTCONADDR.DataBind();
			}
		}

		protected void DDSALMAN_SelectedIndexChanged(object sender, EventArgs e)
		{
			genordn();
		}
		protected void DDDVCD_SelectedIndexChanged(object sender, EventArgs e)
		{
			genordn();
		}


		private void genordn()
		{

			string PRFX;
			int code;
			try
			{
				SALORDER salord = new SALORDER();

				string CS = ConfigurationManager.ConnectionStrings["CN"].ConnectionString;
				using (SqlConnection CON = new SqlConnection(CS))
				{

					SqlCommand cmd = new SqlCommand();
					cmd.CommandText = "SELECT PRFX, SUBSTRING(LSRNO,2,5) AS SRNO,PRFX FROM SALMANMST WHERE CODE = '" + DDSALMAN.Value + "' GROUP BY PRFX,LSRNO  ";
					cmd.Connection = CON;
					CON.Open();

					DataTable dt = new DataTable();
					SqlDataAdapter da = new SqlDataAdapter(cmd);
					da.Fill(dt);


					if (dt.Rows.Count > 0)
					{
						PRFX = dt.Rows[0]["PRFX"].ToString();
						code = Convert.ToInt32(dt.Rows[0]["SRNO"]);


						//PRFX = (string)DR["PRFX".ToString()];
						//code = (int)DR["SRNO".ToString()];

						code++;
						string gencode = "";
						if (code.ToString().Length == 1)
						{
							gencode = "0000" + code.ToString();
						}
						else if (code.ToString().Length == 2)
						{
							gencode = "000" + code.ToString();
						}
						else if (code.ToString().Length == 3)
						{
							gencode = "00" + code.ToString();
						}
						else if (code.ToString().Length == 4)
						{
							gencode = "0" + code.ToString();
						}
						else
						{
							gencode = code.ToString();
						}
						Session["GENCODE"] = gencode;

						TXTORDN.Value = PRFX + gencode + "2021";
					}

					else
					{

						TXTORDN.Value = string.Empty;
						throw new Exception("Unable to generate the Order No. !!!");
					}
				}
			}

			catch (Exception e)

			{

			}


		}
        protected void Save_click(object sender, EventArgs e)
		{
        }

    public class ORDNN
    {
        public DateTime ORDT { get; set; }
        public string ORDN { get; set; }
        public string PCOD { get; set; }
        public string ICOD { get; set; }
        public string TRCD { get; set; }
        public int QNTY { get; set; }
        public int RATE { get; set; }
        public int ARAT { get; set; }
        public string PORD { get; set; }
        public string TXCD { get; set; }
        public string BRCD { get; set; }
        public string PARTY { get; set; }
        public string AGENT { get; set; }
        public string ITEM { get; set; }
        public string GRADE { get; set; }

        public string UNIT { get; set; }
        public string DCOD { get; set; }
        public string DBCD { get; set; }
        public string DCODE { get; set; }
        public string ADDR { get; set; }


    }

		public class ORDMANNN
		{
			public string COMP { get; set; }
			public string UNIT { get; set; }
			public string DCOD { get; set; }
			public string ORDN { get; set; }
			public string DBCD { get; set; }
			public DateTime ORDT { get; set; }
			public string PORD { get; set; }
			public string PCOD { get; set; }
			public string TXCD { get; set; }
			public string BRCD { get; set; }
			public string ICOD { get; set; }
			public string TRCD { get; set; }
			public decimal QNTY { get; set; }
			public decimal RATE { get; set; }
			public decimal ARAT { get; set; }
			public decimal OSRC { get; set; }
			public string PARTY { get; set; }
			public string AGENT { get; set; }
			public string ITEM { get; set; }
			public string GRADE { get; set; }
            public string DCODE { get; set; }
			public string ADDR { get; set; }
		}

		public class ORDMAN
		{
			public string COMP { get; set; }
			public string UNIT { get; set; }
			public string DCOD { get; set; }
			public string ORDN { get; set; }
			public string DBCD { get; set; }
			public DateTime ORDT { get; set; }
			public string PORD { get; set; }
			public string PCOD { get; set; }
			public string TXCD { get; set; }
			public string BRCD { get; set; }
			public string ICOD { get; set; }
			public string TRCD { get; set; }
			public decimal QNTY { get; set; }
			public decimal RATE { get; set; }
			public decimal ARAT { get; set; }
			public decimal OSRC { get; set; }
            public string PARTY { get; set; }
			public string AGENT { get; set; }
            public string ITEM { get; set; }
			public string GRADE { get; set; }
			
			public string DCODE { get; set; }
			public string ADDR { get; set; }

			internal void Add(ORDMAN ord)
			{
				throw new NotImplementedException();
			}
		}
		
		public class ORDDBCD
		{
			public string DBCD { get; set; }
			public string ORDN { get; set; }
		}

		[WebMethod]
		public static void Insert(int QNTY, int RATE, int ARAT, int OSRC, string ICOD, string TRCD, string UNIT, string DVCD, string DBCD, string ORDN, string PCOD, string TXCD, string BRCD, string PORD, string COMP, string ORDT)
		{
			string sDate = "";
			sDate = DateTime.ParseExact(ORDT, "dd/MM/yyyy", null).ToString("MM/dd/yyyy");

			string connectionString = ConfigurationManager.ConnectionStrings["CN"].ConnectionString;
			using (SqlConnection sqlConnection = new SqlConnection(connectionString))
			{
				SqlCommand cmd = new SqlCommand();
			    cmd.CommandText = "INSERT INTO ORDMAN (COMP,UNIT,DCOD,DBCD,ORDN,ORDT,PORD,PCOD,TXCD,BRCD,ICOD,TRCD,QNTY,RATE,ARAT,OSRC,RTCD) VALUES ('0001', '"+ UNIT +"', '" + DVCD + "', '" + DBCD + "', '" + ORDN + "', '"+ sDate + "', '" + PORD + "', '" + PCOD + "', '" + TXCD + "', '" + BRCD + "', '" + ICOD + "', '" + TRCD + "', " + QNTY + "," + RATE + ", " + ARAT + ", '" + OSRC + "','0')";
		        cmd.Connection = sqlConnection;
				sqlConnection.Open();
				cmd.ExecuteNonQuery();
                sqlConnection.Close();

				

			}
		}

		[WebMethod]
		public static string DeleteOrder(string UNIT, string DBCD, string ORDN)
		{
            string connectionString = ConfigurationManager.ConnectionStrings["CN"].ConnectionString;
			using (SqlConnection sqlConnection = new SqlConnection(connectionString))
			{
				SqlCommand delcmd = new SqlCommand();
				delcmd.CommandText = "DELETE FROM ORDMAN WHERE COMP ='0001' AND UNIT ='" + UNIT + "' AND ORDN ='" + ORDN + "' AND DBCD ='" + DBCD + "' ";
				delcmd.Connection = sqlConnection;
		        sqlConnection.Open();
				delcmd.ExecuteNonQuery();
		        sqlConnection.Close();

				return "First data will delete then after save";
            }
		}


		[WebMethod]
		public static string UpdateOrder(string DBCD, string ORDN)
		{
			string connectionString = ConfigurationManager.ConnectionStrings["CN"].ConnectionString;
			using (SqlConnection sqlConnection = new SqlConnection(connectionString))
			{
				SqlCommand updcmd = new SqlCommand();
				updcmd.CommandText = "UPDATE SALMANMST SET LSRNO ='" + ORDN  + "' WHERE CODE ='" + DBCD + "' ";
				updcmd.Connection = sqlConnection;
				sqlConnection.Open();
				updcmd.ExecuteNonQuery();
				sqlConnection.Close();

				return "";
			}
		}

		public static string Constr = ConfigurationManager.ConnectionStrings["CN"].ConnectionString;
		private static readonly object ordern;

		[WebMethod]
		public static string SaveData(string ordman)//WebMethod to Save the data  
		{
			var serializeData = JsonConvert.DeserializeObject<List<ORDMAN>>(ordman);
			using (var con = new SqlConnection(Constr))
			{
				foreach (var data in serializeData)
				{
					using (var cmd = new SqlCommand("INSERT INTO ORDMAN(COMP,UNIT,DCOD,DBCD,ORDN,ORDT,PORD,PCOD,TXCD,BRCD,ICOD,TRCD,QNTY,RATE,ARAT,OSRC) VALUES(@COMP,@UNIT,@DCOD,@DBCD,@ORDN,@ORDT,@PORD,@PCOD,@TXCD,@BRCD,@ICOD,@TRCD,@QNTY,@RATE,@ARAT,@OSRC)"))
					{
						cmd.CommandType = CommandType.Text;

						cmd.Parameters.AddWithValue("@COMP", data.COMP);
						cmd.Parameters.AddWithValue("@UNIT", data.UNIT);
						cmd.Parameters.AddWithValue("@DCOD", data.DCOD);
						cmd.Parameters.AddWithValue("@DBCD", data.DBCD);
						cmd.Parameters.AddWithValue("@ORDN", data.ORDN);
						cmd.Parameters.AddWithValue("@ORDT", DateTime.Now);
						cmd.Parameters.AddWithValue("@PORD", data.PORD);
						cmd.Parameters.AddWithValue("@PCOD", data.PCOD);
						cmd.Parameters.AddWithValue("@TXCD", data.TXCD);
						cmd.Parameters.AddWithValue("@BRCD", data.BRCD);
						cmd.Parameters.AddWithValue("@ICOD", data.ICOD);
						cmd.Parameters.AddWithValue("@TRCD", data.TRCD);
						cmd.Parameters.AddWithValue("@QNTY", data.QNTY);
						cmd.Parameters.AddWithValue("@RATE", data.RATE);
						cmd.Parameters.AddWithValue("@ARAT", data.ARAT);
						cmd.Parameters.AddWithValue("@OSRC", data.OSRC);


						cmd.Connection = con;
						cmd.Connection = con;
						if (con.State == ConnectionState.Closed)
						{
							con.Open();
						}
						cmd.ExecuteNonQuery();
						con.Close();



					}
				}


			}
			return null;
		}

		[WebMethod]
		public static void genordnew(string DBCD)
		{

			string PRFX;
			int code;
			string maxordn;
			
				string CS = ConfigurationManager.ConnectionStrings["CN"].ConnectionString;
				List<ORDDBCD> ordern = new List<ORDDBCD>();
				using (SqlConnection CON = new SqlConnection(CS))
				{

					SqlCommand cmd = new SqlCommand();
					cmd.CommandText = "SELECT PRFX, SUBSTRING(LSRNO,2,5) AS SRNO,PRFX FROM SALMANMST WHERE CODE = '" + DBCD + "' GROUP BY PRFX,LSRNO  ";
					cmd.Connection = CON;
					CON.Open();

					DataTable dt = new DataTable();
					SqlDataAdapter da = new SqlDataAdapter(cmd);
					da.Fill(dt);

					ORDDBCD lstord = new ORDDBCD();
					if (dt.Rows.Count > 0)
					{


						PRFX = dt.Rows[0]["PRFX"].ToString();
						code = Convert.ToInt32(dt.Rows[0]["SRNO"]);

						code++;
						string gencode = "";
						if (code.ToString().Length == 1)
						{
							gencode = "0000" + code.ToString();
						}
						else if (code.ToString().Length == 2)
						{
							gencode = "000" + code.ToString();
						}
						else if (code.ToString().Length == 3)
						{
							gencode = "00" + code.ToString();
						}
						else if (code.ToString().Length == 4)
						{
							gencode = "0" + code.ToString();
						}
						else
						{
							gencode = code.ToString();

							ordern.Add(lstord);
							maxordn = PRFX + gencode + "2021";
						}

					}
			
                  }
				//return maxordn;
         }


		[WebService(Namespace = "http://edittestorder.org/")]
		[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
		[System.ComponentModel.ToolboxItem(false)]
		[System.Web.Script.Services.ScriptService]
		public class SaleOrderPDMS : System.Web.Services.WebService
		{
			[WebMethod]
			public void GetOrderData()
			{
				string cs = ConfigurationManager.ConnectionStrings["CN"].ConnectionString;
				List<ORDMAN> order = new List<ORDMAN>();
				using (SqlConnection con = new SqlConnection(cs))
				{
					
					SqlCommand cmd = new SqlCommand("SELECT ORDMAN.COMP,ORDMAN.UNIT,ORDMAN.DCOD,ORDMAN.DBCD,ORDMAN.BRCD,ORDMAN.PCOD,ORDMAN.TXCD,ORDMAN.DCODE,ORDMAN.ADDR,ORDT,ORDN,MAX(ORDMAN.PORD) AS PORD,ISNULL(SUM(ORDMAN.QNTY),0) AS QNTY,MAX(FINITMMST.NAME) AS ITEM,MAX(ACCMST.NAME) AS PARTY,MAX(TAXMST.NAME) AS TAXNAME ,MAX(REFMST.NAME) AS AGENT FROM ORDMAN LEFT JOIN FINITMMST ON ORDMAN.COMP = FINITMMST.COMP AND ORDMAN.UNIT = FINITMMST.UNIT AND ORDMAN.DCOD = FINITMMST.DVCD AND ORDMAN.ICOD = FINITMMST.CODE LEFT JOIN ACCMST ON ORDMAN.PCOD = ACCMST.CODE LEFT JOIN REFMST ON ORDMAN.BRCD = REFMST.CODE LEFT JOIN TAXMST ON ORDMAN.TXCD = TAXMST.CODE WHERE ORDMAN.COMP = '0001' GROUP BY ORDMAN.COMP, ORDMAN.UNIT, ORDMAN.DCOD, ORDT, ORDN,ORDMAN.DBCD,ORDMAN.BRCD,ORDMAN.PCOD,ORDMAN.TXCD,ORDMAN.DCODE,ORDMAN.ADDR", con);
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



						order.Add(ord);
					}
				}
				JavaScriptSerializer js = new JavaScriptSerializer();
				Context.Response.Write(js.Serialize(order));
			}
		}


		[WebMethod]
		public void GetordInfo(string ORDN, string UNIT)

		{
			string cs = ConfigurationManager.ConnectionStrings["CN"].ConnectionString;
			List<ORDMAN> ordernoo = new List<ORDMAN>();
			using (SqlConnection con = new SqlConnection(cs))
			{

				SqlCommand cmd = new SqlCommand("SELECT ORDMAN.COMP,ORDMAN.UNIT,ORDMAN.DCOD,ORDT,ORDN,TRCD,QNTY,ICOD,RATE,ARAT,FINITMMST.NAME AS ITEM,GRDMST.GRAD AS GRADE FROM ORDMAN LEFT JOIN FINITMMST ON ORDMAN.COMP = FINITMMST.COMP AND ORDMAN.UNIT = FINITMMST.UNIT AND ORDMAN.DCOD = FINITMMST.DVCD AND ORDMAN.ICOD = FINITMMST.CODE LEFT JOIN GRDMST ON ORDMAN.TRCD = GRDMST.CODE  WHERE ORDMAN.COMP = '0001' AND ORDMAN.UNIT='" + UNIT + "' AND ORDMAN.ORDN ='" + ORDN + "' ", con);

				cmd.CommandType = CommandType.Text;

				con.Open();
				SqlDataReader rdr = cmd.ExecuteReader();
				while (rdr.Read())
				{
					ORDMAN ordnn = new ORDMAN();
					ordnn.ORDT = Convert.ToDateTime(rdr["ORDT"]);
					ordnn.ORDN = rdr["ORDN"].ToString();
					ordnn.ITEM = rdr["ITEM"].ToString();
					ordnn.ICOD = rdr["ICOD"].ToString();
					ordnn.TRCD = rdr["TRCD"].ToString();
					ordnn.QNTY = Convert.ToInt32(rdr["QNTY"]);
					ordnn.GRADE = rdr["GRADE"].ToString();
					ordnn.RATE = Convert.ToInt32(rdr["RATE"]);
					ordnn.ARAT = Convert.ToInt32(rdr["ARAT"]);


					ordernoo.Add(ordnn);
				}

			}

			JavaScriptSerializer js = new JavaScriptSerializer();
			Context.Response.Write(js.Serialize(ordernoo));
		}


		public class division
		{
			public string id_;
			public string name_;

		}

		[WebMethod]
		public List<division> bindChild_ddl(List<string> aData)

		{
			string cs = ConfigurationManager.ConnectionStrings["CN"].ConnectionString;
			using (SqlConnection con = new SqlConnection(cs))
			{
				List<division> u = new List<division>();
				string getID = aData[0];
				SqlDataReader dr;
				SqlCommand cmd = new SqlCommand("select CODE,NAME from FINITMMST where COMP ='0001' AND UNIT ='000001' AND  DVCD=@DIVID", con);
				cmd.CommandType = CommandType.Text;
				cmd.Parameters.AddWithValue("@DIVID", getID);
				con.Open();
				dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
				if (dr.HasRows)
				{
					while (dr.Read())
					{
						u.Add(new division
						{
							id_ = dr["CODE"].ToString(),
							name_ = dr["NAME"].ToString(),
						});

					}
					dr.Close();
				}
				return u;
			}
			

	    }

	}
}

	