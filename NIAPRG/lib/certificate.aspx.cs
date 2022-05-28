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
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;


namespace NIAPRG.lib
{
    public partial class certificate : System.Web.UI.Page
    {
        SqlConnection cnn = new SqlConnection(ConfigurationManager.AppSettings["DSN"]);
        string uid, courseID, userID = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //uid = Convert.ToString(Session["uid"]);
                courseID = Request.QueryString["courseID"];
                userID = Request.QueryString["uid"];
                //if (userID != "")
                //{
                //    uid = userID;
                //}
                lblcourseid.Text = courseID;
                lbluserid.Text = userID;
               

                //try
                //{ 
                //string query1 = "select count(*) UserID from UserCourses c where CompleteDate is not null and c.userid=" + uid + " and c.CourseID =" + courseID + " and datediff(d,c.CreateDate,getdate()) >=5";
                //cnn.Open();
                //SqlCommand SQLCommand = new SqlCommand(query1, cnn);
                //SQLCommand.CommandType = CommandType.Text;
                //SqlDataReader dr = SQLCommand.ExecuteReader();
                //if (dr.HasRows == true)
                //{
                //    divdownload.Visible = true;
                //    divnotgen.Visible = false;
                //}
                //else
                //{
                //      lblmessage.Text = "No Data.";
                //        divdownload.Visible = false;
                //    divnotgen.Visible = true;
                //}
                //    //if (courseID == "15" || courseID == "18" || courseID == "19" || courseID == "17" || courseID == "24" || courseID == "5")
                //    //{
                //    // 
                //}
                //catch(Exception ex)
                //{
                //    lblmessage.Text = ex.ToString();
                //}
                try
                {
                     //SqlCommand cmd = new SqlCommand("select  UserID from UserCourses c where CompleteDate is not null and c.userid=" + userID + " and c.CourseID =" + courseID + " and datediff(d,c.CreateDate,getdate()) >=5", cnn);
                     SqlCommand cmd = new SqlCommand("select UserID from UserCourses c where CompleteDate is not null and c.userid=8395 and c.CourseID =44 and datediff(d,c.CreateDate,getdate()) >=5", cnn);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    cnn.Close();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        divdownload.Visible = true;
                        divnotgen.Visible = false;

                    }
                    else
                    {
                        divdownload.Visible = false;
                        divnotgen.Visible = true;
                    }
                }
                catch (Exception ex)
                {
                    lblmessage.Visible = true;
                    lblmessage.Text = ex.ToString();
                }

                //else if (courseID == "20")
                //{
                //    string query1 = "select * from ScormStatus where userid='" + uid + "' and CourseID='" + courseID + "' and SCOID='ITEM-BBC645A5-5A3D-B2DE-7170-AE40F4EFDF74' and isnull(scoreraw,0)>0";
                //    cnn.Open();
                //    SqlCommand SQLCommand = new SqlCommand(query1, cnn);
                //    SQLCommand.CommandType = CommandType.Text;
                //    SqlDataReader dr = SQLCommand.ExecuteReader();
                //    if (dr.HasRows == true)
                //    {
                //        divdownload.Visible = true;
                //        divnotgen.Visible = false;
                //    }
                //    else
                //    {
                //        divdownload.Visible = false;
                //        divnotgen.Visible = true;
                //    }
                //}
                //else
                //{
                //    divdownload.Visible = false;
                //    divnotgen.Visible = true;

