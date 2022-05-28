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
    public partial class AddPMI : System.Web.UI.Page
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
                return id+1;
            else
                return 1;
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            string query2 = "select VisitorId from VisitorsData where Vid='"+txtVisitorNo.Text+"'";
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



    //            ScriptManager.RegisterStartupScript(this, this.GetType(),
    //"alert",
    //"alert('Visitor details saved sucessfully');window.location ='ListofData.aspx';",
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

        //private void print()
        //{
        //    Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "printDiv('makepayment')", true);
        //}

        //protected void btnStart_Click(object sender, EventArgs e)
        //{
        //    ScriptManager.RegisterStartupScript(this, GetType(), "stopCapture", "stopCapture();", true);
        //}
       
        [WebMethod]
        public static void Upload(string base64)
        {
            var obj = DateTime.Now.Second;
            var parts = base64.Split(new char[] { ',' }, 2);
            var bytes = Convert.FromBase64String(parts[1]);
            var path = HttpContext.Current.Server.MapPath(string.Format("~/CapturedImages/{0}.jpg", Convert.ToString(HttpContext.Current.Session["userid"]) + "_" + Convert.ToString(obj)));
            System.IO.File.WriteAllBytes(path, bytes);
            HttpContext.Current.Session["path"] = path;
        }
      
    }
}