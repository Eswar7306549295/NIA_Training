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


namespace NIAPRGExams.lib
{
    public partial class CourseAdminUsersList : System.Web.UI.Page
    {
        int adminId = 0;
        SqlConnection cnn = new SqlConnection(ConfigurationManager.AppSettings["DSN"]);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"] != null)
            {
                adminId = Convert.ToInt32(Session["id"]);

            }
            else
            {
                Response.Redirect("CourseAdminLogin.aspx");
            }
            if (!Page.IsPostBack)
            {
                BindData();
            }
        }
        private void BindData()
        {
            decimal totalAmount = 0;
            cnn.Open();
            SqlCommand cmd = new SqlCommand("SELECT  AdminID,[Id] ,[Name] ,[Mobile] ,[PANNo] ,ExamCentre,ModuleOpted,status ,PaymentAmount ,[TransRefNo] ,[TranStatus] FROM [LearningServer].[dbo].[NiaApplicants] where TransRefNo is null and AdminID=" + adminId + ";", cnn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            cnn.Close();
            Session["Details"] = ds;
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    int x = Convert.ToInt32(ds.Tables[0].Rows[i]["id"]);
                    totalAmount = totalAmount + Convert.ToDecimal(ds.Tables[0].Rows[i]["PaymentAmount"].ToString());
                    lbltotalamount.Text = totalAmount.ToString();
                }
                gvpager.Visible = true;
                //gvpager1.Visible = true;
                GvRpt.DataSource = ds.Tables[0];
                GvRpt.DataBind();
                dvamt.Visible = true;
                bnprocessed.Visible = true;

            }
            else
            {
                dvamt.Visible = false;
                bnprocessed.Visible = false;
                ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                GvRpt.DataSource = ds.Tables[0];
                GvRpt.DataBind();
                GvRpt.Rows[0].Visible = false;
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMSG",
                                                    "alertify.alert('No Records Found');",
                                                    true);

            }

        }

        protected void Proceed_Click(object sender, EventArgs e)
        {


            if (Session["Mobile"] != null && Session["Email"] != null && Session["Username"] != null)
            {
                hdngatewayreq.Value = "NIANEW|" + "NIAEXM000000000000007" + "|NA|" + lbltotalamount.Text + "|NA|NA|NA|INR|NA|R|niabrkr|NA|NA|F|" + Session["Mobile"] + "|" + Session["Email"] + "|" + Session["Username"] + "|" + Session["Username"] + "|NA|NA|NA|http://103.241.144.250/lib/CourseordreturnNew.aspx";
                // hdngatewayreq.Value = "NIABRKR|" + "NIAEXM000000000000007" + "|NA|2|NA|NA|NA|INR|NA|R|niabrkr|NA|NA|F|" + Session["Mobile"] + "|" + Session["Email"] + "|" + Session["Username"] + "|" + Session["Username"] + "|NA|NA|NA|http://103.241.144.250/lib/CourseordreturnNew.aspx";
                Server.Transfer("BillDesk.aspx");
            }
            else
            {
                Server.Transfer("CourseAdminLogin.aspx");
            }

        }

        protected void GvRpt_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            cnn.Open();
            GridViewRow row = (GridViewRow)GvRpt.Rows[e.RowIndex];
            //Label lbldeleteid = (Label)row.FindControl("lblID");
            SqlCommand cmd = new SqlCommand("delete FROM  NiaApplicants where id='" + Convert.ToInt32(GvRpt.DataKeys[e.RowIndex].Value.ToString()) + "'", cnn);
            cmd.ExecuteNonQuery();
            cnn.Close();
            BindData();

        }
    }
}