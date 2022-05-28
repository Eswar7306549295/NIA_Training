using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;



namespace NIAPRGExams.exam
{
    public partial class sendrcpt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string nameOfCandidate = Request.QueryString["name"];
            string email = Request.QueryString["EmailID"];
            string txnReferenceNo = Request.QueryString["TransRefNo"];
            string TranStatus = Request.QueryString["TranStatus"];
            string appliedfor = Request.QueryString["appliedfor"];
            string ModuleOpted = Request.QueryString["ModuleOpted"];
            string examcenter = Request.QueryString["ExamCentre"];
            string PaymentAmount = Request.QueryString["PaymentAmount"];
            string TransactionDt = Request.QueryString["CreationDate"];



            SmtpClient smtpClient = new SmtpClient();
            System.Net.Mail.MailMessage mailMessage = new System.Net.Mail.MailMessage();



            mailMessage.To.Add(new MailAddress(email));
            mailMessage.Subject = "NIA Exam Registration Reconfirmation";
            mailMessage.Body = "<html><body style='font-family: Helvetica Neue, Helvetica, Arial, sans-serif; font-size: 14px; line-height: 1.42857143; color: #333;' >  Dear " + nameOfCandidate + ",<br /><br />" +
"  Thank you! <br />" +
" You have successfully enrolled for the Online Brokers’ examination.<br />" +
"We have received your payment Rs.2950. Hall ticket for the exam will be sent to your registered email ID, two days before the exam.<br />" +
"<p style='text-align:left;'> <b> All the best</b></p>" +
"<h3> Your payment Details</h3></br> " +
"<table width='650px' border='2'> " +
" <tr> <td>Transaction Ref.Number </td>  <td> " + txnReferenceNo + "</td> </tr> " +
" <tr> <td>Name of the Applicant </td>  <td> " + nameOfCandidate + "</td> </tr> " +
" <tr> <td>Applied for </td>  <td> " + appliedfor + "</td> </tr> " +
" <tr> <td>Broking Module Opted for </td>  <td> " + ModuleOpted + "</td> </tr> " +
" <tr> <td>Examination Centre </td>  <td> " + examcenter + "</td> </tr> " +
" <tr> <td>Amount paid </td>  <td> " + PaymentAmount + "</td> </tr> " +
" <tr> <td>Date  of Transaction </td>  <td>" + TransactionDt + " </td> </tr> " +
"  </table>" +
"<p style='text-align:left;'> <b>This is reconfirmation of your payment, Please Ingore it if you already received payment receipt .</b></p>" +

"</body></html>";

            mailMessage.IsBodyHtml = true;
            smtpClient.Send(mailMessage);

            //Response.Write("<script>alert('Email');</script>");



            //ClientScript.RegisterStartupScript(this.GetType(), "alert", "Email Sent Sucessfully to Your Register Email Id", true);

            //ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "Email Sent Sucessfully to Your Register Email Id", true);

            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Email Sent Successfully to Your Register Email Id.Note: This tab is now getting close');window.close();", true);

            //ClientScript.RegisterStartupScript()

            //ScriptManager.RegisterStartupScript(this, GetType(), "alertMSG",
            //                                        "alertify.alert('Email Sent Sucessfully to Your Register Email Id');",
            //                                        true);



            //foreach (string s in Request.QueryString)
            //{
            //    Response.Write(Request.QueryString[s]);
            //}

            //for (int i = 0; i < Request.QueryString.Count; i++)
            //{
            //    Response.Write(Request.QueryString[i]);
            //}
            //string[] strArr = new string[Request.QueryString.Count]; 


            // Quary string values navigate from one page to another page..below method.


            //Response.Redirect("~/exam/WebForm1.aspx?sentence=" + strUserID + " &word=" + status + " &letter=" + username);

            //string[] conunt = new string[Request.QueryString.Count];

            // for (int j = 0; j < conunt.Length; j++)
            //{
            //StreamWriter logfile = null;
            //logfile = File.CreateText(Server.MapPath("~/NIAPRGExams/exam/log.txt"));
            //System.IO.File.WriteAllText("E:\\NIAPRGNew\\NIAPRGEXAM\\NIAPRGExam\\NIAPRGExams\\exam\\log.txt", conunt[j]);
            //Response.WriteFile("log.txt",true);
            // }
        }
    }
}