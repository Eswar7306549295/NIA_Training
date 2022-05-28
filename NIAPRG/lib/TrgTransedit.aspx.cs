using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace NIAPRGExams.exam
{
    public partial class TrgTransedit : System.Web.UI.Page
    {

        SqlConnection cnn = new SqlConnection(ConfigurationManager.AppSettings["DSN"]);
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                string id = Request.QueryString["Id"];
                string Statusid = Request.QueryString["statusid"];
                if (Statusid=="1")
                {
                    CHKagree.Visible = true;
                    lblreg.Visible = true;
                }
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("select status as statusid,* from NiaApplicants where id='" + id + "'", cnn))
                {

                    cmd.CommandType = CommandType.Text;
                    SqlDataReader dr = cmd.ExecuteReader();
                    dt.Load(dr);
                    cnn.Close();
                }
                if (dt.Rows.Count > 0)
                {
                    txtpan.Text = Convert.ToString(dt.Rows[0]["PANNo"]);
                    txtpan.ReadOnly = true;

                    txtnameOfCandidate.Text = Convert.ToString(dt.Rows[0]["Name"]);
                    txtnameOfCandidate.ReadOnly = true;

                    txtPaymnetRef.Text = Convert.ToString(dt.Rows[0]["TransRefNo"]);
                    txtTransStatus.Text = Convert.ToString(dt.Rows[0]["TranStatus"]);

                    if (dt.Rows[0]["status"] != DBNull.Value && Convert.ToString(dt.Rows[0]["status"]) != null && Convert.ToString(dt.Rows[0]["status"]) != string.Empty)
                    {
                        if (ddlStatus.Items.FindByValue(Convert.ToString(dt.Rows[0]["status"]).Trim()) != null)
                        {
                            ddlStatus.Items.FindByValue(Convert.ToString(dt.Rows[0]["status"]).Trim()).Selected = true;

                        }
                    }
                    if (dt.Rows[0]["ModuleOpted"] != DBNull.Value && Convert.ToString(dt.Rows[0]["ModuleOpted"]) != null && Convert.ToString(dt.Rows[0]["ModuleOpted"]) != string.Empty)
                    {
                        if (ddlbrokingModule.Items.FindByText(Convert.ToString(dt.Rows[0]["ModuleOpted"]).Trim()) != null)
                        {
                            ddlbrokingModule.Items.FindByText(Convert.ToString(dt.Rows[0]["ModuleOpted"]).Trim()).Selected = true;
                        }
                    }
                }

            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            string id = Request.QueryString["Id"];
            string Pan = txtpan.Text;
            string Name = txtnameOfCandidate.Text;
            string PaymnetRef = txtPaymnetRef.Text;
            string TransStatus = txtTransStatus.Text;

            string Status = ddlStatus.SelectedItem.Value;


            int k = 0;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["DSN"]))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "update NiaApplicants SET TransRefNo = '" + PaymnetRef + "',TranStatus='" + TransStatus + "',ModuleOpted='" + ddlbrokingModule.SelectedItem + "',ModuleCode='" + ddlbrokingModule.SelectedValue + "',status='" + Status + "' where id=" + id + "";
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    k = cmd.ExecuteNonQuery();
                    con.Close();
                }

                if(CHKagree.Checked==true)
                {

                    // 

                }

                if (k == 1)
                {
                    this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('Record Updated successfully.');window.close();", true);

                }
            }

        }



    }
}