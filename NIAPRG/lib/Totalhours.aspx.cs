using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace NIAPRG.lib
{
    public partial class Totalhours : System.Web.UI.Page
    {
        SqlConnection cnn = new SqlConnection(ConfigurationManager.AppSettings["DSN"]);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int uid = Convert.ToInt32(Session["uid"]);
                string courseID = Request.QueryString["courseID"]; 
                //Convert.ToString(Session["courseID"]);
                BindData(1, uid);
            }

        }

        private void BindData(int parameter1, int parameter2)
        {
            DataTable dt = new DataTable();
            DataTable dtTemp = new DataTable();
            string courseTitle = "";
            DateTime? lastAccessDate = null;
            DateTime? completeDate = null;
            string elapsedTime = "";



            dtTemp.Columns.Add("CourseTitle");
            dtTemp.Columns.Add("LastAccessDate");
            dtTemp.Columns.Add("CompleteDate");
            dtTemp.Columns.Add("ElapsedTime");
            using (SqlCommand cmd = new SqlCommand("SP_GetRecordsTest", cnn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@parameter1", parameter1);
                cmd.Parameters.AddWithValue("@parameter2", parameter2);
                cnn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr);
                cnn.Close();
            }

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int hours = 0;
                    int minutes = 0;
                    int seconds = 0;
                    int totalSeconds = 0;
                    int quotient = 0;
                    int remainder = 0;

                    courseTitle = Convert.ToString(dt.Rows[i]["CourseTitle"]);
                    if (dt.Rows[i]["LastAccessDate"] != DBNull.Value && Convert.ToString(dt.Rows[i]["LastAccessDate"]) != string.Empty)
                    {
                        lastAccessDate = Convert.ToDateTime(dt.Rows[i]["LastAccessDate"]);
                    }
                    if (dt.Rows[i]["CompleteDate"] != DBNull.Value && Convert.ToString(dt.Rows[i]["CompleteDate"]) != string.Empty)
                    {
                        completeDate = Convert.ToDateTime(dt.Rows[i]["CompleteDate"]);
                    }
                    if (dt.Rows[i]["TotalHours"] != DBNull.Value && Convert.ToString(dt.Rows[i]["TotalHours"]) != string.Empty)
                    {
                        hours = Convert.ToInt32(dt.Rows[i]["TotalHours"]);
                    }
                    if (dt.Rows[i]["TotalMinutes"] != DBNull.Value && Convert.ToString(dt.Rows[i]["TotalMinutes"]) != string.Empty)
                    {
                        minutes = Convert.ToInt32(dt.Rows[i]["TotalMinutes"]);
                    }
                    if (dt.Rows[i]["TotalSeconds"] != DBNull.Value && Convert.ToString(dt.Rows[i]["TotalSeconds"]) != string.Empty)
                    {
                        seconds = Convert.ToInt32(dt.Rows[i]["TotalSeconds"]);
                    }

                    totalSeconds = seconds + (minutes * 60) + (hours * 60 * 60);
                    quotient = (totalSeconds) / 3600;
                    remainder = (totalSeconds) % 3600;

                    hours = quotient; // hours

                    quotient = (remainder) / 60;
                    minutes = quotient; // mintues

                    remainder = (remainder) % 60;
                    seconds = remainder; // seconds

                    elapsedTime = hours + ":" + minutes + ":" + seconds;
                    dtTemp.Rows.Add(courseTitle, lastAccessDate, completeDate, elapsedTime);
                }
                string tblid = "";
                int y = 0;
                foreach (DataRow x in dtTemp.Rows)

                {

                    Table tbl = new Table();
                    y++;
                    tbl.ID = "tblid" + y.ToString(); // this is for Dyanamic table id generate
                    tbl.ID = tblid.ToString(); // this is also for Dyanamic table id generate
                    tbl.BorderWidth = 2;
                    //tbl.BorderStyle= BorderStyle.Solid;
                    tbl.Height = 126;
                    tbl.Width = 700;
                    tbl.CssClass = "table table-striped table-c"; // table and table-stripped bootstrap classes and table-c our custom class
                    //tbl. = 1.;
                    //tbl.CellPadding = 3;
                    //tbl.CellSpacing = 3;
                    // tbl. = "red";

                    TableRow tRow = new TableRow();
                    tRow.Height = 10;

                    TableCell tCell = new TableCell();
                    tCell.Text = "Course Title";
                    tCell.Width = 200; // by default it will take Pixles. 200 means 200 pixles
                    tCell.Attributes.Add("style", "background-color:cornflowerblue;");
                    tRow.Cells.Add(tCell); // here we are adding cell 1 to TableRow



                    TableCell tCell2 = new TableCell();
                    tCell2.Text = x["CourseTitle"].ToString();
                    tRow.Cells.Add(tCell2); // here we are adding cell 2 to TableRow

                    tbl.Rows.Add(tRow); // here we are adding 2 tells two Table here row 1

                    TableRow tRow2 = new TableRow();
                    tRow2.Height = 10;
                    TableCell tCell3 = new TableCell();
                    tCell3.Text = "Last Access Date";
                    tCell3.Width = 200;
                    tCell3.Attributes.Add("style", "background-color:cornflowerblue;");
                    tRow2.Cells.Add(tCell3);

                    TableCell tCell4 = new TableCell();
                    tCell4.Text = x["LastAccessDate"].ToString();
                    tRow2.Cells.Add(tCell4);


                    tbl.Rows.Add(tRow2); //here row 2


                    //TableRow tRow3 = new TableRow();
                    //tRow3.Height = 10;
                    //TableCell tCell5 = new TableCell();
                    //tCell5.Text = "Total Time(HH:MM:SS)";
                    //tCell5.Width = 200;
                    //tCell5.Attributes.Add("style", "background-color:cornflowerblue;");
                    //tRow3.Cells.Add(tCell5);


                    //TableCell tCell6 = new TableCell();
                    //tCell6.Text = x["ElapsedTime"].ToString();
                    //tRow3.Cells.Add(tCell6);

                    //tbl.Rows.Add(tRow3); //here row 3


                    PlaceHolder1.Controls.Add(tbl); // finally we are adding into place holder for good formatting..we can add form also but design not good
                    //form1.Controls.Add(tbl);
                    //GvRpt.DataSource = dtTemp;
                    //GvRpt.DataBind();
                }
            }
            else
            {
                GvRpt.DataSource = null;
                GvRpt.DataBind();
            }

            //SqlCommand cmd = new SqlCommand("SP_GetRecordsTest", cnn);
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@parameter1", parameter1);
            //cmd.Parameters.AddWithValue("@parameter2", parameter2);
            //SqlDataAdapter da = new SqlDataAdapter(cmd);
            //DataSet ds = new DataSet();
            //da.Fill(ds);
            //cnn.Close();

            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    GvRpt.DataSource = ds.Tables[0];
            //    GvRpt.DataBind();

            //}

        }
    }
}