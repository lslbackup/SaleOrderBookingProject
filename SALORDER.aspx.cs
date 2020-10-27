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
	public partial class SALORDER : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
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
				TXTPCOD.DataValueField = "TXCD";

				TXTPCOD.DataBind();

			}

		}
		private void fillTax()
		{
			string connectionString = ConfigurationManager.ConnectionStrings["CN"].ConnectionString;
			using (SqlConnection sqlConnection = new SqlConnection(connectionString))
			{
				SqlCommand sqlCommand = new SqlCommand();
				sqlCommand.CommandText = "SELECT * FROM TAXMST WHERE CODE ='" + TXTPCOD.Value + "' ";
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



			internal void Add(ORDMAN ord)
			{
				throw new NotImplementedException();
			}
		}

		public string Getmstcode(string Tablename, string Value, string condition, string Result)
		{
			string retresult = "";

			string connectionString = ConfigurationManager.ConnectionStrings["CN"].ConnectionString;
			using (SqlConnection sqlConnection = new SqlConnection(connectionString))
			{
				SqlCommand cmd = new SqlCommand();
				cmd.CommandText = "Select " + Result + " From " + Tablename + " Where " + condition + "='" + Value + "'";
				cmd.Connection = sqlConnection;
				sqlConnection.Open();

				SqlDataReader rdr = cmd.ExecuteReader();

				if (rdr.Read())
				{

					retresult = rdr["CODE"].ToString();
				}
				return retresult;
			}
		}

		public static string Constr = ConfigurationManager.ConnectionStrings["CN"].ConnectionString;
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
					//string sql = "";
					//sql = " SELECT ORDMAN.*,CONVERT(VARCHAR,ORDMAN.ORDT ,103) AS DATE,ACCMST.NAME AS ACNM,PADDMST.NAME AS CONPTY,PADDMST.ADDR AS CONADD,REFMST.NAME AS AGNM,FINITMMST.NAME AS ITNM,TAXMST.NAME AS STAX,SUBDEALER.NAME AS SUBDEALER FROM ORDMAN  LEFT JOIN REFMST ON REFMST.CODE=ORDMAN.BRCD AND REFMST.CATA='B' INNER JOIN ACCMST ON ACCMST.CODE=ORDMAN.PCOD LEFT JOIN PADDMST ON PADDMST.CODE=ORDMAN.DCODE AND PADDMST.SRNO=ORDMAN.ADDR LEFT JOIN TAXMST ON TAXMST.CODE=ORDMAN.TXCD INNER JOIN FINITMMST ON FINITMMST.COMP=ORDMAN.COMP AND FINITMMST.UNIT=ORDMAN.UNIT AND FINITMMST.DVCD=ORDMAN.DCOD AND FINITMMST.CODE=ORDMAN.ICOD LEFT JOIN REFMST SUBDEALER ON SUBDEALER.CODE=ORDMAN.TBRCD AND SUBDEALER.CATA='B' WHERE ORDMAN.FIN_APRV='N' AND ORDMAN.VP_APRV='N' ";
					SqlCommand cmd = new SqlCommand("SELECT DISTINCT COMP,UNIT,DCOD,DBCD,ORDT,ORDN,PCOD,TXCD,BRCD,QNTY FROM ORDMAN WHERE COMP ='0001' AND UNIT ='000001'", con);
					cmd.CommandType = CommandType.Text;

					con.Open();
					SqlDataReader rdr = cmd.ExecuteReader();
					while (rdr.Read())
					{
						ORDMAN ord = new ORDMAN();
						ord.ORDT = Convert.ToDateTime(rdr["ORDT"]);
						ord.ORDN = rdr["ORDN"].ToString();
						ord.PCOD = rdr["PCOD"].ToString();
						ord.TXCD = rdr["TXCD"].ToString();
						ord.BRCD = rdr["BRCD"].ToString();

						//ord.QNTY = Convert.ToInt32(rdr["QNTY"]);

						order.Add(ord);
					}
				}
				JavaScriptSerializer js = new JavaScriptSerializer();
				Context.Response.Write(js.Serialize(order));
			}
		}
	}


}