                //}
            }
        }
        private void bindData()
        {
            //cnn.Open();
            //SqlCommand cmd = new SqlCommand("Select * from NiaApplicants where status = 3 order by id desc", cnn);
            //SqlDataAdapter da = new SqlDataAdapter(cmd);
            //DataSet ds = new DataSet();
            //da.Fill(ds);
            //cnn.Close();
            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    GdvExamUsers.DataSource = ds;
            //    GdvExamUsers.DataBind();
            //}
        }

        public void PDFConvert(string P1)
        {
            courseID = Request.QueryString["courseID"]; //Convert.ToString(Session["courseID"]);

            //courseID = "20";
            //courseID = "15";

            if (courseID != "20" && courseID!="47")
            {
                string imgpath = imglogo.ImageUrl;

                string filename = Path.GetFileName(imgpath);
                string file = P1 + ".pdf";


                string imgpath1 = userimg.ImageUrl;
                string filename1 = Path.GetFileName(imgpath1);






                if (File.Exists(Server.MapPath("~/lib/niaPhotos/" + filename1)))
                {
                    userimg.ImageUrl = Server.MapPath("~/lib/niaPhotos/" + filename1);
                    //userimg.Style.Add("height", "100px ");
                    //userimg.Style.Add("width", "100px ");
                    //userimg.Style.Add("margin-right", "500px; ");
                }
                else
                {
                    userimg.Visible = false;
                }
                //imglogo.Visible = true;

                //imglogo.Style.Add("opacity", "0.0");

                imglogo.ImageUrl = Server.MapPath("~/lib/nia_files/logo1.jpg");







                userimg.Visible = false;


                var UPath = Server.MapPath("~/lib/niaPhotos/" + filename1);
                iTextSharp.text.Image Uimg = iTextSharp.text.Image.GetInstance(UPath);
                Uimg.ScaleToFit(75f, 75f);









                string imageFilePath = Server.MapPath("~/lib/nia_files/NIAFrame.jpg");
                iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(imageFilePath);
                jpg.ScaleToFit(3000, 770);
                //If you want to choose image as background then,
                jpg.Alignment = iTextSharp.text.Image.UNDERLYING;
                //If you want to give absolute/specified fix position to image.
                jpg.SetAbsolutePosition(0, 0);
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", "attachment;filename=" + file);
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                StringWriter sw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                this.Page.RenderControl(hw);
                StringReader sr = new StringReader(sw.ToString());
                Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 100f, 0f);
                HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                pdfDoc.Open();
                pdfDoc.Add(jpg);
                //Logo.SetAbsolutePosition(100, pdfDoc.PageSize.Height - 200);
                //pdfDoc.Add(Logo);
                Uimg.SetAbsolutePosition(400, pdfDoc.PageSize.Height - 230);
                pdfDoc.Add(Uimg);
                htmlparser.Parse(sr);
                pdfDoc.Close();
                Response.Write(pdfDoc);
                Response.End();
            }
            else if(courseID == "20" || courseID == "47")
            {

                string imgpathren = imglogo.ImageUrl;
                string file = P1 + ".pdf";
                string imgpathren1 = userimg.ImageUrl;
                string filename2 = Path.GetFileName(imgpathren1);
                imglogo1.ImageUrl = Server.MapPath("~/lib/nia_files/logo1.jpg");
                if (File.Exists(Server.MapPath("~/lib/niaPhotos/" + filename2)))
                {
                    userimg1.ImageUrl = Server.MapPath("~/lib/niaPhotos/" + filename2);
                    //userimg.Style.Add("height", "100px ");
                    //userimg.Style.Add("width", "100px ");
                    //userimg.Style.Add("margin-right", "500px; ");
                }
                else
                {
                    userimg1.Visible = false;
                }




                userimg1.Visible = false;



                var UPath1 = Server.MapPath("~/lib/niaPhotos/" + filename2);
                iTextSharp.text.Image Uimg1 = iTextSharp.text.Image.GetInstance(UPath1);
                Uimg1.ScaleToFit(75f, 75f);








                string imageFilePath1 = Server.MapPath("~/lib/nia_files/NIAFrame_02.jpg");



                iTextSharp.text.Image jpg1 = iTextSharp.text.Image.GetInstance(imageFilePath1);
                jpg1.ScaleToFit(3000, 770);

                //If you want to choose image as background then,





                jpg1.Alignment = iTextSharp.text.Image.UNDERLYING;

                //If you want to give absolute/specified fix position to image.
                jpg1.SetAbsolutePosition(0, 0);





                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", "attachment;filename=" + file);
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                StringWriter sw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                this.Page.RenderControl(hw);
                StringReader sr = new StringReader(sw.ToString());
                Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 100f, 0f);
                HTMLWorker htmlparser1 = new HTMLWorker(pdfDoc);
                PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                pdfDoc.Open();
                pdfDoc.Add(jpg1);
                //Logo.SetAbsolutePosition(100, pdfDoc.PageSize.Height - 200);
                //pdfDoc.Add(Logo);
                Uimg1.SetAbsolutePosition(400, pdfDoc.PageSize.Height - 230);
                pdfDoc.Add(Uimg1);

                htmlparser1.Parse(sr);
                pdfDoc.Close();
                Response.Write(pdfDoc);
                Response.End();
            }
        }


        public override void VerifyRenderingInServerForm(Control control)
        {
        }

        protected void btnexport_Click(object sender, EventArgs e)
        {
            imglogo.ImageUrl = "~/lib/nia_files/Logo.jpg";
            imglogo1.ImageUrl = "~/lib/nia_files/Logo.jpg";
            // getting userID of login user

            string uid = Convert.ToString(Session["uid"]); //Request.QueryString["uid"];
            string courseID = Request.QueryString["courseID"]; //Convert.ToString(Session["courseID"]);
                                                               //uid = "1174";
                                                               //courseID = "20";
                                                               //uid = "1620";
                                                               //courseID = "15";
                                                               //uid = "2526";
                                                               //courseID = "20";

            //userID = Request.QueryString["userID"];
            //if (userID != "")
            //{
            //    uid = userID;
            //}
            string query1 = "select a.userid,a.username,LastName+FirstName as name,b.CourseID,convert(varchar, b.CompleteDate, 106) CompleteDate,convert(varchar, b.CompleteDate+364, 105) TrainingValidDate," +
            "convert(varchar, b.CompleteDate+1095, 105) RenewalTrainingValidDate,convert(varchar, b.CompleteDate+943, 105) RenewalpriorTrainingValidDate,convert(varchar, getdate(), 106) as today,convert(varchar, b.CreateDate, 106) CreateDate, c.title,d.photo,d.EligibleHours,d.RequiredHours " +
            " from users a, usercourses b, courses c, niaapplicants d " +
            "where a.userid=b.userid and b.courseid=c.courseid and d.panno=a.username and d.status=1 and b.status=2  " +
            " and a.UserID = '" + uid + "'" +
            " and b.CourseID = '" + courseID + "'";

            cnn.Open();
            SqlCommand SQLCommand = new SqlCommand(query1, cnn);
            SQLCommand.CommandType = CommandType.Text;
            SqlDataReader dr = SQLCommand.ExecuteReader();
            string nameOfCandidate = "", CourseHrs = "";
            string CourseID = "", pan = "", CompleteDate = "", TrainingValidDate = "", RenewalTrainingValidDate = "", RenewalpriorTrainingValidDate = "", today = "", userid = "", CreateDate = "", CourseTitle = "", photo = "";
            if (dr.Read())
            {
                nameOfCandidate = dr["name"].ToString();
                pan = dr["UserName"].ToString();
                CompleteDate = dr["CompleteDate"].ToString();
                today = dr["today"].ToString();
                CourseID = dr["CourseID"].ToString();
                CourseTitle = dr["title"].ToString();
                photo = dr["photo"].ToString();
                CreateDate = dr["CreateDate"].ToString();
                userid = dr["userid"].ToString();
                CourseHrs = dr["RequiredHours"].ToString();
                TrainingValidDate = dr["TrainingValidDate"].ToString();
                RenewalTrainingValidDate = dr["RenewalTrainingValidDate"].ToString();
                RenewalpriorTrainingValidDate = dr["RenewalpriorTrainingValidDate"].ToString();
            }
            lbname.Text = nameOfCandidate;
            lbname1.Text = nameOfCandidate;
            lbtodayDate.Text = today;
            lbdate.Text = CompleteDate;
            lbtodayDate1.Text = today;
            lbdate1.Text = CompleteDate;
            lbCourseHrs.Text = CourseHrs;
            lbCourseHrs1.Text = CourseHrs;
            lbCourseHrsCompleted.Text = CourseHrs;
            lbCourseHrsCompleted1.Text = CourseHrs;

            userimg.ImageUrl = "~/lib/niaPhotos/" + photo;
            userimg1.ImageUrl = "~/lib/niaPhotos/" + photo;
            userimg.Width = 75;
            userimg.Height = 75;
            userimg1.Width = 75;
            userimg1.Height = 75;


            lbtrgid.Text = userid;
            lbstartdt.Text = CreateDate;
            lbcompleted.Text = CompleteDate;
            lbcourse.Text = CourseTitle;
            lbtrgid1.Text = userid;
            lbstartdt1.Text = CreateDate;
            //  lbcompleted1.Text = CompleteDate;
            lbcourse1.Text = CourseTitle;
            lbltrainingvaliddate.Text = TrainingValidDate;
            lblnotedate.Text = TrainingValidDate;

            lblrenewaltrainingvaliddate.Text = RenewalTrainingValidDate;
            lblrenewaltrainingvaliddate2.Text = RenewalTrainingValidDate;
            lblrenewaltrainingvalidpriordate.Text = RenewalpriorTrainingValidDate;
            lblrenewaltrainingvaliddate3.Text = RenewalTrainingValidDate;

            divdownload.Visible = false;
            if (courseID == "20" || courseID=="47")
            {

                ctf.Visible = false;
                ctf2.Visible = true;

            }
            else if(courseID != "20" || courseID != "47")
            {
                ctf.Visible = true;
                ctf2.Visible = false;
            }


            PDFConvert(pan);

            cnn.Close();

        }

        ///
    }
}