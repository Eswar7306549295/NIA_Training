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
//using ClosedXML.Excel;


namespace NIAPRG
{
    public partial class UserExternalCoursesReport : System.Web.UI.Page
    {

        SqlConnection cnn = new SqlConnection(ConfigurationManager.AppSettings["DSN"]);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindEventType();
                BindData("", "3");
            }
        }

        public void BindEventType()
        {

            using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["DSN"]))
            {
                using (SqlCommand cmd = new SqlCommand("select * from ExternalEventTypes"))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    con.Open();
                    ddltype.DataSource = cmd.ExecuteReader();
                    ddltype.DataTextField = "Title";
                    ddltype.DataValueField = "ExternalEventTypeID";
                    ddltype.DataBind();
                    con.Close();
                }
            }
           // ddltype.Items.Insert(0, new ListItem("Please choose anyone", "0"));
            //ddlcompanylist.Items.Insert(+1, new ListItem("Not Applicable", "999"));

        }
        private void BindData(string pageindex, string pagesize)
        {

            lblphotos.Visible = false;
            //string type = ddltype.SelectedValue.ToString();
            cnn.Open();
            SqlCommand cmd = new SqlCommand("ril_GetExternalCourses", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CourseType", ddltype.SelectedItem.Value);


            cmd.Parameters.AddWithValue("@StartDate", txtstart.Text.Trim());
            cmd.Parameters.AddWithValue("@EndDate", txtto.Text.Trim());

            cmd.Parameters.AddWithValue("@EmpID", txtSearch.Text.Trim());

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            cnn.Close();
            Session["Details"] = ds;
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvpager.Visible = true;
                //gvpager1.Visible = true;
                GvRpt.DataSource = ds.Tables[0];
                GvRpt.DataBind();
                btnExport.Visible = true;
                //exportphotos.Visible = true;
                exportpdf.Visible = false;

                // ViewState["totcnt"] = ds.Tables[0].Rows[0]["totcnt"];
                // BindPageCnt();
            }
            else
            {
                ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                GvRpt.DataSource = ds.Tables[0];
                GvRpt.DataBind();
                GvRpt.Rows[0].Visible = false;
                //exportphotos.Visible = false;
                exportpdf.Visible = false;
                //   gvpager.Visible = false;
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMSG",
                                                    "alertify.alert('No Records Found');",
                                                    true);
                //RptMdlExt.Hide();

            }

        }

        protected void btngetdetails_Click(object sender, EventArgs e)
        {
            BindData("", "10");
        }

        protected void GvRpt_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvRpt.PageIndex = e.NewPageIndex;
            BindData("", "3");
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {

            DataSet ds = (DataSet)Session["Details"];
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataTableExportToExcel(ds.Tables[0], " Report", "");
            }

        }

        public void DataTableExportToExcel(DataTable dt, string filename, string header)
        {
            try
            {
                var ds = (DataSet)Session["Details"];
                ds.Tables[0].TableName = "Report";


                if (dt.Rows.Count <= 0) return;
                var tw = new StringWriter();
                var hw = new HtmlTextWriter(tw);
                var dgGrid = new DataGrid { DataSource = dt };
                dgGrid.DataBind();
                dgGrid.HeaderStyle.Font.Bold = true;
                dgGrid.RenderControl(hw);
                Response.ContentType = "application/vnd.ms-excel";
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename + ".xls");
                EnableViewState = false;
                Response.Write(tw.ToString());
                Response.End();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            //
        }

        protected void OnCheckedChanged(object sender, EventArgs e)
        {

            bool isUpdateVisible = false;
            CheckBox chk = (sender as CheckBox);
            if (chk.ID == "checkAll")
            {
                foreach (GridViewRow row in GvRpt.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        row.Cells[0].Controls.OfType<CheckBox>().FirstOrDefault().Checked = chk.Checked;
                    }
                }
            }
            CheckBox chkAll = (GvRpt.HeaderRow.FindControl("checkAll") as CheckBox);
            //
            chkAll.Checked = true;

            foreach (GridViewRow row in GvRpt.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    bool isChecked = row.Cells[0].Controls.OfType<CheckBox>().FirstOrDefault().Checked;
                    //for (int i = 1; i < row.Cells.Count; i++)
                    //{
                    //  Label status = (GvRpt.HeaderRow.FindControl("lblStatus") as Label);
                    // row.Cells[i].Controls.OfType<Label>().FirstOrDefault().Visible = isChecked;
                    //if (row.Cells[i].Controls.OfType<Label>().ToList().Count > 0)
                    //{
                    //    row.Cells[i].Controls.OfType<Label>().FirstOrDefault().Visible = isChecked;
                    //}
                    if (isChecked == true)
                    {
                        //if (row.Cells[6].Controls.OfType<DropDownList>().ToList().Count > 0)
                        //{
                        //    row.Cells[6].Controls.OfType<DropDownList>().FirstOrDefault().Visible = true;
                        //    row.Cells[6].Controls.OfType<Label>().FirstOrDefault().Visible = false;
                        //}
                    }
                    else
                    {
                        // row.Cells[6].Controls.OfType<DropDownList>().FirstOrDefault().Visible = false;
                        // row.Cells[6].Controls.OfType<Label>().FirstOrDefault().Visible = true;
                    }

                    if (isChecked && !isUpdateVisible)
                    {
                        isUpdateVisible = true;
                        //  status.Visible = false;
                        //  row.Cells[i].Controls.OfType<Label>().FirstOrDefault().Visible = true;

                    }
                    if (!isChecked)
                    {
                        chkAll.Checked = false;
                    }
                }
                // }
            }
           // string type = ddltype.SelectedItem.Text;
            //if (type == "Registered")
            //{
            //    btnUpdate.Visible = isUpdateVisible;

            //}
            //else
            //{
            //    btnUpdate.Visible = false;
            //}
        }

        protected void Update(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GvRpt.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    bool isChecked = row.Cells[0].Controls.OfType<CheckBox>().FirstOrDefault().Checked;
                    string PanID = row.Cells[3].Controls.OfType<Label>().FirstOrDefault().Text;
                    string Status = row.Cells[6].Controls.OfType<DropDownList>().FirstOrDefault().SelectedItem.Value;
                    if (isChecked)
                    {
                        try
                        {

                            SqlCommand cmd = new SqlCommand("UPDATE NiaExamApplicants SET status = '" + Status + "'  WHERE status=1 and PANNo='" + PanID + "'", cnn);
                            cnn.Open();
                            // SqlCommand cmd = new SqlCommand("UPDATE NiaExamApplicants SET status = '" + Status + "'  WHERE PANNo='" + PanID + "'");
                            cmd.ExecuteNonQuery();


                        }
                        catch (Exception ex)
                        {

                        }
                        finally
                        {
                            cnn.Close();
                        }
                    }
                }
            }
            btnUpdate.Visible = false;
            Response.Redirect("TrgDashbord.aspx");
        }

        protected void GvRpt_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    CheckBox chkboxall = (CheckBox)e.Row.FindControl("checkAll");
            //    CheckBox chkboxchk = (CheckBox)e.Row.FindControl("chk");
            //    if (e.Row.Cells[6].Text == "Registered")
            //    {
            //        chkboxall.Visible = true;
            //        chkboxchk.Visible = true;
            //    }
            //    else
            //    {
            //        //  chkboxall.Visible = false;
            //        //  chkboxchk.Visible = false;

            //    }
            //}
        }

        protected void exportphotos_Click(object sender, EventArgs e)
        {

            try
            {
                DataSet ds = (DataSet)Session["details"];

                DataTable firsttable = ds.Tables[0];
                string[] strArr = new string[firsttable.Rows.Count]; // some time here null values record also came thats why count showing exactly (ex: 14..etc)

                int i = 0;
                foreach (DataRow r in firsttable.Rows)
                {
                    if (r["photo"] != DBNull.Value && Convert.ToString(r["photo"]) != null && Convert.ToString(r["photo"]) != string.Empty && Convert.ToString(r["photo"]) != "")
                    {
                        strArr[i] = Server.MapPath(@"~\\lib\\niaPhotos\\") + Convert.ToString(r["photo"]);
                    }

                    i++;
                }


                string notFoundFiles = "";
                string foundFiles = "";
                //string[] filename = strArr;

                for (int j = 0; j < strArr.Length; j++)
                {
                    if (File.Exists(strArr[j]))
                    {
                        foundFiles += strArr[j] + ",";
                    }
                    else
                    {
                        if (strArr[j] != null && strArr[j] != string.Empty && strArr[j] != "") // thats why here we are checking not null
                        {
                            notFoundFiles += strArr[j].Substring(strArr[j].LastIndexOf('\\') + 1) + ","; // + 1 used to dispaly content of the after this // 
                            //notFoundFiles += strArr[j] + ",";
                        }
                    }
                }

                foundFiles = foundFiles.TrimEnd(',');
                notFoundFiles = notFoundFiles.TrimEnd(',');

                string[] filename = foundFiles.Split(',');

                if (notFoundFiles != "")
                {
                    string[] notFoundFilesList = notFoundFiles.Split(',');
                    notFoundFiles = "";
                    for (int k = 0; k < notFoundFilesList.Length; k++)
                    {
                        notFoundFiles += notFoundFilesList[k] + "<br>";
                    }

                }
                using (ZipFile zip = new ZipFile())
                {

                    DateTime _date = DateTime.Now;
                    string format = "dd-MM-yyyy";
                    string date = _date.ToString(format);

                    //if (filename.Length > 1)
                    //{
                    if (foundFiles != string.Empty)
                    {
                        zip.AddFiles(filename, "file");
                        zip.Save(Server.MapPath(@"~\\lib\\niaPhotos\\" + "niaExamPhotos_" + date + ".zip"));
                        lblphotos.Text = "Photos Zip File is ready to download <a href='/lib/niaPhotos/niaExamPhotos_" + date + ".zip'>Click Here</a>";
                        lblphotos.Visible = true;
                    }

                    //break;
                    if (notFoundFiles != "")
                    {
                        lblphotos.Text = "Following files are not found <br>" + notFoundFiles;
                    }
                    //}
                }

            }

            catch (Exception ex)
            {

                lblphotos.Text = lblphotos.Text + ex.Message;
                //tryAgain = true;
                //lbltxt.Text = ex.Message;
            }


        }


    }
}