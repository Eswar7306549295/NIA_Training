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
    public partial class NewTotalHours : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["DSN"]);
        protected void Page_Load(object sender, EventArgs e)
        {
            int uid = Convert.ToInt32(Session["uid"]);
            string courseID = Request.QueryString["courseID"];
            //Convert.ToString(Session["courseID"]);
            BindData(1, "1");
            BindData(uid, courseID);

        }
        private void BindData(int parameter1, string parameter2)
        {
            string query1 = "select COUNT(*) as Totallessons from lessons where CourseID=42 and MasteryScore<>'block';";
            con.Open();
            SqlCommand SQLCommand = new SqlCommand(query1, con);
            SQLCommand.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(SQLCommand);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    lbltotallessons.Text = ds.Tables[0].Rows[i]["Totallessons"].ToString();

                }
            }
            con.Close();
            string query2 = "select count(*) as Completedlessons from ScormStatus where UserID= 5149 and CourseID=42";
            con.Open();
            SqlCommand SQLCommand2 = new SqlCommand(query2, con);
            SQLCommand.CommandType = CommandType.Text;
            SqlDataAdapter da2 = new SqlDataAdapter(SQLCommand2);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            if (ds2.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds2.Tables[0].Rows.Count; i++)
                {
                    lblcompletedlessons.Text = ds2.Tables[0].Rows[i]["Completedlessons"].ToString();

                }
            }
            con.Close();
        }
    }
}