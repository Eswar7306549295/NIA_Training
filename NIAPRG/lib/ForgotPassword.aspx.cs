using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using System.Security;
using System.Net.Mail;
using System.Net;

namespace NIAPRG.lib
{
    public partial class ForgotPassword : System.Web.UI.Page
    {

        SqlConnection cnn = new SqlConnection(ConfigurationManager.AppSettings["DSN"]);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            if (txtusername.Text != "" || txtemail.Text != "")
            {
                string Username = "", Name = "", Password = "";
                cnn.Open();

                string query = "select LastName+''+FirstName Name,Email, UserName , Password from Users where UserName = '" + txtusername.Text.Trim()+"' and Email = '"+ txtemail.Text.Trim()+"'";
                SqlCommand SQLCommand = new SqlCommand(query, cnn);
                SQLCommand.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(SQLCommand);
                DataSet ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        Name = ds.Tables[0].Rows[i]["Name"].ToString();
                        Username = ds.Tables[0].Rows[i]["Username"].ToString();
                        Password = ds.Tables[0].Rows[i]["Password"].ToString();
                        string email = ds.Tables[0].Rows[i]["Email"].ToString();

                        //string nameOfCandidate = Request.QueryString["name"];
                        //string email = Request.QueryString["Email"];
                        //string txnReferenceNo = Request.QueryString["TransRefNo"];
                        //string TranStatus = Request.QueryString["TranStatus"];
                        ////string appliedfor = Request.QueryString["appliedfor"];
                        //string ModuleOpted = Request.QueryString["ModuleOpted"];
                        ////string examcenter = Request.QueryString["ExamCentre"];
                        //string PaymentAmount = Request.QueryString["PaymentAmount"];
                        //string TransactionDt = Request.QueryString["CreationDate"];

                        SmtpClient smtpClient = new SmtpClient();
                        smtpClient.Port = 587;
                        smtpClient.Host = "smtp.office365.com";
                        smtpClient.EnableSsl = true;
                        System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                        smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                        //smtpClient.UseDefaultCredentials = false;
                        smtpClient.ServicePoint.MaxIdleTime = 1;

                        smtpClient.Credentials = new NetworkCredential("lms-support@niapune.org.in", "nbt@2022");

                        string From = "lms-support@niapune.org.in";
                        // string ToAdd = "pavankasa3@gmail.com";
                        System.Net.Mail.MailMessage mailMessage = new System.Net.Mail.MailMessage(From, email);


                        mailMessage.To.Add(new MailAddress(email));
                        // mailMessage.CC.Add(new MailAddress(From));
                        mailMessage.Subject = "Requested Log-on information";
                        mailMessage.Body = "<html><body style='font-family: Helvetica Neue, Helvetica, Arial, sans-serif; font-size: 14px; line-height: 1.42857143; color: #333;' >  Dear " + Name + ",<br /><br />" +
            "  You recently requested that we e-mail your log-on information to this e-mail address. <br/>" +
            " The information you requested is listed below.<br /><br/>" +
            "User Name  : " + Username + "<br />" +
            "Password : " + Password + "<br />" +
            "Email : " + email + "<br /><br />" +
            "This request was received and processed on : " + DateTime.Now + "<br /><br />" +
            "System Administrator <br />" +
            "Site Administrator <br />" +
            "</body></html>";

                        mailMessage.IsBodyHtml = true;
                        try
                        {
                            smtpClient.Send(mailMessage);
                        }
                        catch
                        {
                            smtpClient.Send(mailMessage);
                        }
                       // ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Email Sent Successfully to Your Register Email Id.Note: This tab is now getting close');window.close();", true);
                        lblmsg.Text = "Email Sent Successfully to Your Register Email Id.";
                    }


                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMSG",
                                                     "alertify.alert(Invalid UserName / EmailId');",
                                                     true);
                    lblmsg.Text = "Invalid UserName / EmailId";
                    lblmsg.Visible = true;
                    return;
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMSG",
                                                     "alertify.alert(Invalid UserName / EmailId');",
                                                     true);
                lblmsg.Text = "Invalid UserName / EmailId";
                lblmsg.Visible = true;
                return;
            }
        }
    }
    
}

