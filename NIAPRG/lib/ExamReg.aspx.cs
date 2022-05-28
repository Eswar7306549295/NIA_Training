using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web.Services;

namespace NIAPRG.lib
{
    public partial class ExamReg : System.Web.UI.Page
    {
        public string Eq1 = "", Eq2 = "", Eq3 = "", Eq4 = "", Eq5 = "", Eq6 = "", Eq7 = "", Eq8 = "", Eq9 = "", Eq10 = "", Eq11 = "", Eq12 = "", Eq13 = "", Eq14 = "", Eq15 = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                btnUpdate.Visible = false;
            }
           

        }


        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetState(string prefixText)
        {
            DataTable dt = new DataTable();

            string constr = ConfigurationManager.AppSettings["DSN"].ToString();
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("select name from [NiaApplicants]  where Name like @City+'%'", con);
            cmd.Parameters.AddWithValue("@City", prefixText);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(dt);
            List<string> CityNames = new List<string>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                CityNames.Add(dt.Rows[i][0].ToString());
            }
           // List<string> CityNames = new List<string>();

           // // Add items using Add method 
           // CityNames.Add("Andhra Pradesh");
           // CityNames.Add("Arunachal Pradesh");
           // CityNames.Add("Assam ");
           // CityNames.Add("Bihar ");
           // CityNames.Add("Goa ");
           // CityNames.Add("Gujarat ");
           // CityNames.Add("Haryana ");
           // CityNames.Add("Himachal Pradesh");
           // CityNames.Add("Jammu & Kashmir");
           // CityNames.Add("Karnataka ");
           // CityNames.Add("Kerala ");
           // CityNames.Add("Nipun");
           // CityNames.Add("Madhya Pradesh");
           // CityNames.Add("Maharashtra");
           // CityNames.Add("Manipur");
           // CityNames.Add("Meghalaya ");
           // CityNames.Add("Mizoram ");
           // CityNames.Add("Nagaland ");
           // CityNames.Add("Orissa ");
           // CityNames.Add("Punjab ");
           // CityNames.Add("Rajasthan ");
           // CityNames.Add("Sikkim ");
           // CityNames.Add("Tamil Nadu");
           // CityNames.Add("Tripura");
           // CityNames.Add("Uttar Pradesh");
           // CityNames.Add("West Bengal");
           // CityNames.Add("Chhattisgarh ");
           // CityNames.Add("Uttarakhand ");
           // CityNames.Add("Jharkhand ");
           // CityNames.Add("Telangana ");

           //// CityNames = CityNames.Contains(prefixText).ToList();
            return CityNames;
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
                            DateTime dt = DateTime.Now;
                            dt = dt.AddMonths(6);
                            string CompletedDate = dt.ToString();
                            SqlConnection cnn = new SqlConnection(ConfigurationManager.AppSettings["DSN"]);
                            cnn.Open();

                            String query = "il_NiaApplicants_pru";
                            SqlCommand command = new SqlCommand(query, cnn);
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.Add("@Action", 2);
                            command.Parameters.Add("@salutation", ddlsalutation.SelectedItem.Text);
                            command.Parameters.Add("@Name", txtnameOfCandidate.Text);
                            command.Parameters.Add("@DateofBirth", txtDob.Text);
                            command.Parameters.Add("@Address", txtAddress.Text);
                            command.Parameters.Add("@state", ddlstate.SelectedItem.Text);
                            command.Parameters.Add("@Pin", txtpin.Text);
                            command.Parameters.Add("@Mobile", txtmobile.Text);
                            command.Parameters.Add("@Tel", txttel.Text);
                            command.Parameters.Add("@EmailID", txtemail.Text);
                            command.Parameters.Add("@PANNo", txtpan.Text);
                            command.Parameters.Add("@AdharCardNo", txtAdhar.Text);
                            command.Parameters.Add("@CompanyName", ddlcompanylist.SelectedItem.Text);
                            command.Parameters.Add("@CmpAddress", txtCmpAddress.Text);
                            command.Parameters.Add("@CmpContactPerson", txtContPerson.Text);
                            command.Parameters.Add("@CmpPhone", txtCmpPhone.Text);
                            command.Parameters.Add("@CmpEmailID", txtcmpEmail.Text);
                            command.Parameters.Add("@carryingReinsurance", ddlreinsuranceReActi.SelectedItem.Text);
                            command.Parameters.Add("@principalUnderwriter", ddlprincipleUnderwriter.SelectedItem.Text);
                            command.Parameters.Add("@InsuranceConsultant", ddlinsuranceConsultant.SelectedItem.Text);
                            command.Parameters.Add("@ManagerNIA", ddlpositionOfManager.SelectedItem.Text);
                            command.Parameters.Add("@ProfQualification", txtprofessionalQuali.Text);
                            command.Parameters.Add("@Appliedfor", ddlappliedFor.SelectedItem.Text);
                            command.Parameters.Add("@completiondate", CompletedDate);
                            command.Parameters.Add("@ModuleOpted", ddlbrokingModule.SelectedItem.Text);
                            command.Parameters.Add("@PaymentAmount", LBAMT.Text);
                            command.Parameters.Add("@status", "3");
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
                            // command.Parameters.Add("@certificate", lbctfname.Text); 
                            command.Parameters.Add("@certificate", lbctfname.Text);
                            //command.Parameters.Add("@EligibleHours", LbEligibleHours.Text);
                            command.Parameters.Add("@RequiredHours", DdlReqHours.SelectedItem.Text);
                            command.Parameters.Add("@TrainingId", txttrainingId.Text);
                            command.Parameters.Add("@ExamCentre", ddlExamCentre.SelectedItem.Text);
                            command.Parameters.Add("@NoAttempts", txtNoAttempts.Text);
                            command.Parameters.Add("@SpState", ddlSponsorState.SelectedItem.Text);
                            command.Parameters.Add("@SpPin", TxtSponsorPin.Text);
                            command.Parameters.Add("@insurancebackground", ddlinsurance.SelectedItem.Text);
                            command.ExecuteNonQuery();
                            cnn.Close();
                            string panno = txtpan.Text;
                            //NIANEW|E0060013170105141441QGV1|NA|2.00|NA|NA|NA|INR|NA|R|nianew|NA|NA|F|9848919134|jxraju@thebostongroup.com|NA|NA|NA|NA|NA|http://e-learning.niapune.org.in/lib/courseordreturn.aspxA4FFD3BA201389B05F732A8288A30BD18CB4F38EC9F44872941AA36C806A0458
                            //NIANEW|NIAREG000000010         |NA|2.00|NA|NA|NA|INR|NA|R|nianew|NA|NA|F|8179469768|xzczx@dfd.ds             |NA|NA|NA|NA|NA|http://e-learning.niapune.org.in/lib/courseordreturn.aspx|7FB41D0B9987FEAC7300D6ACA29A7D8B9420E771AF88E66EB8023FFA0B36D8FD
                            callBillDesk(panno);
                             this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('User Successfully Registered')", true);
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

        private void callBillDesk(string pan)
        {
            string id = "";
            string PaymentAmount = "", email = "", mobile = "";
            SqlConnection cnn = new SqlConnection(ConfigurationManager.AppSettings["DSN"]);
            cnn.Open();
            string query2 = "select * from [NiaApplicants] where PANNo='" + pan + "' ";
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

            }
            cnn.Close();
            //NIANEW|NIAREG000000010         |NA|2.00|NA|NA|NA|INR|NA|R|nianew|NA|NA|F|8179469768|xzczx@dfd.ds             |NA|NA|NA|NA|NA|http://e-learning.niapune.org.in/lib/courseordreturn.aspx|7FB41D0B9987FEAC7300D6ACA29A7D8B9420E771AF88E66EB8023FFA0B36D8FD
                          
            msg.Text = "NIABRKR|" + id + "|NA|" + PaymentAmount + "|NA|NA|NA|INR|NA|R|niabrkr|NA|NA|F|" + mobile + "|" + email + "|NA|NA|NA|NA|NA|http://103.241.144.250/lib/examordreturn.aspx";
            Server.Transfer("ExamBillDesk.aspx");

        }

        private Int32 Getuesrid(string username, string query)
        {

            SqlConnection cnn = new SqlConnection(ConfigurationManager.AppSettings["DSN"]);
            cnn.Open();
            SqlCommand SQLCommand = new SqlCommand(query, cnn);
            SQLCommand.CommandType = CommandType.Text;
            int USRole = Convert.ToInt32(SQLCommand.ExecuteScalar());
            cnn.Close();
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
                if (txtnameOfCandidate.Text != "")
                {
                    string fullname = txtnameOfCandidate.Text;
                    fullname = fullname.Replace(" ", String.Empty);
                    string pan = txtpan.Text;
                    filename = fullname + "_" + pan + ".jpeg";

                   

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
                                this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('Please choose jpg photo file only')", true);
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
            }
            else
            {
                this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('Please Enter Your pan Number')", true);
                txtpan.Focus();
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
                if (txtnameOfCandidate.Text != "")
                {
                    string fullname = txtnameOfCandidate.Text;
                    fullname = fullname.Replace(" ", String.Empty);
                    string pan = txtpan.Text;
                    filename = fullname + "_" + pan + ".pdf";
                    string ext = System.IO.Path.GetExtension(this.FlCertificate.PostedFile.FileName);
                    if (FlCertificate.HasFile)
                    {

                        if (ext != ".pdf")
                        {
                            lbctf.Text = "";
                            lbctfname.Text = "";
                            FlCertificate.Focus();
                            this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('Please choose Training certificate file to be in PDF format only')", true);
                        }
                        else
                        {
                            if (FlPhoto.PostedFile.ContentLength < 102400)
                            {
                                FlCertificate.PostedFile.SaveAs(Server.MapPath("~/lib/niaPdf") + System.IO.Path.DirectorySeparatorChar + filename);
                                lbctfname.Text = filename;
                                lbctf.Text = "File " + filename + " uploaded successfully.";
                                CHKagree.Focus();
                            }
                            else
                            {
                                lbctf.Text = "";
                                lbctfname.Text = "";
                                FlCertificate.Focus();
                                this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('Please choose Training certificate file to be in 100kb only')", true);
             
                            }
                        }

                    }
                    else
                    {
                        // warning message
                        lbctf.Text = "";
                        lbctfname.Text = "";
                        this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('Please choose  Training certificate file to upload')", true);
                        FlCertificate.Focus();
                    }
                }
                else
                {
                    this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('Please Enter Your Full Name')", true);
                    txtpan.Focus();
                }
            }
            else
            {
                this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('Please Enter Your pan Number')", true);
                txtpan.Focus();
            }
        }

        protected void txtpan_TextChanged(object sender, EventArgs e)
        {
            //CQLPK7823N
            string username = txtpan.Text;
            string query1 = "Select id from NiaApplicants where PANNo='" + username + "' and LTRIM(RTRIM(status))=1 ";
            int id = Getuesrid(username, query1);
            if (id != 0)
            {
                btnsubmit.Visible = false;
                btnUpdate.Visible = true;
                //string query2 = "select  top(1)* from NiaApplicants where id=" + id + " order by id desc ";
                String query2 = "il_NiaApplicants_prd";
                SqlConnection cnn = new SqlConnection(ConfigurationManager.AppSettings["DSN"]);
                cnn.Open();
                SqlCommand cmd = new SqlCommand(query2, cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Action", "selectid");
                cmd.Parameters.Add("@id", id);
                SqlDataReader dr = cmd.ExecuteReader();
                
                if (dr.Read())
                {
                    txtnameOfCandidate.Text = dr["Name"].ToString();
                    ddlsalutation.SelectedItem.Text = dr["salutation"].ToString();
                    txtpan.Text = dr["PANNo"].ToString();
                    txtemail.Text = dr["EmailID"].ToString();
                    txtDob.Text = dr["DateofBirth"].ToString();
                    txtAddress.Text = dr["Address"].ToString();
                    txtpin.Text = dr["Pin"].ToString();
                    txtmobile.Text = dr["Mobile"].ToString();
                    txttel.Text = dr["Tel"].ToString();
                    txtemail.Text = dr["EmailID"].ToString();
                    txtpan.Text = dr["PANNo"].ToString();
                    txtAdhar.Text = dr["AdharCardNo"].ToString();
                   ddlcompanylist.SelectedValue = dr["CompanyName"].ToString();
                    txtContPerson.Text = dr["CmpContactPerson"].ToString();
                    txtCmpPhone.Text = dr["CmpPhone"].ToString();
                    txtcmpEmail.Text = dr["CmpEmailID"].ToString();                   
                    txtprofessionalQuali.Text = dr["ProfQualification"].ToString();                  
                    LBAMT.Text = dr["PaymentAmount"].ToString();                   
                    ddlreinsuranceReActi.SelectedIndex = ddlreinsuranceReActi.Items.IndexOf(ddlreinsuranceReActi.Items.FindByText(dr["carryingReinsurance"].ToString()));
                    ddlprincipleUnderwriter.SelectedIndex = ddlprincipleUnderwriter.Items.IndexOf(ddlprincipleUnderwriter.Items.FindByText(dr["principalUnderwriter"].ToString()));
                    ddlinsuranceConsultant.SelectedIndex = ddlinsuranceConsultant.Items.IndexOf(ddlinsuranceConsultant.Items.FindByText(dr["InsuranceConsultant"].ToString()));
                    ddlpositionOfManager.SelectedIndex = ddlpositionOfManager.Items.IndexOf(ddlpositionOfManager.Items.FindByText(dr["ManagerNIA"].ToString()));
                    ddlbrokingModule.SelectedIndex = ddlbrokingModule.Items.IndexOf(ddlbrokingModule.Items.FindByValue(dr["ModuleCode"].ToString()));

                    Eq1 = dr["Eq1"].ToString();
                    Eq2 = dr["Eq2"].ToString();
                    Eq3 = dr["Eq3"].ToString();
                    Eq4 = dr["Eq4"].ToString();
                    Eq5 = dr["Eq5"].ToString();
                    Eq6 = dr["Eq6"].ToString();
                    Eq7 = dr["Eq7"].ToString();
                    Eq8 = dr["Eq8"].ToString();
                    Eq9 = dr["Eq9"].ToString();
                    Eq10 = dr["Eq10"].ToString();
                    Eq11 = dr["Eq11"].ToString();
                    Eq12 = dr["Eq12"].ToString();
                    Eq13 = dr["Eq13"].ToString();
                    Eq14 = dr["Eq14"].ToString();
                    Eq15 = dr["Eq15"].ToString();

                    if (Eq11.Trim() == "1")
                    {
                        chkCourses.Items[0].Selected = true;
                    }
                    if (Eq2.Trim() == "1")
                    {
                        chkCourses.Items[1].Selected = true;
                    }
                    if (Eq3.Trim() == "1")
                    {
                        chkCourses.Items[2].Selected = true;
                        
                    }
                    if (Eq4.Trim() == "1")
                    {
                        chkCourses.Items[3].Selected = true;
                    }
                    if (Eq5.Trim() == "1")
                    {
                        chkCourses.Items[4].Selected = true;
                    }
                    if (Eq6.Trim() == "1")
                    {
                        chkCourses.Items[5].Selected = true;
                    }
                    if (Eq7.Trim() == "1")
                    {
                        chkCourses.Items[6].Selected = true;
                    }
                    if (Eq8.Trim() == "1")
                    {
                        chkCourses.Items[7].Selected = true;
                    }
                    if (Eq9.Trim() == "1")
                    {
                        chkCourses.Items[8].Selected = true;
                    }
                    if (Eq10.Trim() == "1")
                    {
                        chkCourses.Items[9].Selected = true;
                    }
                    if (Eq11.Trim() == "1")
                    {
                        chkCourses.Items[10].Selected = true;
                    }
                    if (Eq12.Trim() == "1")
                    {
                        chkCourses.Items[11].Selected = true;
                    }
                    if (Eq13.Trim() == "1")
                    {
                        chkCourses.Items[12].Selected = true;

                    }
                    if (Eq14.Trim() == "1")
                    {
                        chkCourses.Items[13].Selected = true;

                    }
                    if (Eq15.Trim() == "1")
                    {
                        chkCourses.Items[14].Selected = true;
                    }
                    lbimage.Text = "File " + dr["Photo"].ToString() + " uploaded successfully.";
                    lbimagename.Text = dr["Photo"].ToString();

                }

                cnn.Close();
            }
            else
            {
                btnsubmit.Visible = true;
                btnUpdate.Visible = false;
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {

                //pwd  CtzenN7H@4c$
               
                string str = EduQ();
                DateTime dt = DateTime.Now;
                dt = dt.AddMonths(6);
                string CompletedDate = dt.ToString();
                if (str.Length > 0)
                {
                    if (CHKagree.Checked)
                    {
                        string username = txtpan.Text;
                        string query1 = "Select id from NiaApplicants where PANNo='" + username + "' and status=1 ";
                        int id = Getuesrid(username, query1);
                        if (id != 0)
                        {
                            //txtpan.Focus();
                            //this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('User Already Existed with This Pan Number')", true);
                            SqlConnection cnn = new SqlConnection(ConfigurationManager.AppSettings["DSN"]);
                            cnn.Open();
                            String query = "il_NiaApplicants_pru";
                            SqlCommand command = new SqlCommand(query, cnn);
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.Add("@Action", 1);
                            command.Parameters.Add("@id", id);
                            command.Parameters.Add("@salutation", ddlsalutation.SelectedItem.Text);
                            command.Parameters.Add("@Name", txtnameOfCandidate.Text);
                            command.Parameters.Add("@DateofBirth", txtDob.Text);
                            command.Parameters.Add("@Address", txtAddress.Text);
                            command.Parameters.Add("@state", ddlstate.SelectedItem.Text);
                            command.Parameters.Add("@Pin", txtpin.Text);
                            command.Parameters.Add("@Mobile", txtmobile.Text);
                            command.Parameters.Add("@Tel", txttel.Text);
                            command.Parameters.Add("@EmailID", txtemail.Text);
                            command.Parameters.Add("@PANNo", txtpan.Text);
                            command.Parameters.Add("@AdharCardNo", txtAdhar.Text);
                            command.Parameters.Add("@CompanyName", ddlstate.SelectedItem.Text);
                            command.Parameters.Add("@CmpAddress", txtCmpAddress.Text);
                            command.Parameters.Add("@CmpContactPerson", txtContPerson.Text);
                            command.Parameters.Add("@CmpPhone", txtCmpPhone.Text);
                            command.Parameters.Add("@CmpEmailID", txtcmpEmail.Text);
                            command.Parameters.Add("@carryingReinsurance", ddlreinsuranceReActi.SelectedItem.Text);
                            command.Parameters.Add("@principalUnderwriter", ddlprincipleUnderwriter.SelectedItem.Text);
                            command.Parameters.Add("@InsuranceConsultant", ddlinsuranceConsultant.SelectedItem.Text);
                            command.Parameters.Add("@ManagerNIA", ddlpositionOfManager.SelectedItem.Text);
                            command.Parameters.Add("@ProfQualification", txtprofessionalQuali.Text);
                            command.Parameters.Add("@Appliedfor", ddlappliedFor.SelectedItem.Text);
                            command.Parameters.Add("@completiondate", CompletedDate);
                            command.Parameters.Add("@ModuleOpted", ddlbrokingModule.SelectedItem.Text);
                            command.Parameters.Add("@PaymentAmount", LBAMT.Text);
                            command.Parameters.Add("@status", "2");
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
                            // command.Parameters.Add("@certificate", lbctfname.Text); NoAttempts

                            command.Parameters.Add("@certificate", lbctfname.Text);
                            //command.Parameters.Add("@EligibleHours", LbEligibleHours.Text);
                            command.Parameters.Add("@RequiredHours", DdlReqHours.SelectedItem.Text);
                            command.Parameters.Add("@TrainingId", txttrainingId.Text);
                            command.Parameters.Add("@ExamCentre", ddlExamCentre.SelectedItem.Text);
                            command.Parameters.Add("@NoAttempts", txtNoAttempts.Text);
                            command.Parameters.Add("@SpState", ddlstate.SelectedItem.Text);
                            command.Parameters.Add("@SpPin", TxtSponsorPin.Text);
                            command.Parameters.Add("@insurancebackground", ddlinsurance.SelectedItem.Text);
                            command.ExecuteNonQuery();
                            cnn.Close();
                            this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('User Successfully Registered')", true);
                            string panno = txtpan.Text;
                            // callBillDesk(panno);SpPin

                            callBillDesk(panno);
                        }
                        else
                        {
                            
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

        //protected void ddlreinsuranceReActi_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if ((ddlreinsuranceReActi.SelectedItem.Text == "Yes") || (ddlprincipleUnderwriter.SelectedItem.Text == "Yes") || (ddlinsuranceConsultant.SelectedItem.Text == "Yes") || (ddlpositionOfManager.SelectedItem.Text == "Yes"))
        //    {
        //        LbEligibleHours.Text = "25 Hours";
        //        DdlReqHours.SelectedIndex = 0;
        //        DdlReqHours.Enabled = true;
        //        DdlReqHours.Focus();
        //    }
        //    else
        //    {
        //        LbEligibleHours.Text = "50 Hours";
        //        DdlReqHours.SelectedIndex = 1;
        //        DdlReqHours.Enabled = false;
        //        txttrainingId.Focus();
        //    }
        //}

        protected void ddlEarlierExam_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlEarlierExam.SelectedItem.Text == "Yes")
            {
                txtNoAttempts.Text = "";
                txtNoAttempts.ReadOnly = false;
                txtNoAttempts.Focus();
            }
            else
            {
                ddlEarlierExam.Focus();
                txtNoAttempts.Text = "0";
                txtNoAttempts.ReadOnly = true;
            }
        }
    }
}