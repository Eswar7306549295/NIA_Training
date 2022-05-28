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

namespace NIAPRG.Custom
{
    public partial class UserTimeSpentUpdate : System.Web.UI.Page
    {
        SqlConnection cnn = new SqlConnection(ConfigurationManager.AppSettings["DSN"]);
        string Username = ""; int uid;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        private void Binddata(string Username)
        {
            //cnn.Open();
            SqlCommand cmd = new SqlCommand("rSelectUserTimeSpent", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@username", Username);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            cnn.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                spnname.Visible = true;
                spntotaltime.Visible = true;
                lblusernames.Visible = true;
                lblcoursetotaltime.Visible = true;
                lblusernames.Text = ds.Tables[0].Rows[0]["firstname"].ToString();
                lblcoursetotaltime.Text = ds.Tables[0].Rows[0]["CourseTime"].ToString();
                lblmessage.Visible = false;
                GvRpt.Visible = true;
                GvRpt.DataSource = ds.Tables[0];
                GvRpt.DataBind();
                GvRpt.Columns[1].ItemStyle.HorizontalAlign = HorizontalAlign.Left;
                GvRpt.Columns[2].ItemStyle.HorizontalAlign = HorizontalAlign.Left;
                GvRpt.Columns[3].ItemStyle.HorizontalAlign = HorizontalAlign.Left;

            }
            else
            {
                //ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alertMessage('No Data Found..');", true);

                spnname.Visible = false;
                spntotaltime.Visible = false;
                lblusernames.Visible = false;
                lblcoursetotaltime.Visible = false;
                GvRpt.Visible = false;
                lblmessage.Visible = true;
                lblmessage.Text = "User Name Not Found, Enter correct username...!";

            }
        }


        protected void btnsearch_Click(object sender, EventArgs e)
        {
            Binddata(txtsearch.Text.Trim());
        }
        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)

        {
            if (e.CommandName == "TotalTime")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GvRpt.Rows[index];
                TextBox txttime = (TextBox)row.FindControl("txttotaltime");
                string txttimes = txttime.Text;
                Label lblUsername = (Label)row.FindControl("lbllinkusername");
                Label lblscoid = (Label)row.FindControl("lbllinkscoid");
                Label lbluserid = (Label)row.FindControl("lbllinkuserid");
                Label lblcourseid = (Label)row.FindControl("lbllinkcourseid");
                cnn.Open();
                SqlCommand cmd = new SqlCommand("rUpdateUserTimeSpent", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@userid", lbluserid.Text);
                cmd.Parameters.AddWithValue("@courseid", lblcourseid.Text);
                cmd.Parameters.AddWithValue("@scoid", lblscoid.Text);
                cmd.Parameters.AddWithValue("@totaltime", txttimes);
                cmd.ExecuteNonQuery();
                Binddata(lblUsername.Text);
                lblmessage.Visible = true;
                lblmessage.Text = "Time Updated Successfully..";
                cnn.Close();
            }
        }

    }
}