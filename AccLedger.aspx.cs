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
    public partial class Accledger : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fillParty();
            }
          //  CalculateTrn();
        }


        private void fillParty()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["CN"].ConnectionString;
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = "SELECT * FROM ACCMST  ";


                sqlCommand.Connection = sqlConnection;
                sqlConnection.Open();
                DDPCOD.DataSource = sqlCommand.ExecuteReader();
                DDPCOD.DataTextField = "NAME";
                DDPCOD.DataValueField = "CODE";
                DDPCOD.DataBind();
            }
        }

        private void CalculateTrn()

        {

            string connectionString = ConfigurationManager.ConnectionStrings["CN"].ConnectionString;
            string sDate = "";
            sDate = DateTime.ParseExact(DTFROM.Text, "dd/MM/yyyy", null).ToString("MM/dd/yyyy");
            string tDate = "";
            tDate = DateTime.ParseExact(DTTO.Text, "dd/MM/yyyy", null).ToString("MM/dd/yyyy");


            string sql = "SELECT TRNMAN.VTYP,TRNMAN.DATE,TRNMAN.VBNO,TRNMAN.RCOD,TRNMAN.DAMT,TRNMAN.CAMT,(TRNMAN.DAMT-TRNMAN.CAMT) AS BALAMT,ISNULL(TRNMAN.CDNO, '') AS CDNO, TRNMAN.COMP,TRNMAN.SRNO,TRNMAN.UNIT,ISNULL(ACCMST.NAME, 'Multiple Entries') AS NAME, TRNMAN.NARR FROM TRNMAN LEFT JOIN ACCMST ON ACCMST.CODE = TRNMAN.RCOD WHERE TRNMAN.DATE >= '" + sDate  + "' AND TRNMAN.DATE <= '" + tDate + "' AND  trnman.Acod = '" + DDPCOD.SelectedValue + "' AND RECSTAT<>'D' AND COMP = '0001' AND TRNMAN.UNIT ='000001' AND TRNMAN.VTYP <> 'BNK' ORDER BY DATE,trnman.vbno";
            //string sql = "SELECT TRNMAN.VTYP,TRNMAN.DATE,TRNMAN.VBNO,TRNMAN.RCOD,TRNMAN.DAMT,TRNMAN.CAMT,(TRNMAN.DAMT-TRNMAN.CAMT) AS BALAMT,ISNULL(TRNMAN.CDNO, '') AS CDNO, TRNMAN.COMP,TRNMAN.SRNO,TRNMAN.UNIT,ISNULL(ACCMST.NAME, 'Multiple Entries') AS NAME, TRNMAN.NARR FROM TRNMAN LEFT JOIN ACCMST ON ACCMST.CODE = TRNMAN.RCOD WHERE TRNMAN.DATE >= '04/01/2019' AND TRNMAN.DATE <= '04/30/2019' AND  RECSTAT<>'D' AND COMP = '0001' AND TRNMAN.UNIT ='000001' AND TRNMAN.VTYP <> 'BNK' ORDER BY DATE,trnman.vbno";

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {

                using (SqlCommand cmd = new SqlCommand(sql))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = sqlConnection;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            // AcGrid.DataSource = dt;
                            //AcGrid.DataBind();

                            //////Calculate Sum and display in Footer Row
                            ////decimal total = dt.AsEnumerable().Sum(row => row.Field<decimal>("BALAMT"));
                            ////AcGrid.FooterRow.Cells[4].Text = "Total";
                            ////AcGrid.FooterRow.Cells[5].HorizontalAlign = HorizontalAlign.Right;
                            ////AcGrid.FooterRow.Cells[6].Text = total.ToString("N2");
                            //  AcGrid.DataBind();

                            ////int total = 0; ;
                            ////AcGrid.FooterRow.Cells[0].Text = "Total";
                            ////AcGrid.FooterRow.Cells[1].Font.Bold = true;
                            ////AcGrid.FooterRow.Cells[1].HorizontalAlign = HorizontalAlign.Left;
                            ////for (int k = 1; k < dt.Columns.Count - 1; k++)
                            ////{
                            ////    total = dt.AsEnumerable().Sum(row => row.Field<Int32>(dt.Columns[k].ToString()));
                            ////    AcGrid.FooterRow.Cells[k].Text = total.ToString();
                            ////    AcGrid.FooterRow.Cells[k].Font.Bold = true;
                            ////    AcGrid.FooterRow.BackColor = System.Drawing.Color.Beige;
                            ////}
                           
                         
                            decimal camt = 0;
                            decimal damt = 0;
                            decimal balamt = 0;
                            decimal opnamt = 0;

                            for (int i = 0; i <= dt.Rows.Count - 1; i++)
                            {
                                camt += dt.Rows[i].Field<Decimal>(5);
                                damt += dt.Rows[i].Field<Decimal>(4);
                                balamt += dt.Rows[i].Field<Decimal>(6);

                            }
                            string textboxValue = TXTOPN.Text;

                            if (decimal.TryParse(TXTOPN.Text, out opnamt))
                            {
                                opnamt = Convert.ToDecimal(TXTOPN.Text);
                            }
                            else
                            {
                                //something went wrong with the conversion - i.e. not in a recognisable format so
                                //display some kind of error message
                            }

                            decimal tempbal = 0;
                            tempbal = balamt + opnamt;
                           // tempbal = balamt ;
                            // BIND QUERY RESULT WITH THE GRIDVIEW.

                            AcGrid.DataSource = dt;
                            AcGrid.DataBind();
                            if (dt.Rows.Count > 0)
                            {
                                AcGrid.FooterRow.Cells[5].Text = camt.ToString();
                                AcGrid.FooterRow.Cells[4].Text = damt.ToString();
                                AcGrid.FooterRow.Cells[6].Text = tempbal.ToString();

                                AcGrid.FooterRow.Cells[0].Text = "Total";
                                AcGrid.FooterRow.Cells[0].Font.Bold = true;
                                AcGrid.FooterRow.Cells[4].Font.Bold = true;
                                AcGrid.FooterRow.Cells[5].Font.Bold = true;
                                AcGrid.FooterRow.Cells[6].Font.Bold = true;
                                AcGrid.FooterRow.Cells[0].HorizontalAlign = HorizontalAlign.Left;
                                AcGrid.FooterRow.BackColor = System.Drawing.Color.Beige;
                            }
                        }
                    }
                }

            }
        }


        private void FINDOPN()
        {
           
            string connectionString = ConfigurationManager.ConnectionStrings["CN"].ConnectionString;
            string sDate = "";
            sDate = DateTime.ParseExact(DTFROM.Text, "dd/MM/yyyy", null).ToString("MM/dd/yyyy");
            string SQL = "SELECT  (SUM(TRNMAN.DAMT)-SUM(TRNMAN.CAMT)) AS BALAMT FROM TRNMAN  LEFT JOIN ACCMST ON ACCMST.CODE=TRNMAN.RCOD  WHERE  trnman.Acod='" + DDPCOD.SelectedValue + "' AND  RECSTAT<>'D' AND   TRNMAN.VTYP <>'BNK' AND ((TRNMAN.DAMT)+(TRNMAN.CAMT))<>0  AND TRNMAN.DATE < '" + sDate + "' ORDER BY TRNMAN.DATE";
         //   TXTOPN.Text = "8888";


            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
               

                using (SqlCommand cmd = new SqlCommand(SQL))
                {
                  
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                       

                        cmd.Connection = sqlConnection;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                          
                            sda.Fill(dt);

                            if (dt.Rows.Count > 0)
                            {
                              
                                TXTOPN.Text = dt.Rows[0]["BALAMT"].ToString();
                              
                            }
                        }
                    }
                }

            }
        }



        private void UpdateBalance()
        {
          //  double debit;
          //  double balance;
         //   double credit;
         //   int counter;


            // Iterate through the rows, skipping the Starting Balance row.
            for (counter = 1; counter < (AcGrid.Rows.Count - 1); counter++)
            {
                ////debit = 0;
                ////credit = 0;
                ////balance = Convert.ToDouble(AcGrid.Rows[counter].Cells[6].ToString());

                ////credit = Convert.ToDouble(AcGrid.Rows[counter].Cells[5].ToString());
                ////debit = Convert.ToDouble(AcGrid.Rows[counter].Cells[4].ToString());

                ////AcGrid.Rows[counter].Cells[6].Text = (balance + debit -credit).ToString("#00000000.00"); 
                
               
            }

         //   TXTOPN.Text = "6666";
        }

        protected void DDPCOD_TextChanged(object sender, EventArgs e)
        {
            ///FINDOPN();
            ////CalculateTrn();
            ////UpdateBalance();
        }


        protected void AcGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            decimal Total =0 ;
            if (e.Row.RowType == DataControlRowType.DataRow)

                Total += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "BALAMT"));
            else if (e.Row.RowType == DataControlRowType.Footer)

                e.Row.Cells[6].Text = String.Format("{0:0}", "<b>" + Total + "</b>");

        }

        protected void DTFROM_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (DTFROM.Text != "" &&  DTTO.Text !="" ) {
                FINDOPN();
                CalculateTrn();
                UpdateBalance();
            }

        }
    }
    }
