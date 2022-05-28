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

namespace NIAPRG
{
    public partial class AdminReport : System.Web.UI.Page
    {
        string uid;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                uid = Request.QueryString["userid"];
                if (uid == "" || uid == null)
                {
                    uid = Session["uid"].ToString();
                    //uid = "32740";
                    // uid = "1";

                }
               // lblsessionid.Text = uid.ToString();
                BindData();
            }
        }
        private void BindData()
        {
            SqlConnection cnn = new SqlConnection(ConfigurationManager.AppSettings["DSN"]);
            cnn.Open();
            SqlCommand cmd = new SqlCommand("ril_GetExternalCoursesforLearner", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UesrID", uid.Trim().ToString());

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            cnn.Close();
            Session["Details"] = ds;
            if (ds.Tables[0].Rows.Count > 0)
            {
                
                GvRpt.DataSource = ds.Tables[0];
                GvRpt.DataBind();
                btnExport.Visible = true;

            }
            else
            {
                ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                GvRpt.DataSource = ds.Tables[0];
                GvRpt.DataBind();
                GvRpt.Rows[0].Visible = false;
                btnExport.Visible = false;
                this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('No records found')", true);


            }

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
    }
}