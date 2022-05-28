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
    public partial class ExternalEventTypes : System.Web.UI.Page
    {
        string Message = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        protected void btnsubmint_Click(object sender, EventArgs e)
        {
            SqlConnection cnn = new SqlConnection(ConfigurationManager.AppSettings["DSN"]);
            cnn.Open();
            if (txtExternalEventTypes.Text != "")
            {
                try
                {
                    string Query = "INSERT INTO [dbo].[ExternalEventTypes] ([OrgID] ,[Title]) VALUES (1,'" + txtExternalEventTypes.Text + "')";
                    SqlCommand command = new SqlCommand(Query, cnn);
                    command.ExecuteNonQuery();
                    Message = "ExternalEventType Inserted Successfully.";
                    this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('ExternalEventType Inserted Successfully')", true);
                    BindData();
                }
                catch (Exception ex)
                {
                    Message = ex.ToString();
                }
            }
            else
            {
                this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('Please Enter ExternalEventType')", true);

            }

        }

        private void BindData()
        {

            SqlConnection cnn = new SqlConnection(ConfigurationManager.AppSettings["DSN"]);
            cnn.Open();
            SqlCommand cmd = new SqlCommand("select ExternalEventTypeID, title from  ExternalEventTypes", cnn);
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