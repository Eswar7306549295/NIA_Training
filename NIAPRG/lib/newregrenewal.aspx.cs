using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI.WebControls;

namespace NIAPRG.lib
{
    public partial class newregrenewal : System.Web.UI.Page
    {
        public string Eq1 = "", Eq2 = "", Eq3 = "", Eq4 = "", Eq5 = "", Eq6 = "", Eq7 = "", Eq8 = "", Eq9 = "", Eq10 = "", Eq11 = "", Eq12 = "", Eq13 = "", Eq14 = "", Eq15 = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            hdnProcess.Value = "FALSE";

            if (!Page.IsPostBack)
            {
                if (Session["Processed"] == null)
                {
                    Session["Processed"] = "TRUE";
                    hdnProcess.Value = "TRUE";
                }
                BindCompany();
            }

        }

        public void BindCompany()
        {

            using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["DSN"]))
            {
                using (SqlCommand cmd = new SqlCommand("Select ID, ltrim(rtrim(Name)) as Name from SponsersMast ORDER BY NAME"))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    con.Open();
                    ddlcompanylist.DataSource = cmd.ExecuteReader();
                    ddlcompanylist.DataTextField = "Name";
                    ddlcompanylist.DataValueField = "ID";
                    ddlcompanylist.DataBind();
                    con.Close();
                }
            }
            ddlcompanylist.Items.Insert(0, new ListItem("Please choose anyone", "0"));
            //ddlcompanylist.Items.Insert(+1, new ListItem("Not Applicable", "999"));

        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            try
            {
                //string dt = Request.Form[txtDob.UniqueID];

                //IFormatProvider culture = new CultureInfo("en-US", true); 
                ////DateTime Dt2 = DateTime.ParseExact(dt, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                //DateTime dateVal = DateTime.ParseExact(dt, "yyyy-MM-dd", culture);
                string str = EduQ();

                if (str.Length > 0)
                {
                    if (CHKagree.Checked)
                    {
                        string username = txtpan.Text;
                        string query1 = "Select id from NiaApplicants where PANNo='" + username + "' and status=1 ";
                        int id = Getuesrid(username, query1);
                        if (id != 0)
                        {
                            txtpan.Focus();
                            this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('User Already Existed with This Pan Number')", true);

                        }
                        else
                        {
                            SqlConnection cnn = new SqlConnection(ConfigurationManager.AppSettings["DSN"]);
                            cnn.Open();
                            //String query = "INSERT INTO NiaApplicants (salutation, [Name],[DateofBirth],[Address],[Pin],[Mobile],[Tel],[EmailID],[PANNo],[AdharCardNo],[CompanyName],[CmpContactPerson],[CmpPhone],[CmpEmailID]," +
                            //   "carryingReinsurance,principalUnderwriter,InsuranceConsultant,ManagerNIA, ProfQualification,Appliedfor,ModuleOpted," +
                            //   "PaymentAmount, status,ModuleCode,Eq1, Eq2, Eq3, Eq4, Eq5, Eq6, Eq7, Eq8, Eq9, Eq10, Eq11, Eq12, Eq13, Eq14, Eq15,CreationDate,Photo,certificate) " +
                            //    " VALUES(@salutation, @Name, @DateofBirth, @Address,@Pin,@Mobile,@Tel,@EmailID,@PANNo,@AdharCardNo,@CompanyName,@CmpContactPerson,@CmpPhone,@CmpEmailID," +
                            //"@carryingReinsurance,@principalUnderwriter,@InsuranceConsultant,@ManagerNIA,@ProfQualification,@Appliedfor," +
                            //"@ModuleOpted, @PaymentAmount,@status,@ModuleCode,@Eq1, @Eq2, @Eq3, @Eq4, @Eq5, @Eq6, @Eq7, @Eq8, @Eq9, @Eq10, @Eq11, @Eq12, @Eq13, @Eq14, @Eq15,getdate(),@Photo,@certificate )";

                            String query = "il_NiaApplicants_prd";
                            SqlCommand command = new SqlCommand(query, cnn);
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.Add("@Action", "insert");
                            command.Parameters.Add("@salutation", ddlsalutation.SelectedItem.Text);
                            command.Parameters.Add("@Name", txtnameOfCandidate.Text.Trim());
                            command.Parameters.Add("@DateofBirth", txtDob.Text);
                            command.Parameters.Add("@Address", txtAddress.Text);
                            command.Parameters.Add("@Pin", txtpin.Text);
                            command.Parameters.Add("@Mobile", txtmobile.Text.Trim());
                            command.Parameters.Add("@Tel", txttel.Text);
                            command.Parameters.Add("@EmailID", txtemail.Text.Trim());
                            command.Parameters.Add("@PANNo", txtpan.Text.Trim());
                            command.Parameters.Add("@AdharCardNo", txtAdhar.Text);
                            command.Parameters.Add("@CompanyName", ddlcompanylist.SelectedItem.Text);
                            command.Parameters.Add("@CmpAddress", txtCmpAddress.Text);
                            command.Parameters.Add("@SpState", ddlstate.SelectedItem.Text);
                            command.Parameters.Add("@SpPin", txtstatePin.Text);
                            command.Parameters.Add("@CmpContactPerson", txtContPerson.Text);
                            command.Parameters.Add("@CmpPhone", txtCmpPhone.Text);
                            command.Parameters.Add("@CmpEmailID", txtcmpEmail.Text);

                            command.Parameters.Add("@carryingReinsurance", ddlreinsuranceReActi.SelectedItem.Text);
                            command.Parameters.Add("@principalUnderwriter", ddlprincipleUnderwriter.SelectedItem.Text);
                            command.Parameters.Add("@InsuranceConsultant", ddlinsuranceConsultant.SelectedItem.Text);
                            command.Parameters.Add("@ManagerNIA", ddlpositionOfManager.SelectedItem.Text);
                            command.Parameters.Add("@ProfQualification", txtprofessionalQuali.Text);
                            //command.Parameters.Add("@Appliedfor", ddlappliedFor.SelectedItem.Text);
                            command.Parameters.Add("@Appliedfor", "");
                            command.Parameters.Add("@ModuleOpted", ddlbrokingModule.SelectedItem.Text);
                            command.Parameters.Add("@PaymentAmount", LBAMT.Text);
                            command.Parameters.Add("@status", "0");
                            command.Parameters.Add("@ModuleCode", ddlbrokingModule.SelectedItem.Value);

                            command.Parameters.Add("@Eq1", Eq1);
                            command.Parameters.Add("@Eq2", Eq2);
                            command.Parameters.Add("@Eq3", Eq3);
                            command.Parameters.Add("@Eq4", Eq4);
                            command.Parameters.Add("@Eq5", Eq5);
                            command.Parameters.Add("@Eq6", Eq6);
                            command.Parameters.Add("@Eq7", Eq7);
                            command.Parameters.Add("@Eq8", Eq8);
                            command.Parameters.Add("@Eq9", Eq9);
                            command.Parameters.Add("@Eq10", Eq10);
                            command.Parameters.Add("@Eq11", Eq11);
                            command.Parameters.Add("@Eq12", Eq12);
                            command.Parameters.Add("@Eq13", Eq13);
                            command.Parameters.Add("@Eq14", Eq14);
                            command.Parameters.Add("@Eq15", Eq15);
                            command.Parameters.Add("@Photo", lbimagename.Text);
                            command.Parameters.Add("@certificate", lbctfname.Text);
                            //command.Parameters.Add("@certificate", "");
                            command.Parameters.Add("@EligibleHours", LbEligibleHours.Text);
                            command.Parameters.Add("@RequiredHours", DdlReqHours.SelectedItem.Text);
                            command.ExecuteNonQuery();
                            cnn.Close();


                            string panno = txtpan.Text;
                            //NIANEW|E0060013170105141441QGV1|NA|2.00|NA|NA|NA|INR|NA|R|nianew|NA|NA|F|9848919134|jxraju@thebostongroup.com|NA|NA|NA|NA|NA|http://e-learning.niapune.org.in/lib/courseordreturn.aspxA4FFD3BA201389B05F732A8288A30BD18CB4F38EC9F44872941AA36C806A0458
                            //NIANEW|NIAREG000000010         |NA|2.00|NA|NA|NA|INR|NA|R|nianew|NA|NA|F|8179469768|xzczx@dfd.ds             |NA|NA|NA|NA|NA|http://e-learning.niapune.org.in/lib/courseordreturn.aspx|7FB41D0B9987FEAC7300D6ACA29A7D8B9420E771AF88E66EB8023FFA0B36D8FD
                            callBillDesk(panno);
                            //  this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('User Successfully Registered')", true);
                        }
                    }
                    else
                    {

                        CHKagree.Focus();
                        this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('please Confirm the Terms and Conditions')", true);
                    }
                }
                else
                {

                    chkCourses.Focus();
                    this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('please select atleast one educational qualification')", true);
                }
            }
            catch (Exception ex)
            {
                LogError(ex);
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
        /// <summary>
        /// this for add payment process..
        /// </summary>
        /// <param name="pan"></param>
        private void callBillDesk(string pan)
        {
            string id = "";
            string PaymentAmount = "", email = "", mobile = "",Name="",PANno="";
            SqlConnection cnn = new SqlConnection(ConfigurationManager.AppSettings["DSN"]);
            cnn.Open();
            string query2 = "select top 1 * from [NiaApplicants] where PANNo='" + pan + "' order by id desc";
            SqlCommand cmd = new SqlCommand(query2, cnn);
            cmd.CommandType = CommandType.Text;
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                int x = Convert.ToInt32(dr["id"]);
                id = x.ToString("000000000000000");
                id = "NIAREG" + id;
                PaymentAmount = dr["PaymentAmount"].ToString();
                email = dr["EmailID"].ToString();
                mobile = dr["Mobile"].ToString();
                Name = dr["Name"].ToString();
                PANno = dr["PANNo"].ToString();


            }
            cnn.Close();
            msg.Text = "NIANEW|" + id + "|NA|" + PaymentAmount + "|NA|NA|NA|INR|NA|R|nianew|NA|NA|F|" + mobile + "|" + email + "|"+ Name +"|"+ PANno +"|NA|NA|NA|http://103.241.144.250/lib/courseordreturn.aspx";
                 Server.Transfer("billdesk.aspx");
            //  raju change       Server.Transfer("courseordreturn.aspx");
        }

        /// <summary>
        /// Add for free registration process
        /// </summary>
        /// <param name="pan"></param>
        //private void callBillDesk1(string pan)
        //{
        //    string id = "";
        //    string PaymentAmount = "", email = "", mobile = "";
        //    SqlConnection cnn = new SqlConnection(ConfigurationManager.AppSettings["DSN"]);
        //    cnn.Open();
        //    string query2 = "select top 1 * from [NiaApplicants] where PANNo='" + pan + "' order by id desc";
        //    SqlCommand cmd = new SqlCommand(query2, cnn);
        //    cmd.CommandType = CommandType.Text;
        //    SqlDataReader dr = cmd.ExecuteReader();

        //    if (dr.Read())
        //    {
        //        int x = Convert.ToInt32(dr["id"]);
        //        id = x.ToString("000000000000000");
        //        id = "NIAREG" + id;
        //        PaymentAmount = dr["PaymentAmount"].ToString();
        //        email = dr["EmailID"].ToString();
        //        mobile = dr["Mobile"].ToString();

        //    }
        //    cnn.Close();
        //    msg.Text = "NIANEW|" + id + "|NA|" + PaymentAmount + "|NA|NA|NA|INR|NA|R|nianew|NA|NA|F|" + mobile + "|" + email + "|NA|NA|NA|NA|NA|http://103.241.144.250/lib/courseordreturn.aspx";
        //    Session["CustmourID"] = id;
        //    // raju change           Server.Transfer("billdesk.aspx");
        //    Server.Transfer("courseordreturn.aspx");
        //}


        private Int32 Getuesrid(string username, string query)
        {

            SqlConnection cnn = new SqlConnection(ConfigurationManager.AppSettings["DSN"]);
            cnn.Open();
            SqlCommand SQLCommand = new SqlCommand(query, cnn);
            SQLCommand.CommandType = CommandType.Text;
            int USRole = Convert.ToInt32(SQLCommand.ExecuteScalar());
            return USRole;
        }



        private string EduQ()
        {
            string str1 = "";
            for (int i = 0; i < chkCourses.Items.Count; i++)
            {
                if (chkCourses.Items[i].Selected)
                {
                    str1 = str1 + "-" + chkCourses.Items[i].Value;
                    if (i + 1 == 1)
                    { Eq1 = "1"; }
                    else if (i + 1 == 2)
                    { Eq2 = "1"; }
                    else if (i + 1 == 3)
                    { Eq3 = "1"; }
                    else if (i + 1 == 4)
                    { Eq4 = "1"; }
                    else if (i + 1 == 5)
                    { Eq5 = "1"; }
                    else if (i + 1 == 6)
                    { Eq6 = "1"; }
                    else if (i + 1 == 7)
                    { Eq7 = "1"; }
                    else if (i + 1 == 8)
                    { Eq8 = "1"; }
                    else if (i + 1 == 9)
                    { Eq9 = "1"; }
                    else if (i + 1 == 10)
                    { Eq10 = "1"; }
                    else if (i + 1 == 11)
                    { Eq11 = "1"; }
                    else if (i + 1 == 12)
                    { Eq12 = "1"; }
                    else if (i + 1 == 13)
                    { Eq13 = "1"; }
                    else if (i + 1 == 14)
                    { Eq14 = "1"; }
                    else if (i + 1 == 15)
                    { Eq15 = "1"; }

                }
            }

            return str1;
        }
        protected void btnimage_Click(object sender, EventArgs e)
        {
            string path = Server.MapPath(".") + "\\niaPhotos\\";
            string filename = System.IO.Path.GetFileName(FlPhoto.PostedFile.FileName);
            if (txtpan.Text != "")
            {
                //5-Get File Exist and if (true)Generate New Name
                //while (System.IO.File.Exists(path + "\\" + filename))
              
                string fullname = txtnameOfCandidate.Text;
                fullname = fullname.Replace(" ", String.Empty);
                string pan = txtpan.Text;
                filename = pan + "_" + fullname + ".jpg";
                string ext = System.IO.Path.GetExtension(this.FlPhoto.PostedFile.FileName);
                //6-Save File to Server
                if (FlPhoto.HasFile)
                {
                    try
                    {
                        if (ext != ".jpg")
                        {
                            lbimage.Text = "";
                            lbimagename.Text = "";
                            this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('Please choose jpg file only')", true);
                        }
                        else
                        {
                            // Set file size limit(in bytes) condition to disable the
                            // users to upload large files. Here 1024 bytes = 1 kilobyte.
                            if (FlPhoto.PostedFile.ContentLength < 30720)
                            {

                                FlPhoto.PostedFile.SaveAs(Server.MapPath("~/lib/niaPhotos") + System.IO.Path.DirectorySeparatorChar + filename);

                                // success message
                                lbimagename.Text = filename;
                                lbimage.Text = "File " + filename + " uploaded successfully.";
                                //  FlCertificate.Focus();
                                CHKagree.Focus();
                            }
                            else
                            {
                                lbimage.Text = "";
                                lbimagename.Text = "";
                                FlPhoto.Focus();
                                this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('File size of " + Convert.ToString(FlPhoto.PostedFile.ContentLength / 1024) + " KB is exceeding the uploading limit.')", true);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        lbimage.Text = "";
                        lbimagename.Text = "";
                        FlPhoto.Focus();
                        this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('Please choose a file to upload')", true);
                    }
                }
                else
                {
                    // warning message
                    lbimage.Text = "";
                    lbimagename.Text = "";
                    FlPhoto.Focus();
                    this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('Please choose a file to upload')", true);

                }
            }
            else
            {
                this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('Please Enter Your pan Number')", true);
                txtpan.Focus();
            }
        }

        protected void ddlreinsuranceReActi_SelectedIndexChanged(object sender, EventArgs e)
        {
        ////    if ((ddlreinsuranceReActi.SelectedItem.Text == "Yes") || (ddlprincipleUnderwriter.SelectedItem.Text == "Yes") || (ddlinsuranceConsultant.SelectedItem.Text == "Yes") || (ddlpositionOfManager.SelectedItem.Text == "Yes"))
        ////    {
        ////        LbEligibleHours.Text = "25 Hours";
        ////        DdlReqHours.SelectedIndex = 0;
        ////        DdlReqHours.Enabled = true;
        ////        DdlReqHours.Focus();
        ////    }
        ////    else
        ////    {
        ////        LbEligibleHours.Text = "25 Hours";
        ////        DdlReqHours.SelectedIndex = 0;
        ////        DdlReqHours.Enabled = false;
        ////        DdlReqHours.Focus();
        ////    }
        }
        /// <summary>
        /// this is for registration process btn event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnregister_Click(object sender, EventArgs e)
        {
            try
            {
                //string dt = Request.Form[txtDob.UniqueID];

                //IFormatProvider culture = new CultureInfo("en-US", true); 
                ////DateTime Dt2 = DateTime.ParseExact(dt, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                //DateTime dateVal = DateTime.ParseExact(dt, "yyyy-MM-dd", culture);
                string str = EduQ();

                if (str.Length > 0)
                {
                    if (CHKagree.Checked)
                    {
                        string username = txtpan.Text;
                        string query1 = "Select id from NiaApplicants where PANNo='" + username + "' and status=1 ";
                        int id = Getuesrid(username, query1);
                        if (id != 0)
                        {
                            txtpan.Focus();
                            this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('User already existed with this PAN number')", true);

                        }
                        else
                        {
                            SqlConnection cnn = new SqlConnection(ConfigurationManager.AppSettings["DSN"]);
                            cnn.Open();
                            //String query = "INSERT INTO NiaApplicants (salutation, [Name],[DateofBirth],[Address],[Pin],[Mobile],[Tel],[EmailID],[PANNo],[AdharCardNo],[CompanyName],[CmpContactPerson],[CmpPhone],[CmpEmailID]," +
                            //   "carryingReinsurance,principalUnderwriter,InsuranceConsultant,ManagerNIA, ProfQualification,Appliedfor,ModuleOpted," +
                            //   "PaymentAmount, status,ModuleCode,Eq1, Eq2, Eq3, Eq4, Eq5, Eq6, Eq7, Eq8, Eq9, Eq10, Eq11, Eq12, Eq13, Eq14, Eq15,CreationDate,Photo,certificate) " +
                            //    " VALUES(@salutation, @Name, @DateofBirth, @Address,@Pin,@Mobile,@Tel,@EmailID,@PANNo,@AdharCardNo,@CompanyName,@CmpContactPerson,@CmpPhone,@CmpEmailID," +
                            //"@carryingReinsurance,@principalUnderwriter,@InsuranceConsultant,@ManagerNIA,@ProfQualification,@Appliedfor," +
                            //"@ModuleOpted, @PaymentAmount,@status,@ModuleCode,@Eq1, @Eq2, @Eq3, @Eq4, @Eq5, @Eq6, @Eq7, @Eq8, @Eq9, @Eq10, @Eq11, @Eq12, @Eq13, @Eq14, @Eq15,getdate(),@Photo,@certificate )";

                            String query = "il_NiaApplicants_prd";
                            SqlCommand command = new SqlCommand(query, cnn);
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.Add("@Action", "insert");
                            command.Parameters.Add("@salutation", ddlsalutation.SelectedItem.Text);
                            command.Parameters.Add("@Name", txtnameOfCandidate.Text);
                            command.Parameters.Add("@DateofBirth", txtDob.Text);
                            command.Parameters.Add("@Address", txtAddress.Text);
                            command.Parameters.Add("@Pin", txtpin.Text);
                            command.Parameters.Add("@Mobile", txtmobile.Text);
                            command.Parameters.Add("@Tel", txttel.Text);
                            command.Parameters.Add("@EmailID", txtemail.Text);
                            command.Parameters.Add("@PANNo", txtpan.Text);
                            command.Parameters.Add("@AdharCardNo", txtAdhar.Text);
                            command.Parameters.Add("@CompanyName", ddlcompanylist.SelectedItem.Text);
                            command.Parameters.Add("@CmpAddress", txtCmpAddress.Text);
                            command.Parameters.Add("@SpState", ddlstate.SelectedItem.Text);
                            command.Parameters.Add("@SpPin", txtstatePin.Text);
                            command.Parameters.Add("@CmpContactPerson", txtContPerson.Text);
                            command.Parameters.Add("@CmpPhone", txtCmpPhone.Text);
                            command.Parameters.Add("@CmpEmailID", txtcmpEmail.Text);
                            command.Parameters.Add("@carryingReinsurance", ddlreinsuranceReActi.SelectedItem.Text);
                            command.Parameters.Add("@principalUnderwriter", ddlprincipleUnderwriter.SelectedItem.Text);
                            command.Parameters.Add("@InsuranceConsultant", ddlinsuranceConsultant.SelectedItem.Text);
                            command.Parameters.Add("@ManagerNIA", ddlpositionOfManager.SelectedItem.Text);
                            command.Parameters.Add("@ProfQualification", txtprofessionalQuali.Text);
                            //command.Parameters.Add("@Appliedfor", ddlappliedFor.SelectedItem.Text);
                            command.Parameters.Add("@Appliedfor", "");
                            command.Parameters.Add("@ModuleOpted", ddlbrokingModule.SelectedItem.Text);
                            command.Parameters.Add("@PaymentAmount", LBAMT.Text);
                            command.Parameters.Add("@status", "0");
                            command.Parameters.Add("@ModuleCode", ddlbrokingModule.SelectedItem.Value);
                            command.Parameters.Add("@Eq1", Eq1);
                            command.Parameters.Add("@Eq2", Eq2);
                            command.Parameters.Add("@Eq3", Eq3);
                            command.Parameters.Add("@Eq4", Eq4);
                            command.Parameters.Add("@Eq5", Eq5);
                            command.Parameters.Add("@Eq6", Eq6);
                            command.Parameters.Add("@Eq7", Eq7);
                            command.Parameters.Add("@Eq8", Eq8);
                            command.Parameters.Add("@Eq9", Eq9);
                            command.Parameters.Add("@Eq10", Eq10);
                            command.Parameters.Add("@Eq11", Eq11);
                            command.Parameters.Add("@Eq12", Eq12);
                            command.Parameters.Add("@Eq13", Eq13);
                            command.Parameters.Add("@Eq14", Eq14);
                            command.Parameters.Add("@Eq15", Eq15);
                            command.Parameters.Add("@Photo", lbimagename.Text);
                            command.Parameters.Add("@certificate", lbctfname.Text);
//                            command.Parameters.Add("@certificate", "");
                            command.Parameters.Add("@EligibleHours", LbEligibleHours.Text);
                            command.Parameters.Add("@RequiredHours", DdlReqHours.SelectedItem.Text);
                            command.ExecuteNonQuery();
                            cnn.Close();


                            string panno = txtpan.Text;
                            //NIANEW|E0060013170105141441QGV1|NA|2.00|NA|NA|NA|INR|NA|R|nianew|NA|NA|F|9848919134|jxraju@thebostongroup.com|NA|NA|NA|NA|NA|http://e-learning.niapune.org.in/lib/courseordreturn.aspxA4FFD3BA201389B05F732A8288A30BD18CB4F38EC9F44872941AA36C806A0458
                            //NIANEW|NIAREG000000010         |NA|2.00|NA|NA|NA|INR|NA|R|nianew|NA|NA|F|8179469768|xzczx@dfd.ds             |NA|NA|NA|NA|NA|http://e-learning.niapune.org.in/lib/courseordreturn.aspx|7FB41D0B9987FEAC7300D6ACA29A7D8B9420E771AF88E66EB8023FFA0B36D8FD
                            callBillDesk(panno);
                            //  this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('User Successfully Registered')", true);
                        }
                    }
                    else
                    {

                        CHKagree.Focus();
                        this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('please Confirm the Terms and Conditions')", true);
                    }
                }
                else
                {

                    chkCourses.Focus();
                    this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('please select atleast one educational qualification')", true);
                }
            }
            catch (Exception ex)
            {
                LogError(ex);
            }

        }
        protected void btncetf_Click(object sender, EventArgs e)
        {
            string path = Server.MapPath(".") + "\\niaPdf\\";
            string filename = System.IO.Path.GetFileName(FlCertificate.PostedFile.FileName);
            //while (System.IO.File.Exists(path + "\\" + filename))
            //    filename = "1" + filename;
            if (txtpan.Text != "")
            {
                string pan = txtpan.Text;
                filename = pan + filename;
                string ext = System.IO.Path.GetExtension(this.FlCertificate.PostedFile.FileName);
                if (FlCertificate.HasFile)
                {

                    if (ext != ".pdf")
                    {
                        lbctf.Text = "";
                        lbctfname.Text = "";
                        FlCertificate.Focus();
                        this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('Please choose pdf file only')", true);
                    }
                    else
                    {
                        FlCertificate.PostedFile.SaveAs(Server.MapPath("~/lib/niaPdf") + System.IO.Path.DirectorySeparatorChar + filename);
                        lbctfname.Text = filename;
                        lbctf.Text = "File " + filename + " uploaded successfully.";
                        CHKagree.Focus();
                    }

                }
                else
                {
                    // warning message
                    lbctf.Text = "";
                    lbctfname.Text = "";
                    this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('Please choose a file to upload')", true);
                    FlCertificate.Focus();
                }
            }
            else
            {
                this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('Please Enter Your pan Number')", true);
                txtpan.Focus();
            }
        }


    }
}