using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PMI
{
    public partial class ListofData : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["DSN"]);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SqlDataAdapter Adp = new SqlDataAdapter("select * from VisitorsData where INTIME >= CAST(GETDATE() AS DATE) order by VisitorId desc", con);
                DataTable Dt = new DataTable();
                Adp.Fill(Dt);
                visitorsgrid.DataSource = Dt;
                visitorsgrid.DataBind();
               
            }
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            con.Open();
            String query = "update VisitorsData set OUTTIME='"+txtOutTime.Text+"',remarks='"+txtRemarks.Text+"' where vid='"+txtVisitorNo.Text+"' ";

            //  String query = "il_NiaApplicants_prd";
            SqlCommand command = new SqlCommand(query, con);           
            command.ExecuteNonQuery();
            con.Close();
            ScriptManager.RegisterStartupScript(this, this.GetType(),
"alert",
"alert('Visitor details Updated sucessfully');window.location ='ListofData.aspx';",
true);
        }

      

        protected void visitorsgrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            con.Open();
            if (e.CommandName == "Editrow")
            {
                LinkButton lnkedit = (LinkButton)e.CommandSource;
                string VId = lnkedit.CommandArgument;
                string query2 = "select * from VisitorsData where Vid='" + VId + "'";
                SqlCommand cmd = new SqlCommand(query2, con);
                SqlDataReader dr = cmd.ExecuteReader();
                txtVisitorNo.Text = VId;
                if (dr.Read())
                {
                    txtnameOfCandidate.Text = dr["Name"].ToString();
                    txtfrom.Text = dr["fromorg"].ToString();
                    txtmeet.Text = dr["whomtomeet"].ToString();
                    txtOutTime.Text = DateTime.Now.ToString();
                    txtRemarks.Text = dr["remarks"].ToString();
                }
                divedit.Visible = true;
                visitorsgrid.Visible = false;
                griddiv.Visible = false;
            }
            if (e.CommandName == "Printrow")
            {
                string address="", mobile="", emailid="", otherinfo="", intime="", typeof1="", photo="";
                LinkButton lnkedit = (LinkButton)e.CommandSource;
                string VId = lnkedit.CommandArgument;
                string query2 = "select * from VisitorsData where Vid='" + VId + "'";
                SqlCommand cmd = new SqlCommand(query2, con);
                SqlDataReader dr = cmd.ExecuteReader();
                txtVisitorNo.Text = VId;
                if (dr.Read())
                {
                    txtnameOfCandidate.Text = dr["Name"].ToString();
                    txtfrom.Text = dr["fromorg"].ToString();
                    txtmeet.Text = dr["whomtomeet"].ToString();
                    address = dr["Address"].ToString();
                    mobile = dr["mobile"].ToString();
                    emailid = dr["Emailid"].ToString();
                    otherinfo = dr["Otherinfo"].ToString();
                    intime = dr["INTIME"].ToString();
                    typeof1 = dr["Typeof"].ToString();
                    photo = dr["photo"].ToString();
                }
               
                DataTable dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[11] {
                            new DataColumn("vid", typeof(string)),
                            new DataColumn("name", typeof(string)),
                            new DataColumn("org", typeof(string)),
                            new DataColumn("whomeToMeet", typeof(string)),
                             new DataColumn("Address", typeof(string)),
                              new DataColumn("Mobile", typeof(string)),
                               new DataColumn("EmailId", typeof(string)),
                               new DataColumn("Otherinfo", typeof(string)),
                               new DataColumn("INTIME", typeof(string)),
                               new DataColumn("Typeof", typeof(string)),
                            new DataColumn("Photo", typeof(string))});
                dt.Rows.Add(txtVisitorNo.Text, txtnameOfCandidate.Text, txtfrom.Text, txtmeet.Text, address, mobile, emailid, otherinfo, intime, typeof1, photo);
                Session["data"] = dt;
                ClientScript.RegisterStartupScript(this.GetType(), "onclick", "<script language=javascript>window.open('PrintData.aspx','PrintMe','height=300px,width=300px,scrollbars=1');</script>");
   
               
            }
            con.Close();
        }

        protected void btnsearchName_Click(object sender, EventArgs e)
        {
            SqlDataAdapter Adp = new SqlDataAdapter(" select * from VisitorsData where name like '%"+txtsearchname.Text+"%' order by VisitorId desc  ", con);
            DataTable Dt = new DataTable();
            Adp.Fill(Dt);
            visitorsgrid.DataSource = Dt;
            visitorsgrid.DataBind();
        }

        protected void btnsearchdate_Click(object sender, EventArgs e)
        {
            string tdate = txtSearchDate.Text;
            IFormatProvider culture = new CultureInfo("en-US", true);
            DateTime Dt2 = DateTime.ParseExact(tdate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            string sqlFormattedDate = Dt2.Date.ToString("yyyy-MM-dd");
            SqlDataAdapter Adp = new SqlDataAdapter(" select * from VisitorsData where CONVERT(VARCHAR(25), INTIME, 126)  like '%" + sqlFormattedDate + "%' order by VisitorId desc  ", con);
            DataTable Dt = new DataTable();
            Adp.Fill(Dt);
            visitorsgrid.DataSource = Dt;
            visitorsgrid.DataBind();
        }

        protected void btnFindAll_Click(object sender, EventArgs e)
        {
            SqlDataAdapter Adp = new SqlDataAdapter(" select * from VisitorsData order by VisitorId desc  ", con);
            DataTable Dt = new DataTable();
            Adp.Fill(Dt);
            visitorsgrid.DataSource = Dt;
            visitorsgrid.DataBind();
        }       
    }
}