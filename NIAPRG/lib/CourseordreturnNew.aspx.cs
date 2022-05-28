using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;
using System.IO;
using System.Net;

namespace NIAPRG
{
    public partial class courseordreturnNew : System.Web.UI.Page
    {
        SqlConnection cnn = new SqlConnection(ConfigurationManager.AppSettings["DSN"]);

        protected void Page_Load(object sender, EventArgs e)
        {
            //string res = GetResponse();
            //txtmsg.Text = res;

            if (!IsPostBack)
            {

                string _paymentResp = Request.Form["msg"];
                //for Direct Registrations
                //if (_paymentResp == "" || _paymentResp == null)
                //{


                //  _customerId = _customerId.Remove(0, 6);

                //               string _customerId = Session["CustmourID"].ToString();
                //               if (_customerId != "" || _customerId != null)
                //               {
                //                   _customerId = _customerId.Remove(0, 6);
                //                   _customerId = _customerId.TrimStart('0');
                //                   AddToLms(_customerId, "0", "88888");

                //                   //EnrolleCourse(_customerId);
                //                   int STATUS = 1;
                //                   UpdateNIA(STATUS, _customerId, "Direct Registration", "99999", "88888");
                //                   div1.InnerHtml = "   <h3 style=' text-align: left; color: #3f6cb1; font-weight:bold;'>Congratulations!</h3><h3 style=' text-align: left; color: #3f6cb1; font-weight:bold;'>" +
                //      "   Your Transaction has been completed successfully.. </h3><h3 style='text-align: left; color: #3f6cb1; font-weight:bold;'>" +
                //"  we have sent the confirmation with Access details to your mail id</h3><h3 style=' text-align: left; color: #3f6cb1; font-weight:bold;'>Please <a href='http://e-learning.niapune.org.in'> Click Here</a> to login your account </h3>";


                //               }
                //               else
                //               {
                //                   Response.Redirect("newreg.aspx");
                //               }


                //}
                //else
                {
                    createlog(_paymentResp);
                    TESTLB.Text = _paymentResp;


                    try
                    {
                        string[] arrResponse = _paymentResp.Split('|'); //PG

                        string merchantId = arrResponse[0];
                        string _customerId = arrResponse[1];
                        string RealCid = _customerId;
                        //  lbreturn.Text = _customerId;
                        string txnReferenceNo = arrResponse[2];
                        // string bankReferenceNo = arrResponse[3];
                        string txnAmount = arrResponse[4];
                        //  string bankId = arrResponse[5];
                        // string bankMerchantId = arrResponse[6];
                        // string txtType = arrResponse[7];
                        // string CurrencyName = arrResponse[8];
                        string ItemCode = arrResponse[9];
                        //string SecurityType = arrResponse[10];
                        //string SecurityPwd = arrResponse[11];
                        string TxnDate = arrResponse[12];
                        string AuthStatus = arrResponse[14];
                        //string SettlementType = arrResponse[14];
                        //string AddInfo1 = arrResponse[15];
                        //string Addinfo2 = arrResponse[16];
                        //string addinfo3 = arrResponse[17];
                        //string addinfo4 = arrResponse[18];
                        //string addinfo5 = arrResponse[19];
                        //string addinfo6 = arrResponse[20];
                        //string addinfo7 = arrResponse[21];
                        string ErrorStatus = arrResponse[24];
                        //string ErrorDes = arrResponse[23];
                        //string CheckSum = arrResponse[24];
                        ErrorStatus = ErrorStatus + ": " + AuthStatus;
                        if (AuthStatus == "0300")
                        {
                            _customerId = _customerId.Remove(0, 6);
                            _customerId = _customerId.TrimStart('0');
                            AddToLms(_customerId, txnAmount, txnReferenceNo);

                            //EnrolleCourse(_customerId);
                            int STATUS = 1;
                            UpdateNIA(STATUS, _customerId, ErrorStatus, txnReferenceNo, RealCid);
                            div1.InnerHtml = "   <h3 style=' text-align: left; color: #3f6cb1; font-weight:bold;'>Congratulations!</h3><h3 style=' text-align: left; color: #3f6cb1; font-weight:bold;'>" +
               "   Your Transaction has been completed successfully.. </h3><h3 style='text-align: left; color: #3f6cb1; font-weight:bold;'>" +
         "  we have sent the confirmation with Access details to your mail id</h3><h3 style=' text-align: left; color: #3f6cb1; font-weight:bold;'>Please <a href='http://e-learning.niapune.org.in'> Click Here</a> to login your account </h3>";

                        }
                        else
                        {
                            _customerId = _customerId.Remove(0, 6);
                            _customerId = _customerId.TrimStart('0');
                            string nameOfCandidate = "";
                            string salutation = "", pan = "", email = "";
                            cnn.Open();
                            //string query2 = "select * from [NiaApplicants] where id='" + _customerId + "' ";
                            //SqlCommand cmd = new SqlCommand(query2, cnn);
                            //cmd.CommandType = CommandType.Text;
                            string query2 = "il_NiaApplicants_prd";
                            SqlCommand cmd = new SqlCommand(query2, cnn);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@Action", "selectid");
                            cmd.Parameters.Add("@id", _customerId);
                            SqlDataReader dr = cmd.ExecuteReader();

                            if (dr.Read())
                            {
                                nameOfCandidate = dr["Name"].ToString();
                                salutation = dr["salutation"].ToString();
                                pan = dr["PANNo"].ToString();
                                email = dr["EmailID"].ToString();

                            }
                            cnn.Close();
                            int STATUS = 0;
                            UpdateNIA(STATUS, _customerId, ErrorStatus, txnReferenceNo, RealCid);
                            div1.InnerHtml = "   <h3 style=' text-align: left; color: #3f6cb1; font-weight:bold;'>Oops!!</h3><h3 style=' text-align: left; color: #3f6cb1; font-weight:bold;'>" +
              "   Your Transaction has been Failed.. </h3><h3 style='text-align: left; color: #3f6cb1; font-weight:bold;'> we have sent the details to your mail id</h3><h3 style=' text-align: left; color: #3f6cb1; font-weight:bold;'>Please <a href='http://e-learning.niapune.org.in/lib/newReg.aspx'> Click Here</a> to try again </h3>";
                            SmtpClient smtpClient = new SmtpClient();
                            smtpClient.Port = 587;
                            smtpClient.Host = "smtp.office365.com";
                            smtpClient.EnableSsl = true;
                            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                            smtpClient.UseDefaultCredentials = false;
                            System.Net.Mail.MailMessage mailMessage = new System.Net.Mail.MailMessage();
                            mailMessage.To.Add(new MailAddress(email));
                            mailMessage.Subject = " NIA Course Registration Failed";
                            mailMessage.Body = " <html><body style='font-family: Helvetica Neue, Helvetica, Arial, sans-serif; font-size: 14px; line-height: 1.42857143; color: #333;' >Dear " + salutation + "." + nameOfCandidate + ", <br/>" +
                               "Your NIA Registration Process was not Completed .<br/><br/> Please try again <br/>" +
                               "URL : <a href=' https://e-learning.niapune.org.in '> https://e-learning.niapune.org.in</a> <br/> Thank You So Much for reposing the trust in us .<br/><br/> Yours <br/><br/> Team NIA <br/> <html><body> ";
                            mailMessage.IsBodyHtml = true;
                            //smtpClient.Send(mailMessage);
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
                        }
                    }
                    catch (Exception ex)
                    {
                        LogError(ex);
                    }
                }

            }
        }

