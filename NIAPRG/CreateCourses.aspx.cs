using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace NIAPRG
{
    public partial class CreateCourses : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
                BindEventType();
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
                    ddlEventType.DataSource = cmd.ExecuteReader();
                    ddlEventType.DataTextField = "Title";
                    ddlEventType.DataValueField = "ExternalEventTypeID";
                    ddlEventType.DataBind();
                    con.Close();
                }
            }
            ddlEventType.Items.Insert(0, new ListItem("Please choose anyone", "0"));
            //ddlcompanylist.Items.Insert(+1, new ListItem("Not Applicable", "999"));

        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            SqlConnection cnn = new SqlConnection(ConfigurationManager.AppSettings["DSN"]);
            cnn.Open();
            if (ddlEventType.SelectedValue != "0")
            {
                if (txtCourseCode.Text != "")
                {
                    if (txtCourseName.Text != "")
                    {

                        try
                        {
                            string Query = "INSERT INTO [dbo].[ExternalCourses] ([OrgID] ,[ExternalEventTypeID] ,[CourseCode] ,[Title]) VALUES (1," + ddlEventType.SelectedItem.Value + ",'" + txtCourseCode.Text + "','" + txtCourseName.Text + "')";
                            SqlCommand command = new SqlCommand(Query, cnn);
                            command.ExecuteNonQuery();
                            this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('Course Created Successfully')", true);
                            BindData();
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                    else
                    {
                        this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('Please Enter Course Name')", true);

                    }
                }
                else
                {
                    this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('Please Enter Course Code')", true);

                }
            }
            else
            {
                this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('Please Select External EventType')", true);

            }
        }
        protected void btnExport_Click(object sender, EventArgs e)
        {

            DataSet ds = (DataSet)Session["Details"];
            if (ds.Tables[0].Rows.Count > 0)
            {
               // DataTableExportToExcel(ds.Tables[0], " Report", "");
            }

        }
        private void BindData()
        {

            SqlConnection cnn = new SqlConnection(ConfigurationManager.AppSettings["DSN"]);
            cnn.Open();
            SqlCommand cmd = new SqlCommand("select b.Title as Type, a.CourseCode,a.Title as courseName from ExternalCourses a, ExternalEventTypes b where a.ExternalEventTypeID=b.ExternalEventTypeID;", cnn);
            //cmd.CommandType = CommandType.StoredProcedure;
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
                //exportphotos.Visible = true;

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
                //   gvpager.Visible = false;
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMSG",
                                                    "alertify.alert('No Records Found');",
                                                    true);
                //RptMdlExt.Hide();

            }

        }
    }
}