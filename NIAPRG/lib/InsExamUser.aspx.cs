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
    public partial class InsExamUser : System.Web.UI.Page
    {
        SqlConnection cnn = new SqlConnection(ConfigurationManager.AppSettings["DSN"]);
        protected void Page_Load(object sender, EventArgs e)
        {
            string uid = Convert.ToString(Session["uid"]);
           // Label1.Text = "-|- uid" + Convert.ToString(Session["uid"]);
           // Label1.Text = Label1.Text + " -|- oid" + Convert.ToString(Session["oid"]);
           // Label1.Text = Label1.Text + "-|- role" + Convert.ToString(Session["role"]);
           // Label1.Text = Label1.Text + "-|- LangID" + Convert.ToString(Session["LangID"]);

           // string query1 = "SELECT UserName FROM Users WHERE  UserID = '" + uid + "'";
           // cnn.Open();
           // SqlCommand SQLCommand = new SqlCommand(query1, cnn);
           // SQLCommand.CommandType = CommandType.Text;
           //string USRole = Convert.ToString(SQLCommand.ExecuteScalar());
           // Label2.Text = Convert.ToString(USRole);
           // cnn.Close();
            if (!IsPostBack)
            {
                bindData();
            }
        }
        private void bindData()
        {
            cnn.Open();
            SqlCommand cmd = new SqlCommand("Select * from NiaApplicants where status = 3 order by id desc", cnn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            cnn.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                GdvExamUsers.DataSource = ds;
                GdvExamUsers.DataBind();
            }
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            //required to avoid the run time error "  
            //Control 'GridView1' of type 'Grid View' must be placed inside a form tag with runat=server."  
        }
        protected void btnExport_Click(object sender, EventArgs e)
        {
            ExportGridToExcel();
        }
        private void ExportGridToExcel()
        {
            Response.Clear();
            Response.Buffer = true;
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Charset = "";
            string FileName = "Vithal" + DateTime.Now + ".xls";
            StringWriter strwritter = new StringWriter();
            HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
            GdvExamUsers.GridLines = GridLines.Both;
            GdvExamUsers.HeaderStyle.Font.Bold = true;
            GdvExamUsers.RenderControl(htmltextwrtter);
            Response.Write(strwritter.ToString());
            Response.End();

        }  
    }
}