        private void LogError(Exception ex)
        {
            string message = string.Format("Time: {0}", DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"));
            message += Environment.NewLine;
            message += "-----------------------------------------------------------";
            message += Environment.NewLine;
            message += string.Format("page", "CourseOrderReturn.aspx page");
            message += Environment.NewLine;
            message += string.Format("Message: {0}", ex.Message);
            message += Environment.NewLine;
            message += string.Format("StackTrace: {0}", ex.StackTrace);
            message += Environment.NewLine;
            message += string.Format("Source: {0}", ex.Source);
            message += Environment.NewLine;
            message += string.Format("TargetSite: {0}", ex.TargetSite.ToString());
            message += Environment.NewLine;
            message += "-----------------------------------------------------------";
            message += Environment.NewLine;
            string path = Server.MapPath("nia_files/LogError.txt");
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine(message);
                writer.Close();
            }
        }

        private void createlog(string _paymentResp)
        {
            string message = string.Format("Time: {0}", DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"));
            message += Environment.NewLine;
            message += "-----------------------------------------------------------";
            message += Environment.NewLine;
            message += string.Format("paymentResponse: {0}", _paymentResp);
            message += Environment.NewLine;
            message += "-----------------------------------------------------------";
            message += Environment.NewLine;
            string path = Server.MapPath("nia_files/logfile.txt");
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine(message);
                writer.Close();
            }
        }



