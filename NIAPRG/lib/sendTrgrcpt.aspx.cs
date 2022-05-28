using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Net;

namespace NIAPRGExams.exam
{
    public partial class sendTrgrcpt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            string nameOfCandidate = Request.QueryString["name"];
            string email = Request.QueryString["EmailID"];
            string txnReferenceNo = Request.QueryString["TransRefNo"];
            string TranStatus = Request.QueryString["TranStatus"];
            //string appliedfor = Request.QueryString["appliedfor"];
            string ModuleOpted = Request.QueryString["ModuleOpted"];
            //string examcenter = Request.QueryString["ExamCentre"];
            string PaymentAmount = Request.QueryString["PaymentAmount"];
            string TransactionDt = Request.QueryString["CreationDate"]; //dd/mm/yyyy



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
            mailMessage.CC.Add(new MailAddress(From));
            mailMessage.Subject = "NIA Course Registration Reconfirmation";
            mailMessage.Body = "<html><body style='font-family: Helvetica Neue, Helvetica, Arial, sans-serif; font-size: 14px; line-height: 1.42857143; color: #333;' >  Dear " + nameOfCandidate + ",<br /><br />" +
"  Thank you! <br />" +
" You have successfully enrolled for the Online Brokers Course.<br />" +
"We have received your payment "+PaymentAmount+". <br />." +
"You can login thru http://e-learning.niapune.org.in link. If you missed username and password please get it from forgot username and password link.<br />" +
"<p style='text-align:left;'> <b> All the best</b></p>" +
"<h3> Your payment Details</h3></br> " +
"<table width='650px' border='2'> " +
" <tr> <td>Transaction Ref.Number </td>  <td> " + txnReferenceNo + "</td> </tr> " +
" <tr> <td>Name of the Applicant </td>  <td> " + nameOfCandidate + "</td> </tr> " +
//" <tr> <td>Applied for </td>  <td> " + appliedfor + "</td> </tr> " +
" <tr> <td>Broking Module Opted for </td>  <td> " + ModuleOpted + "</td> </tr> " +
//" <tr> <td>Examination Centre </td>  <td> " + examcenter + "</td> </tr> " +
" <tr> <td>Amount paid </td>  <td> " + PaymentAmount + "</td> </tr> " +
" <tr> <td>Date  of Transaction </td>  <td>" + TransactionDt + " </td> </tr> " +
"  </table>" +
"<p style='text-align:left;'> <b>This is reconfirmation of your payment, Please Ingore it if you already received payment receipt .</b></p>" +

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
            //finally
            //{
            //    smtpClient.Send(mailMessage);
            //}
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Email Sent Successfully to Your Register Email Id.Note: This tab is now getting close');window.close();", true);

          



        }
    }
}