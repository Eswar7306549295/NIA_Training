using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace NIAPRG.lib
{
    public partial class SendingMail : System.Web.UI.Page
    {
        SqlConnection cnn = new SqlConnection(ConfigurationManager.AppSettings["DSN"]);

        //private const string URL = "https://outliers.tech/lms-api/testmail.php?to_mail=pavankasa3@gmail.com&cc_mail=pavankkumar.k@thebostongroup.com&subject=LMS%20EMAIL&body=LMS%20TEST%20EMAIL&payment=5.00&transaction_no=LHMP5929397579&name=SHIVA%20K%20RAJU&broking_module=Direct%20Life%20Insurance&date_of_transaction=01/01/2018&course_name=Online%20Brokers";
        //private const string DATA = @"{""object"":{""name"":""Name""}}";

        protected void Page_Load(object sender, EventArgs e)
        {
            string query1 = "select a.Name , a.EmailID ,a.TransRefNo ,a.TranStatus , a.ModuleOpted , a.PaymentAmount , a.CreationDate ,a.PANNo , b.Password from NiaApplicants a, Users b where a.PANNo = b.UserName and a.status=1 and a.CreationDate> '2022-01-01'";

            cnn.Open();
            SqlCommand SQLCommand = new SqlCommand(query1, cnn);
            SQLCommand.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(SQLCommand);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    string nameOfCandidate = ds.Tables[0].Rows[i]["Name"].ToString();
                    string email = ds.Tables[0].Rows[i]["EmailID"].ToString();
                    string txnReferenceNo = ds.Tables[0].Rows[i]["TransRefNo"].ToString();
                    string TranStatus = ds.Tables[0].Rows[i]["TranStatus"].ToString();
                    //string appliedfor = ds.Tables[0].Rows[i]["appliedfor"].ToString();
                    string ModuleOpted = ds.Tables[0].Rows[i]["ModuleOpted"].ToString();
                    //string examcenter = ds.Tables[0].Rows[i]["ExamCentre"].ToString();
                    string PaymentAmount = ds.Tables[0].Rows[i]["PaymentAmount"].ToString();
                    string TransactionDt = ds.Tables[0].Rows[i]["CreationDate"].ToString();
                    //string CompanyName = ds.Tables[0].Rows[i]["CompanyName"].ToString();
                    string PANNo = ds.Tables[0].Rows[i]["PANNo"].ToString();
                    string Password = ds.Tables[0].Rows[i]["Password"].ToString();

                    //string nameOfCandidate = Request.QueryString["name"];
                    //string email = Request.QueryString["EmailID"];
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
                    mailMessage.Subject = "NIA Course Registration Reconfirmation";
                    mailMessage.Body = "<html><body style='font-family: Helvetica Neue, Helvetica, Arial, sans-serif; font-size: 14px; line-height: 1.42857143; color: #333;' >  Dear " + nameOfCandidate + ",<br /><br />" +
        "  Thank you! <br />" +
        " You have successfully enrolled for the Online Brokers Course.<br />" +
        "We have received your payment " + PaymentAmount + ". <br />." +
    "You can access the course through the following URL: <a href=' https://e-learning.niapune.org.in '> https://e-learning.niapune.org.in</a> <br /><br />" +
        "<b>Your Login id </b> : " + PANNo + "<br />" +
    "<b> Your Password </b>: " + Password + "<br /><br />" +
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

                }
            }
        }
        //public string WebMethod()

        //{

        //    var result = string.Empty;

        //    try

        //    {

        //        var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://outliers.tech/lms-api/testmail.php?to_mail=durgaprasadp552@gmail.com&cc_mail=chinnababi552@gmail.com&subject=LMS EMAIL&body=LMS TEST EMAIL&payment=5.00&transaction_no=LHMP5929397579&name=SHIVA K RAJU&broking_module=Direct Life Insurance&date_of_transaction=01/01/2018&course_name=Online Brokers");

        //        httpWebRequest.Method = "POST";

        //        httpWebRequest.KeepAlive = false;

        //        httpWebRequest.Accept = "text/json";

        //        httpWebRequest.ContentType = "application/json";

        //        var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

        //        using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))

        //        {

        //            result = streamReader.ReadToEnd();

        //        }

        //    }

        //    catch (WebException ex)

        //    {

        //        result = ex.Message;

        //    }

        //    return result;

        //}
    }
}