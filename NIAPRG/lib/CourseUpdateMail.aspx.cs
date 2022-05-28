using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;

namespace NIAPRG.lib
{
    public partial class CourseUpdateMail : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["DSN"]);

        protected void Page_Load(object sender, EventArgs e)
        {
            //string nameOfCandidate = Request.QueryString["name"];



            string email = "pavankumar.k@thebostongroup.com";
            string query1 = "select * from emailidtable;";
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
                    string usermailid = ds.Tables[0].Rows[i]["EmailID"].ToString();
                    SmtpClient smtpClient = new SmtpClient();
                    string FromAddress = "lms-support@niapune.org.in";
                    string ToAddress = "pavankasa3@gmail.com";
                    System.Net.Mail.MailMessage mailMessage = new System.Net.Mail.MailMessage();
                    mailMessage.To.Add(new MailAddress(usermailid));
                   // mailMessage.CC.Add(new MailAddress(usermailid));
                    mailMessage.Subject = "Testing mail";
                    mailMessage.Body = "<html><body style='font-family: Helvetica Neue, Helvetica, Arial, sans-serif; font-size: 14px; line-height: 1.42857143;' ><br /><br />" +
                        "Dear Sir/Madam,<br /><br />" +
                        " Testing mail.<br />" +
        "Testing mail.<br /><br />" +
        "Regards,<br/>" +
        "Support Team" +
        "</body></html>";

                    mailMessage.IsBodyHtml = true;

                    try
                    {
                        smtpClient.Send(mailMessage);
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Email Sent Successfully to Your Register Email Id.Note: This tab is now getting close');window.close();", true);
                    }
                    catch(Exception ex)
                    {

                    }
                }
            }
            

        }
    }
}