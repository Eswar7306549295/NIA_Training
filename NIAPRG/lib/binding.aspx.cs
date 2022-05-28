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
    public partial class Binding : System.Web.UI.Page
    {
        SqlConnection cnn = new SqlConnection(ConfigurationManager.AppSettings["DSN"]);
        string uid;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //string uid = Convert.ToString(Session["uid"]); //Request.QueryString["uid"]; 
                //int uid = Convert.ToInt32(Session["uid"]);

                uid = Request.QueryString["userid"];
                if (uid == "" || uid == null)
                {
                     uid = Session["uid"].ToString();
                    //uid = "32740";
                    // uid = "1";
                    //uid = "10043";
                }
                 

                BindData(1, uid);

            }

        }

        private void BindData(int parameter1, string parameter2)
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
            using (SqlCommand cmd = new SqlCommand("SELECT a.*,b.LastAccessDate,b.CompleteDate, cast(HRS as varchar)+':' + cast(MINS as varchar) as TimeSpent FROM rUsertimeReport a,UserCourses b where a.userid=" + uid+" and a.userid=b.UserID", cnn))
            {
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@parameter1", parameter1);
                //cmd.Parameters.AddWithValue("@parameter2", parameter2);
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

                    courseTitle = Convert.ToString(dt.Rows[i]["title"]);
                    if (dt.Rows[i]["LastAccessDate"] != DBNull.Value && Convert.ToString(dt.Rows[i]["LastAccessDate"]) != string.Empty)
                    {
                        lastAccessDate = Convert.ToDateTime(dt.Rows[i]["LastAccessDate"]);
                    }
                    if (dt.Rows[i]["CompleteDate"] != DBNull.Value && Convert.ToString(dt.Rows[i]["CompleteDate"]) != string.Empty)
                    {
                        completeDate = Convert.ToDateTime(dt.Rows[i]["CompleteDate"]);
                    }
                    if (dt.Rows[i]["HRS"] != DBNull.Value && Convert.ToString(dt.Rows[i]["HRS"]) != string.Empty)
                    {
                        hours = Convert.ToInt32(dt.Rows[i]["HRS"]);
                    }
                    if (dt.Rows[i]["MINS"] != DBNull.Value && Convert.ToString(dt.Rows[i]["MINS"]) != string.Empty)
                    {
                        minutes = Convert.ToInt32(dt.Rows[i]["MINS"]);
                    }
                    //if (dt.Rows[i]["TotalSeconds"] != DBNull.Value && Convert.ToString(dt.Rows[i]["TotalSeconds"]) != string.Empty)
                    //{
                    //    seconds = Convert.ToInt32(dt.Rows[i]["TotalSeconds"]);
                    //}

                    totalSeconds = seconds + (minutes * 60) + (hours * 60 * 60);
                    quotient = (totalSeconds) / 3600;
                    remainder = (totalSeconds) % 3600;
                    hours = quotient; // hours
                    quotient = (remainder) / 60;
                    minutes = quotient; // mintues
                    remainder = (remainder) % 60;
                    seconds = remainder; // seconds
                    elapsedTime = hours + ":" + minutes;
                    dtTemp.Rows.Add(courseTitle, lastAccessDate, completeDate, elapsedTime);
                }
                GvRpt.DataSource = dtTemp;
                GvRpt.DataBind();
            }
            else
            {
                GvRpt.DataSource = null;
                GvRpt.DataBind();
            }


        }


    }
}