        private void UpdateNIA(int STATUS, string _customerId, string ErrorStatus, string txnReferenceNo, string RealCid)
        {
            cnn.Open();
            // string query2 = "update [NiaApplicants] set status="+STATUS+",TranStatus='" + ErrorStatus + "',TransRefNo='" + txnReferenceNo + "',customerId='" + RealCid + "' where id='" + _customerId + "' ";
            string query2 = "il_NiaApplicants_prd";
            SqlCommand cmd = new SqlCommand(query2, cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Action", "update");
            cmd.Parameters.Add("@status", STATUS);
            cmd.Parameters.Add("@TranStatus", ErrorStatus);
            cmd.Parameters.Add("@TransRefNo", txnReferenceNo);
            cmd.Parameters.Add("@customerId", RealCid);
            cmd.Parameters.Add("@id", _customerId);
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        private void AddToLms(string _customerId, string txnAmount, string txnReferenceNo)
        {
            try
            {

                string nameOfCandidate = "", modulecode = "";
                string salutation = "", pan = "", Adhar = "", email = "", tel = "", mobile = "", Address = ""
                    , pin = "", imagename = "", professionalQuali = "", ModuleOpted = "";
                cnn.Open();
                // string query2 = "select * from [NiaApplicants] where id='" + _customerId + "' ";
                string query2 = "il_NiaApplicants_prd";
                SqlCommand cmd = new SqlCommand(query2, cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Action", "selectid");
                cmd.Parameters.Add("@id", _customerId);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    modulecode = dr["ModuleCode"].ToString();
                    ModuleOpted = dr["ModuleOpted"].ToString();
                    nameOfCandidate = dr["Name"].ToString();
                    salutation = dr["salutation"].ToString();
                    pan = dr["PANNo"].ToString();
                    Adhar = dr["AdharCardNo"].ToString();
                    email = dr["EmailID"].ToString();
                    // appliedFor = dr["Appliedfor"].ToString();
                    tel = dr["Tel"].ToString();
                    mobile = dr["Mobile"].ToString();
                    Address = dr["Address"].ToString();
                    pin = dr["Pin"].ToString();
                    imagename = dr["Photo"].ToString();
                    professionalQuali = dr["ProfQualification"].ToString();
                }
                cnn.Close();
                Random rand = new Random();
                int randomNumber = rand.Next(100000, 999999);

                String query = "il_User_User_pri";
                cnn.Open();
                SqlCommand command = new SqlCommand(query, cnn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@OrgID", "1");
                command.Parameters.Add("@Fname", nameOfCandidate);
                command.Parameters.Add("@Lname", salutation);
                command.Parameters.Add("@Username", pan);
                command.Parameters.Add("@Password", randomNumber);

                command.Parameters.Add("@Nickname", null);
                command.Parameters.Add("@GUID", null);
                command.Parameters.Add("@EmployeeID", pan);
                command.Parameters.Add("@AlternateID", Adhar);
                command.Parameters.Add("@AlternateID2", null);

                command.Parameters.Add("@AlternateID3", "");
                command.Parameters.Add("@HireDate", "");
                command.Parameters.Add("@SSN", null);
                command.Parameters.Add("@Email", email);
                command.Parameters.Add("@JobTitle", "");
                command.Parameters.Add("@Department", null);

                command.Parameters.Add("@Organization", null);
                command.Parameters.Add("@Location", "");
                command.Parameters.Add("@WorkPhone", tel);
                command.Parameters.Add("@CellPhone", mobile);
                command.Parameters.Add("@Fax", "");

                command.Parameters.Add("@Address", Address);
                command.Parameters.Add("@Address2", "");
                command.Parameters.Add("@City", "");
                command.Parameters.Add("@State", "");
                command.Parameters.Add("@Country", "");

                command.Parameters.Add("@PostalCode", pin);
                command.Parameters.Add("@Active", 1);
                command.Parameters.Add("@PublicPrivate", 0);
                command.Parameters.AddWithValue("@Option1", 0);
                command.Parameters.AddWithValue("@Option2", 0);

                command.Parameters.AddWithValue("@Option3", 0);
                command.Parameters.AddWithValue("@Role0", 0);
                command.Parameters.AddWithValue("@Role1", 0);
                command.Parameters.AddWithValue("@Role2", 1);
                command.Parameters.AddWithValue("@Role3", 0);

                command.Parameters.AddWithValue("@Role4", 0);
                command.Parameters.AddWithValue("@Role5", 0);
                command.Parameters.AddWithValue("@Role6", 0);
                command.Parameters.Add("@LocalDrive", null);
                command.Parameters.Add("@License", null);

                command.Parameters.Add("@Photo", imagename);
                command.Parameters.Add("@Resume", null);
                command.Parameters.Add("@ResAttach", null);
                command.Parameters.Add("@Education", professionalQuali);
                command.Parameters.Add("@WorkExperience", null);

                command.Parameters.Add("@Comments", null);
                command.Parameters.Add("@Reflections", null);
                command.Parameters.Add("@BlogURL", null);
                command.Parameters.Add("@LanguagePreference", 1);
                command.Parameters.Add("@HierarchyID", 0);

                command.Parameters.Add("@StoreFrontID", null);
                command.Parameters.Add("@DisplayExtTrain", 0);
                command.Parameters.Add("@ADGroupName", null);
                command.Parameters.Add("@outStatus", 0);
                command.Parameters["@outStatus"].Direction = ParameterDirection.Output;
                command.ExecuteNonQuery();
                string output = command.Parameters["@outStatus"].Value.ToString();
                cnn.Close();

                EnrolleCourse(_customerId, modulecode, pan);
                string query1 = "SELECT UserID FROM Users WHERE UserName = '" + pan + "'";
                int userid = Getuesrid(query1);
                cnn.Open();
                string query3 = "il_Orders_Order_pri";
                SqlCommand cmd2 = new SqlCommand(query3, cnn);
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.Parameters.Add("@OrgID", "1");
                cmd2.Parameters.Add("@UserID", userid);
                cmd2.Parameters.Add("@FirstName", nameOfCandidate);
                cmd2.Parameters.Add("@LastName", salutation);
                cmd2.Parameters.Add("@BillingAddress", Address);
                cmd2.Parameters.Add("@BillingAddress2", "");
                cmd2.Parameters.Add("@BillingAddress3", "");
                cmd2.Parameters.Add("@BillingCity", "");
                cmd2.Parameters.Add("@BillingState", "");
                cmd2.Parameters.Add("@BillingCountry", "India");
                cmd2.Parameters.Add("@BillingPostalCode", pin);
                cmd2.Parameters.Add("@Phone", mobile);
                cmd2.Parameters.Add("@WorkPhone", tel);
                cmd2.Parameters.Add("@Fax", "");
                cmd2.Parameters.Add("@Email", email);
                cmd2.Parameters.Add("@ShippingAddress", "");
                cmd2.Parameters.Add("@ShippingAddress2", "");
                cmd2.Parameters.Add("@ShippingAddress3", "");
                cmd2.Parameters.Add("@ShippingCity", "");
                cmd2.Parameters.Add("@ShippingState", "");
                cmd2.Parameters.Add("@ShippingCountry", "");
                cmd2.Parameters.Add("@ShippingPostalCode", "");
                cmd2.Parameters.Add("@RemitAddress", "");
                cmd2.Parameters.Add("@OrderPayMethod", 2);
                cmd2.Parameters.Add("@SubTotal", txnAmount);
                cmd2.Parameters.Add("@TotalPurchasePrice", txnAmount);
                cmd2.ExecuteNonQuery();
                cnn.Close();

                string query3courseid = " select CourseID from Courses where CourseCode='" + modulecode + "'";
                int courseid = Getuesrid(query3courseid);
                string query4courseid = " select top(1) orderid from orders where userid='" + userid + "' order by orderid desc";
                int OrderID = Getuesrid(query4courseid);
                cnn.Open();
                string query4 = "il_Orders_OrderItem_pri";
                SqlCommand cmd4 = new SqlCommand(query4, cnn);
                cmd4.CommandType = CommandType.StoredProcedure;
                cmd4.Parameters.Add("@OrgID", "1");
                cmd4.Parameters.Add("@OrderID", OrderID);
                cmd4.Parameters.Add("@Type", 1);
                cmd4.Parameters.Add("@CourseID", courseid);
                cmd4.Parameters.Add("@CourseKey", "");
                cmd4.Parameters.Add("@ItemPrice", txnAmount);
                cmd4.ExecuteNonQuery();
                cnn.Close();


                cnn.Open();
                string query5 = "il_Orders_ProcessStatus_pru";
                SqlCommand cmd5 = new SqlCommand(query5, cnn);
                cmd5.CommandType = CommandType.StoredProcedure;
                cmd5.Parameters.Add("@OrgID", "1");
                cmd5.Parameters.Add("@OrderIDList", OrderID);
                cmd5.Parameters.Add("@Status", 1);
                cmd5.ExecuteNonQuery();
                cnn.Close();

                cnn.Open();
                string query6 = "il_Orders_BillingStatus_pru";
                SqlCommand cmd6 = new SqlCommand(query6, cnn);
                cmd6.CommandType = CommandType.StoredProcedure;
                cmd6.Parameters.Add("@OrgID", "1");
                cmd6.Parameters.Add("@OrderID", OrderID);
                cmd6.Parameters.Add("@Gateway_OrderNumber", txnReferenceNo);
                cmd6.ExecuteNonQuery();

                cnn.Close();

                //mail
                DateTime dt = DateTime.Now;
                dt = dt.AddDays(60);
                string CompletedDate = dt.ToString();
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
                //mailMessage.CC.Add(new MailAddress(From));

                mailMessage.Subject = "NIA Course Registration confirmation";
                //mailMessage.Body = "<html><body> Dear " + nameOfCandidate + ",<br/><br/><br/> Your NIA Registration Process was Completed Successfully.<br/><br/> Please find your Login details:<br/><br/> User Name : " + pan + "<br/>Password : " + randomNumber + "<br/><br/>" +
                //    "Your login URL : <a href=' https://e-learning.niapune.org.in '> https://e-learning.niapune.org.in</a> <br/><br/> The Broking Module Opted for : " + ModuleOpted + "<br/><br/>You can change your password, after login to website by clicking on <b> my profile<b/>.<br/><br/>" +
                //   "Thank You So Much for reposing the trust in us .<br/><br/>Yours <br/> Team NIA <br/> </html></body>";
                mailMessage.Body = "<html><body style='font-family: Helvetica Neue, Helvetica, Arial, sans-serif; font-size: 14px; line-height: 1.42857143; color: #333;' >  Dear " + nameOfCandidate + ",<br /><br />" +
  "  Congratulations! You have now successfully enrolled for the  Online Course for Brokers’ examination.  We heartily welcome you.<br /><br />" +
   " The fact that the classes are  brought to you by the National Insurance Academy, the premier institution for insurance education and the examination body for the brokers in India, makes it unique and special. We thank you for choosing our Course.<br /><br />" +
    "The course is developed to equip the candidates to appear for the Insurance Brokers Examination as prescribed in the IRDAI Regulations.<br /><br />" +
    "The advantage is that this course contains a number of lessons which you can learn at your own pace and convenience at any time of the day. You can also refresh your knowledge by revising those subjects you have already learnt by referring to the Table of Contents and clicking on the relevant topics. You need to complete a  minimum of 50 hours (25 hours for those who satisfy conditions prescribed by IRDAI) of this course to appear for the examination. The time you spent on the lessons will be tracked by the system on a cumulative basis.<br /><br />" +
    "We hope you will have a pleasant learning experience and wish you all the best for your success in the examination.<br /><br /> " +
   "<p style='text-align:right;'> <b> -Team NIA</b></p>" +
    "You can access the course through the following URL: <a href=' https://e-learning.niapune.org.in '> https://e-learning.niapune.org.in</a> <br /><br />" +
    "<b>Your Login id </b> : " + pan + "<br />" +
    "<b> Your Password </b>: " + randomNumber + "<br /><br />" +
    "<b>1.Training portal is video based. Video watching should be completed. Completed status can be seen in course status. Once all the videos  and  survey is completed  certificate will be generated.</b> <br /><br />" +
    "<b>2.Certificate will be generated and downloaded only after 5 days of registration for online training for both, fresh as well as renewal.</b> <br /><br />" +
   //    "<b> Steps to enable flash player in internet explorer </b><br />" +
   //    "<ul><li> Open the page that has the rich media content in Internet Explorer. <br />" +
   //    "</li> <li> Click the Tools menu, in the upper-right corner of Internet Explorer. <br />" +
   //    "</li> <li> From the Tools menu, choose Manage add-ons. <br />" +
   //    "</li> <li> Select Shockwave Flash Object from the list. <br />" +
   //    "</li> <li> Click Enable, and then click Close.</li></ul> <br /><br />" +
   " Please mail to <a href='lms-support@niapune.org.in'>lms-support@niapune.org.in</a> if you face problem to access above" +
    " training module link.<br /><br />" +
    "<b> Availability</b> :<br />" +
    "Please note that the training module will be available up to " + CompletedDate + "  i.e. for 60 days from the date of enrollment. Even if you have downloaded the certificate, training module will be available for 60 days" +
    "from the date of enrollment. After completion of 60 days, the login id will be deactivated" +
    "automatically which cannot be activated / extended in any case.<br /><br />" +

   " <b> Download Training Completion Certificate</b><br />" +

   " You can download the Training Completion Certificate using following link. <br/> <a href=' https://e-learning.niapune.org.in '> https://e-learning.niapune.org.in</a> <br />" +
    "After completion of 50/25 hours training you will be able to get completion certificate on the NIA portal. Go to the My Learning -> View Courses -> Completed Tab then click on the 'Print Certificate'." +
    "<br />  The downloaded certificate is final. You will not get any hard copy of this certificate. <br />" +

      "<h3>Training Module Help</h3><b>TIME CALCULATION</b><br /><ul><li>The basis of completion of the training is number of hours spent by you " +
           " after logging in the training module. The user must complete 50 hours on the course timer to be eligible" +
           " for getting the online training completion certificate. Overall the system will calculate" +
           " the number of hours spent by you in the training module. It is necessary to access" +
           " modules which are relevant to your syllabus. Other modules are optional which can be" +
            " accessed by you if you desire to have additional information.<br />" +
        "</li> <li> The Training module is slides having three characters (One learner and two faculty members). As soon as you begin the training module," +
           " the system will start calculating the time. <br /></li><li> The training module software will keep track of the hours of training. The number of training hours completed will be displayed in My Learning -> Course Status. <br/>" +
        "</li> <li> The following is the list of modules to be completed for the respective training program selected by you. <br /></li>" +
  "<table width='650px' border='1'> <tr> <td>S.No</td>  <td> Training Program Selected</td> <td>	Modules to be completed</td>" +
  "</tr> <tr><td>1.</td><td>Direct Life Insurance Broker</td><td>Compulsory subjects<br />Life Insurance </td> </tr><tr> <td>2.</td>" +
  " <td>Direct General Insurance Broker</td>   <td>Compulsory subjects,  Motor, Marine, Health & Personal Accident, Fire, Engineering, Liability and" +
   " Miscellaneous</td></tr> <tr> <td>3.</td><td>Direct Life & General Insurance Broker</td><td> Compulsory subjects Motor, Marine, Health & Personal Accident," +
   " Fire, Engineering, Liability, Miscellaneous and Life   Insurance </td> </tr> <tr><td>4.</td>  <td>Reinsurance Broker</td>" +
 "<td>Compulsory subjects, Reinsurance </td> </tr> <tr> <td>5.</td><td>Composite Broker</td> <td>  Compulsory subjects, Motor, Marine, Health & Personal Accident," +
 "  Fire, Engineering, Liability, Miscellaneous  Life Insurance  Reinsurance </td> </tr> </table>" +
 "Candidate has to give the grand test after completing 25 hours of training. After completing the grand test certificate will be generated" +
 "<li> Navigation through slides: </li>" +
 "<br/><img width='900px' src='http://e-learning.niapune.org.in/lib/nia_files/helpScreen.PNG'  />" +
"</ul>  <b>SYLLABUS</b> <br /> <a href='http://e-learning.niapune.org.in/courses/Brokers_Syllabus.pdf'>Please Click Here For Syllabus</a>" +
 "   <br /><b>Examination Pattern</b> <br />" +
 "   <a href='http://e-learning.niapune.org.in/nia/BROKERS%20EXAMINATION%20PATTERN.pdf'>Please Click Here For Examination Pattern</a>" +
  "  <br /> <b>Brokers Examination Registration Procedure:</b><br />" +
     "  <p> After the completion of the training, you have to pass the Online Brokers examination conducted by National Insurance Academy (NIA).  For details click on the given link " +
     "<br/> <a href='http://niapune.org.in/examinations/brokers-examination#online-registration-process'>http://niapune.org.in/examinations/brokers-examination#online-registration-process</a>" +

//"  <p> After the completion of the training, you have to pass the Online Brokers examination" +
// "     conducted by National Insurance Academy (NIA), Pune with a minimum of 60% marks to" +
//   "   receive the Brokers certificate which is a mandate for procuring and soliciting business. </p>" +
//  "<p><b>For the registration of brokers examination, you need to follow the below mentioned process:</b></p><p>" +
// "     1) Kindly download the form from the link below and fill and courier/handover the hard" +
//   "   copy to NIA, Pune directly on/before the last date mentioned by NIA.</p>" +
//  "<a href='http://www.niapune.com/brokers_examination.php'>http://www.niapune.com/brokers_examination.php</a>" +
// " <p> Exam Date: The examination date and last date of accepting form for broker" +
//  "    examination will be declared by National Insurance Academy, Pune. </p><b>Required Documents for Examination:</b>" +
//  "<ul> <li> 1. Brokers Examination Form  </li>  <li>   2. Graduation certificate (Attested) </li><li>3. Brokers Training Completion Certificate</li>" +
//   "   <li>4. FeesRs. 2500/- (Plus GST)to be paid to NIA Pune online</li> </ul><h4>Instructions to Fill up Examination Form:</h4>" +
//"<p> please <a href='#'>Click Here</a> to NIA examination form  </p" +


"</body></html>";
                mailMessage.IsBodyHtml = true;
                //smtpClient.Send(mailMessage);
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

            }
            catch (Exception ex)
            {

            }
        }

        private void EnrolleCourse(string _customerId, string modulecode, string pan)
        {
            ////string query1 = "SELECT UserID FROM Users WHERE UserName = '" + pan + "'";
            //string Action = "selectuserid", param = "PANNo";
            //int userid = Getuesrid(Action, pan);
            ////string query3 = " select CourseID from Courses where CourseCode='" + modulecode + "'";
            ////int courseid = Getuesrid(query3);

            //int courseid = Convert.ToInt32(Getuesrid("selectcourseid", modulecode));


            string query1 = "SELECT UserID FROM Users WHERE UserName = '" + pan + "'";
            int userid = Getuesrid(query1);
            string query3 = " select CourseID from Courses where CourseCode='" + modulecode + "'";
            int courseid = Getuesrid(query3);
            DateTime dt = DateTime.Now;
            dt = dt.AddDays(60);

            String query = "il_userCourses_pri";
            cnn.Open();
            SqlCommand command = new SqlCommand(query, cnn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@OrgID", "1");
            command.Parameters.Add("@UserID", userid);
            command.Parameters.Add("@CourseList", courseid);
            command.Parameters.Add("@Role", 2);
            command.Parameters.Add("@Flag", 1);
            command.Parameters.Add("@RequiredByDate", dt);
            command.ExecuteNonQuery();

            cnn.Close();
        }

        //private int Getuesrid(string Action, string paramvalue)
        //{
        //    string userid="";
        //    cnn.Open();
        //    SqlCommand SQLCommand = new SqlCommand("il_NiaApplicants_prd", cnn);
        //    SQLCommand.CommandType = CommandType.StoredProcedure;
        //    SQLCommand.Parameters.Add("@Action", Action);
        //    SQLCommand.Parameters.Add("@PANNo", paramvalue);
        //    SqlDataReader dr = SQLCommand.ExecuteReader();

        //    if (dr.Read())
        //    {
        //        userid = dr["UserID"].ToString();

        //    }
        //    int USRole = Convert.ToInt32(userid);
        //    cnn.Close();
        //    return USRole;
        //}


        private Int32 Getuesrid(string query)
        {
            cnn.Open();
            SqlCommand SQLCommand = new SqlCommand(query, cnn);
            SQLCommand.CommandType = CommandType.Text;

            int USRole = Convert.ToInt32(SQLCommand.ExecuteScalar());
            cnn.Close();
            return USRole;
        }




    }
}