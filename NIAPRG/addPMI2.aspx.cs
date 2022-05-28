using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PMI
{
    public partial class addPMI2 : System.Web.UI.Page
    {
        SqlConnection cnn = new SqlConnection(ConfigurationManager.AppSettings["DSN"]);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string query = "select top(1)VisitorId from VisitorsData order by VisitorId desc";
                int id = Getuesrid(query);
                string strid = id.ToString("0000000");
                strid = "PMI" + strid;
                Session["userid"] = strid;
                txtVisitorNo.Text = strid;
                txtIntime.Text = DateTime.Now.ToString();
            }

        }

        private int Getuesrid(string query)
        {

            cnn.Open();
            SqlCommand SQLCommand = new SqlCommand(query, cnn);
            SQLCommand.CommandType = CommandType.Text;
            int id = Convert.ToInt32(SQLCommand.ExecuteScalar());
            cnn.Close();
            if (id != 0)
                return id + 1;
            else
                return 1;
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            string query2 = "select VisitorId from VisitorsData where Vid='" + txtVisitorNo.Text + "'";
            int id = Getuesrid(query2);
            if (id == 1)
            {
                cnn.Open();
                String query = "INSERT INTO VisitorsData (name, fromorg,Address,whomtomeet,mobile,Typeof, Emailid,Otherinfo,INTIME," +
                   "OUTTIME, photo,remarks,creationDate,Vid) " +
                    " VALUES(@name, @fromorg,@Address,@whomtomeet,@mobile,@Typeof, @Emailid,@Otherinfo,@INTIME," +
                   "GETDATE(), @photo,@remarks,GETDATE(),@Vid)";

                //  String query = "il_NiaApplicants_prd";
                SqlCommand command = new SqlCommand(query, cnn);
                command.CommandType = CommandType.Text;
                command.Parameters.Add("@name", txtnameOfCandidate.Text);
                command.Parameters.Add("@fromorg", txtfrom.Text);
                command.Parameters.Add("@Address", txtAddress.Text);
                command.Parameters.Add("@whomtomeet", txtmeet.Text);
                command.Parameters.Add("@mobile", txtmobile.Text);
                command.Parameters.Add("@Typeof", ddlTypeList.SelectedValue.ToString());
                command.Parameters.Add("@Emailid", txtemail.Text);
                command.Parameters.Add("@Otherinfo", txtOtherInfo.Text);
                command.Parameters.Add("@INTIME", txtIntime.Text);
                command.Parameters.Add("@photo", Convert.ToString(Session["path"]));
                command.Parameters.Add("@remarks", "");
                command.Parameters.Add("@Vid", txtVisitorNo.Text);

                command.ExecuteNonQuery();
                cnn.Close();
                imgprt.Visible = true;
                lbsingn.Visible = true;
                string oldString = Convert.ToString(Session["path"]); ;
               // string s = oldString.Substring(oldString.IndexOf("CapturedImages"));
                imgprt.ImageUrl = oldString;

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
                dt.Rows.Add(txtVisitorNo.Text,txtnameOfCandidate.Text, txtfrom.Text, txtmeet.Text, txtAddress.Text,txtmobile.Text,txtemail.Text,txtOtherInfo.Text,txtIntime.Text,ddlTypeList.SelectedItem.Text, oldString);
                Session["data"] = dt;
                ClientScript.RegisterStartupScript(this.GetType(), "onclick", "<script language=javascript>window.open('PrintData.aspx','PrintMe','height=300px,width=300px,scrollbars=1');</script>");
   
                //Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "PrintElem('#makepayment')", true);


    //            ScriptManager.RegisterStartupScript(this, this.GetType(),
    //"alert",
    //"alert('Visitor details saved sucessfully');window.location ='PrintData.aspx';",
    //true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(),
                    "alert",
                    "alert('Visitor already existed with this VisitorId please Try again');",
                    true);
            }
        }

      

        [WebMethod]
        public static void Upload(string base64)
        {
            var obj = DateTime.Now.Second;
            var parts = base64.Split(new char[] { ',' }, 2);
            var bytes = Convert.FromBase64String(parts[1]);
            var path = HttpContext.Current.Server.MapPath(string.Format("~/CapturedImages/{0}.jpg", Convert.ToString(HttpContext.Current.Session["userid"]) + "_" + Convert.ToString(obj)));
            System.IO.File.WriteAllBytes(path, bytes);
            
            string oldString = Convert.ToString(path); ;
            string s = oldString.Substring(oldString.IndexOf("CapturedImages"));
            HttpContext.Current.Session["path"] = s;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Session["ctrl"] = pnlContents;
            //ClientScript.RegisterStartupScript(this.GetType(), "onclick", "<script language=javascript>window.open('PrintData.aspx','PrintMe','height=300px,width=300px,scrollbars=1');</script>");

            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[8] {
                            new DataColumn("vid", typeof(string)),
                            new DataColumn("name", typeof(string)),
                            new DataColumn("org", typeof(int)),
                            new DataColumn("whomeToMeet", typeof(int)),
                             new DataColumn("Address", typeof(int)),
                              new DataColumn("Mobile", typeof(int)),
                               new DataColumn("EmailId", typeof(int)),
                            new DataColumn("Photo", typeof(int))});
            dt.Rows.Add(101, "Sun Glasses", 200, 5, 1000);

        }
      
    }
}