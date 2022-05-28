using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NIAPRGExams.exam
{
    public partial class TrgDashbordEdit : System.Web.UI.Page
    {
        SqlConnection cnn = new SqlConnection(ConfigurationManager.AppSettings["DSN"]);
        DataTable dt = new DataTable();

        public string Eq1 = "", Eq2 = "", Eq3 = "", Eq4 = "", Eq5 = "", Eq6 = "", Eq7 = "", Eq8 = "", Eq9 = "", Eq10 = "", Eq11 = "", Eq12 = "", Eq13 = "", Eq14 = "", Eq15 = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCompany();
                BindSponsorState();
                BindState();
                BindExamCenter();
                string id = Request.QueryString["Id"];
                string logname = Convert.ToString(Session["Name"]);

                //if (logname != null && logname != string.Empty)
                //{
                    //if (id != null && id != string.Empty)
                    //{
                        cnn.Open();
                        using (SqlCommand cmd = new SqlCommand("select * from NiaApplicants where id='" + id + "'", cnn))
                        {

                            cmd.CommandType = CommandType.Text;
                            SqlDataReader dr = cmd.ExecuteReader();
                            dt.Load(dr);
                            cnn.Close();

                        }

                        if (dt.Rows.Count == 0)
                        {
                            //if not data -  Data is not available  - Action is close page.
                            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Data is not available ');window.close();", true);
                        }
                        else
                        {
                            txtpan.Text = Convert.ToString(dt.Rows[0]["PANNo"]);
                            txtpan.ReadOnly = true;
                            //txtpan.Enabled = true;


                            if (dt.Rows[0]["salutation"] != DBNull.Value && Convert.ToString(dt.Rows[0]["salutation"]) != null && Convert.ToString(dt.Rows[0]["salutation"]) != string.Empty)
                            {
                                if (ddlsalutation.Items.FindByText(Convert.ToString(dt.Rows[0]["salutation"]).Trim()) != null)
                                {
                                    ddlsalutation.Items.FindByText(Convert.ToString(dt.Rows[0]["salutation"]).Trim()).Selected = true;
                                }
                            }

                            //ddlsalutation.SelectedItem.Text = Convert.ToString(dt.Rows[0]["salutation"]);
                            // in text box Convert.ToString can handle NUll but .ToString() rasies error..
                            // easy step is FindByValue(real time going on.) we need to insert values instead of text in database.then desinging also we need writre values for Value property of list item. for that value automatically select or Set a Text in Dropdown 

                            txtnameOfCandidate.Text = Convert.ToString(dt.Rows[0]["Name"]);
                            txtemail.Text = Convert.ToString(dt.Rows[0]["EmailID"]);


                            //if (dt.Rows[0]["gender"] != DBNull.Value && Convert.ToString(dt.Rows[0]["gender"]) != null && Convert.ToString(dt.Rows[0]["gender"]) != string.Empty)
                            //{
                            //    if (ddlgender.Items.FindByValue(Convert.ToString(dt.Rows[0]["gender"]).Trim()) != null)
                            //    {
                            //        ddlgender.Items.FindByValue(Convert.ToString(dt.Rows[0]["gender"]).Trim()).Selected = true;
                            //        //ddlgender.SelectedIndex = ddlgender.Items.IndexOf(ddlgender.Items.FindByValue(Convert.ToString(dt.Rows[0]["gender"])));
                            //    }
                            //}


                            txtDob.Text = Convert.ToString(dt.Rows[0]["DateofBirth"]);
                            txtAddress.Text = Convert.ToString(dt.Rows[0]["Address"]);

                            if (dt.Rows[0]["state"] != DBNull.Value && Convert.ToString(dt.Rows[0]["state"]) != null && Convert.ToString(dt.Rows[0]["state"]) != string.Empty)
                            {
                                if (ddlstate.Items.FindByText(Convert.ToString(dt.Rows[0]["state"]).Trim()) != null)
                                {
                                    ddlstate.Items.FindByText(Convert.ToString(dt.Rows[0]["state"]).Trim()).Selected = true;

                                }
                            }
                            txtpin.Text = Convert.ToString(dt.Rows[0]["Pin"]);
                            txtmobile.Text = Convert.ToString(dt.Rows[0]["Mobile"]);
                            txttel.Text = Convert.ToString(dt.Rows[0]["Tel"]);
                            txtAdhar.Text = Convert.ToString(dt.Rows[0]["AdharCardNo"]);


                            if (dt.Rows[0]["CompanyName"] != DBNull.Value && Convert.ToString(dt.Rows[0]["CompanyName"]) != null && Convert.ToString(dt.Rows[0]["CompanyName"]) != string.Empty)
                            {
                                if (ddlcompanylist.Items.FindByText(Convert.ToString(dt.Rows[0]["CompanyName"]).Trim()) != null)
                                {
                                    ddlcompanylist.Items.FindByText(Convert.ToString(dt.Rows[0]["CompanyName"]).Trim()).Selected = true;
                                }
                            }

                            //ddlcompanylist.SelectedIndex = ddlcompanylist.Items.IndexOf(ddlcompanylist.Items.FindByText(Convert.ToString(dt.Rows[0]["CompanyName"])));


                            txtCmpAddress.Text = Convert.ToString(dt.Rows[0]["CmpAddress"]);


                            if (dt.Rows[0]["SpState"] != DBNull.Value && Convert.ToString(dt.Rows[0]["SpState"]) != null && Convert.ToString(dt.Rows[0]["SpState"]) != string.Empty)
                            {
                                if (ddlSponsorState.Items.FindByText(Convert.ToString(dt.Rows[0]["SpState"]).Trim()) != null)
                                {
                                    ddlSponsorState.Items.FindByText(Convert.ToString(dt.Rows[0]["SpState"]).Trim()).Selected = true;
                                }
                            }

                            TxtSponsorPin.Text = Convert.ToString(dt.Rows[0]["SpPin"]);
                            txtContPerson.Text = Convert.ToString(dt.Rows[0]["CmpContactPerson"]);
                            txtCmpPhone.Text = Convert.ToString(dt.Rows[0]["CmpPhone"]);
                            txtcmpEmail.Text = Convert.ToString(dt.Rows[0]["CmpEmailID"]);



                            for (int i = 1; i <= chkCourses.Items.Count; i++)
                            {
                                string item = "Eq" + i;  // we are make it as database column name same like Eq1,Eq2,,Eq3,,Eq4...etc
                                if (Convert.ToString(dt.Rows[0][item]) != null && Convert.ToString(dt.Rows[0][item]) != string.Empty)
                                {
                                    if (Convert.ToString(dt.Rows[0][item]).Trim() == "1")
                                    {
                                        chkCourses.Items[i - 1].Selected = true;  // list item index will start from '0' thtas why  1-1=0
                                    }
                                    else
                                    {
                                        chkCourses.Items[i - 1].Selected = false;
                                    }
                                }
                                else
                                {
                                    chkCourses.Items[i - 1].Selected = false;
                                }
                            }

                            txtprofessionalQuali.Text = Convert.ToString(dt.Rows[0]["ProfQualification"]);

                            if (dt.Rows[0]["carryingReinsurance"] != DBNull.Value && Convert.ToString(dt.Rows[0]["carryingReinsurance"]) != null && Convert.ToString(dt.Rows[0]["carryingReinsurance"]) != string.Empty)
                            {
                                if (ddlreinsuranceReActi.Items.FindByText(Convert.ToString(dt.Rows[0]["carryingReinsurance"]).Trim()) != null)
                                {
                                    ddlreinsuranceReActi.Items.FindByText(Convert.ToString(dt.Rows[0]["carryingReinsurance"]).Trim()).Selected = true;
                                }
                            }

                            if (dt.Rows[0]["InsuranceConsultant"] != DBNull.Value && Convert.ToString(dt.Rows[0]["InsuranceConsultant"]) != null && Convert.ToString(dt.Rows[0]["InsuranceConsultant"]) != string.Empty)
                            {
                                if (ddlinsuranceConsultant.Items.FindByText(Convert.ToString(dt.Rows[0]["InsuranceConsultant"]).Trim()) != null)
                                {
                                    ddlinsuranceConsultant.Items.FindByText(Convert.ToString(dt.Rows[0]["InsuranceConsultant"]).Trim()).Selected = true;
                                }
                            }

                            if (dt.Rows[0]["principalUnderwriter"] != DBNull.Value && Convert.ToString(dt.Rows[0]["principalUnderwriter"]) != null && Convert.ToString(dt.Rows[0]["principalUnderwriter"]) != string.Empty)
                            {
                                if (ddlprincipleUnderwriter.Items.FindByText(Convert.ToString(dt.Rows[0]["principalUnderwriter"]).Trim()) != null)
                                {
                                    ddlprincipleUnderwriter.Items.FindByText(Convert.ToString(dt.Rows[0]["principalUnderwriter"]).Trim()).Selected = true;
                                }
                            }

                            if (dt.Rows[0]["ManagerNIA"] != DBNull.Value && Convert.ToString(dt.Rows[0]["ManagerNIA"]) != null && Convert.ToString(dt.Rows[0]["ManagerNIA"]) != string.Empty)
                            {
                                if (ddlpositionOfManager.Items.FindByText(Convert.ToString(dt.Rows[0]["ManagerNIA"]).Trim()) != null)
                                {
                                    ddlpositionOfManager.Items.FindByText(Convert.ToString(dt.Rows[0]["ManagerNIA"]).Trim()).Selected = true;
                                    // WE CAN DO IN BELOW FORMAT ALSO
                                    // ddlpositionOfManager.SelectedIndex = ddlpositionOfManager.Items.IndexOf(ddlpositionOfManager.Items.FindByText(Convert.ToString(dt.Rows[0]["ManagerNIA"])));
                                }
                            }


                            if (dt.Rows[0]["RequiredHours"] != DBNull.Value && Convert.ToString(dt.Rows[0]["RequiredHours"]) != null && Convert.ToString(dt.Rows[0]["RequiredHours"]) != string.Empty)
                            {
                                if (DdlReqHours.Items.FindByText(Convert.ToString(dt.Rows[0]["RequiredHours"]).Trim()) != null)
                                {
                                    DdlReqHours.Items.FindByText(Convert.ToString(dt.Rows[0]["RequiredHours"]).Trim()).Selected = true;
                                }
                            }

                            txttrainingId.Text = Convert.ToString(dt.Rows[0]["TrainingId"]);

                            //completiondate.Text = Convert.ToString(dt.Rows[0]["trgcompletedate"]);

                            // string Convertcompletiondate = Convert.ToString(dt.Rows[0]["trgcompletedate"]);
                            //completiondate.Text = Convertcompletiondate.Replace("/", "-");


                            txtNoAttempts.Text = Convert.ToString(dt.Rows[0]["NoAttempts"]);

                            if (dt.Rows[0]["NoAttempts"] != DBNull.Value && Convert.ToString(dt.Rows[0]["NoAttempts"]) != null && Convert.ToString(dt.Rows[0]["NoAttempts"]) != string.Empty)
                            {
                                if (txtNoAttempts.Text == "0")
                                {
                                    //ddlExamCentre.Items.FindByText(Convert.ToString(dt.Rows[0]["ExamCentre"]).Trim()).Selected = true;
                                    // ddlEarlierExam.SelectedItem.Text = "No";
                                    //ddlEarlierExam.Items.FindByText(Convert.ToString(dt.Rows[0]["NoAttempts"]).text = "No";
                                    ddlEarlierExam.Items.FindByText("No").Selected = true;
                                }
                                else
                                {
                                    //ddlEarlierExam.SelectedItem.Text = "Yes";
                                    ddlEarlierExam.Items.FindByText("Yes").Selected = true;
                                    txtNoAttempts.ReadOnly = false;
                                    //ddlEarlierExam.Items.FindByText( Convert.ToString(dt.Rows[0]["NoAttempts"]).Text = "Yes";
                                }
                            }


                            //TxtDetailsTrInstitute.Text = Convert.ToString(dt.Rows[0]["trginstitute"]);

                            if (dt.Rows[0]["ExamCentre"] != DBNull.Value && Convert.ToString(dt.Rows[0]["ExamCentre"]) != null && Convert.ToString(dt.Rows[0]["ExamCentre"]) != string.Empty)
                            {
                                if (ddlExamCentre.Items.FindByText(Convert.ToString(dt.Rows[0]["ExamCentre"]).Trim()) != null)
                                {
                                    ddlExamCentre.Items.FindByText(Convert.ToString(dt.Rows[0]["ExamCentre"]).Trim()).Selected = true;
                                }
                            }

                            if (dt.Rows[0]["ModuleOpted"] != DBNull.Value && Convert.ToString(dt.Rows[0]["ModuleOpted"]) != null && Convert.ToString(dt.Rows[0]["ModuleOpted"]) != string.Empty)
                            {
                                if (ddlbrokingModule.Items.FindByText(Convert.ToString(dt.Rows[0]["ModuleOpted"]).Trim()) != null)
                                {
                                    ddlbrokingModule.Items.FindByText(Convert.ToString(dt.Rows[0]["ModuleOpted"]).Trim()).Selected = true;
                                }
                            }


                            if (dt.Rows[0]["Appliedfor"] != DBNull.Value && Convert.ToString(dt.Rows[0]["Appliedfor"]) != null && Convert.ToString(dt.Rows[0]["Appliedfor"]) != string.Empty)
                            {
                                if (ddlappliedFor.Items.FindByText(Convert.ToString(dt.Rows[0]["Appliedfor"]).Trim()) != null)
                                {
                                    ddlappliedFor.Items.FindByText(Convert.ToString(dt.Rows[0]["Appliedfor"]).Trim()).Selected = true;
                                }
                            }

                            if (dt.Rows[0]["insurancebackground"] != DBNull.Value && Convert.ToString(dt.Rows[0]["insurancebackground"]) != null && Convert.ToString(dt.Rows[0]["insurancebackground"]) != string.Empty)
                            {
                                if (ddlinsurance.Items.FindByText(Convert.ToString(dt.Rows[0]["insurancebackground"]).Trim()) != null)
                                {
                                    ddlinsurance.Items.FindByText(Convert.ToString(dt.Rows[0]["insurancebackground"]).Trim()).Selected = true;
                                }
                            }

                            //string RegExamDate = Convert.ToString(dt.Rows[0]["ExamDate"]);
                            //string examFloderexit = DateTime.ParseExact(RegExamDate, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyyMMdd", CultureInfo.InvariantCulture);
                            //hplimage.Visible = true;
                            //hplimage.ForeColor = System.Drawing.Color.Blue;
                            //hplimage.Text = (Convert.ToString(dt.Rows[0]["Photo"]));
                            //hplimage.NavigateUrl = Server.UrlPathEncode(@"~/lib/" + examFloderexit + "/Photos/") + (Convert.ToString(dt.Rows[0]["Photo"]));

                            //hplctf.Visible = true;
                            //hplctf.ForeColor = System.Drawing.Color.Blue;
                            //hplctf.Text = (Convert.ToString(dt.Rows[0]["certificate"]));
                            //hplctf.NavigateUrl = Server.UrlPathEncode(@"~/lib/" + examFloderexit + "/PDfs/") + (Convert.ToString(dt.Rows[0]["certificate"]));

                         
                        }


                    //}

                    //else
                    //{
                    //    Response.Redirect("Dashbord.aspx?source=LoadRegisterType");
                    //    //ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('ID Not exists: This tab is now getting close');window.close();", true);

                    //}
                //}

                //else
                //{

                //    Response.Redirect("Login.aspx");
                //    //this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('please Confirm the Terms and Conditions')", true);
                //    //ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Sesson is closed.Note: This tab is now getting close');window.close();", true);
                //}

            }
        }
        public void BindCompany()
        {

            using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["DSN"]))
            {
                using (SqlCommand cmd = new SqlCommand("Select ID, ltrim(rtrim(Name)) as Name from SponsersMast order by Name"))
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
            ddlcompanylist.Items.Insert(0, new ListItem("Choose Any one", "0"));

        }


        public void BindSponsorState()
        {

            using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["DSN"]))
            {
                using (SqlCommand cmd = new SqlCommand("Select ID, ltrim(rtrim(Name)) as Name from StatesMast order by Name"))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    con.Open();
                    ddlSponsorState.DataSource = cmd.ExecuteReader();
                    ddlSponsorState.DataTextField = "Name";
                    ddlSponsorState.DataValueField = "ID";
                    ddlSponsorState.DataBind();
                    con.Close();
                }
            }
            ddlSponsorState.Items.Insert(0, new ListItem("Choose Any one", "0"));

        }

        public void BindState()
        {

            using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["DSN"]))
            {
                using (SqlCommand cmd = new SqlCommand("Select ID, ltrim(rtrim(Name)) as Name from StatesMast order by Name"))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    con.Open();
                    ddlstate.DataSource = cmd.ExecuteReader();
                    ddlstate.DataTextField = "Name";
                    ddlstate.DataValueField = "ID";
                    ddlstate.DataBind();
                    con.Close();
                }
            }
            ddlstate.Items.Insert(0, new ListItem("Choose Any one", "0"));

        }

        public void BindExamCenter()
        {

            using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["DSN"]))
            {
                using (SqlCommand cmd = new SqlCommand("Select ID, ltrim(rtrim(Name)) as Name from ExamCenterMast order by Name"))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    con.Open();
                    ddlExamCentre.DataSource = cmd.ExecuteReader();
                    ddlExamCentre.DataTextField = "Name";
                    ddlExamCentre.DataValueField = "ID";
                    ddlExamCentre.DataBind();
                    con.Close();
                }
            }
            ddlExamCentre.Items.Insert(0, new ListItem("Choose Any one", "0"));

        }

        protected void ddlEarlierExam_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (ddlEarlierExam.SelectedItem.Text == "Yes")
            {
                // txtNoAttempts.Text = "";
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


     

    

        protected void btnupdate_click(object sender, EventArgs e)
        {
            //string str = EduQ();

            //if (str.Length > 0)     // suppose if i select first 5 education Qualifications example : return -1-2-3-4-5-6= length 12
            //{
                //if (CHKagree.Checked)
                //{
                string id = Request.QueryString["Id"];

                string salutation = ddlsalutation.SelectedItem.Text;
                string candidateName = txtnameOfCandidate.Text;
                string email = txtemail.Text;
                string dob = txtDob.Text;
                string address = txtAddress.Text;

                string state = ddlstate.SelectedItem.Text;
                string pin = txtpin.Text;

                string mobile = txtmobile.Text;
                string rGender = ddlgender.SelectedItem.Value;
                string tel = txttel.Text;
                string Adhar = txtAdhar.Text;

                string companylist = ddlcompanylist.SelectedItem.Text;

                string cmpAddress = txtCmpAddress.Text;
                string sponsorState = ddlSponsorState.SelectedItem.Text;

                string sponsorPin = TxtSponsorPin.Text;
                string contPerson = txtContPerson.Text;
                string cmpPhone = txtCmpPhone.Text;
                string cmpEmail = txtcmpEmail.Text;

                string[] eqs = new string[chkCourses.Items.Count];

                for (int i = 0; i < chkCourses.Items.Count; i++)
                {
                    if (chkCourses.Items[i].Selected == true)
                    {
                        eqs[i] = "1";
                    }
                    else
                    {
                        eqs[i] = "0";
                    }
                }

                string professionalQuali = txtprofessionalQuali.Text;
                string reinsuranceReActi = ddlreinsuranceReActi.SelectedItem.Text;
                string insuranceConsultant = ddlinsuranceConsultant.SelectedItem.Text;
                string principleUnderwriter = ddlprincipleUnderwriter.SelectedItem.Text;

                string positionOfManager = ddlpositionOfManager.SelectedItem.Text;
                string reqHours = DdlReqHours.SelectedItem.Text;

                string trainingId = txttrainingId.Text;
                string Completiondate = completiondate.Text;

                string txtDetailsTrInstitute = TxtDetailsTrInstitute.Text;

                string noAttempts = txtNoAttempts.Text;
                string examCentre = ddlExamCentre.SelectedItem.Text;

                string brokingModule = ddlbrokingModule.SelectedItem.Text;
                string appliedFor = ddlappliedFor.SelectedItem.Text;
                string insurance = ddlinsurance.SelectedItem.Text;

                //string imagename = lbimagename.Text;
                //string ctfname = lbctfname.Text;





                //string query = "Update NiaExamApplicants set CandidateName = '" + candidateName + "', State = '" + state + "' , Eq1 = '" + eqs[0] + "', Eq2 = '" + eqs[1] + "'";
                //string query = "UPDATE NiaExamApplicants SET salutation = '" + salutation + "', Name='"+candidateName+"',EmailID='"+email+"',DateofBirth='"+dob+"',Address='"+address+"',state = '" + state + "' ,Pin='"+pin+"', Mobile='"+mobile+"',Tel='"+tel+"',AdharCardNo='"+Adhar+"',  CompanyName='"+companylist+"',CmpAddress='"+cmpAddress+"', SpState='"+sponsorState+"',SpPin='"+sponsorPin+"',CmpContactPerson='"+contPerson+"', CmpPhone='"+cmpPhone+"',CmpEmailID='"+cmpEmail+"', Eq1 = '" + eqs[0] + "', Eq2 = '" + eqs[1] + "',Eq3 = '" + eqs[2] + "', Eq4 = '" + eqs[3] + "',Eq5 = '" + eqs[4] + "', Eq6 = '" + eqs[5] + "',Eq7 = '" + eqs[6] + "', Eq8 = '" + eqs[7] + "',Eq9 = '" + eqs[8] + "', Eq10 = '" + eqs[9] + "',Eq11 = '" + eqs[10] + "', Eq12 = '" + eqs[11] + "',Eq13 = '" + eqs[12] + "', Eq14 = '" + eqs[13] + "',Eq15 = '" + eqs[14]+"',ProfQualification='"+professionalQuali+"',carryingReinsurance='"+reinsuranceReActi+"',InsuranceConsultant='"+insuranceConsultant+"',principalUnderwriter='"+principleUnderwriter+"',ManagerNIA='"+positionOfManager+"',RequiredHours='"+reqHours+"',TrainingId='"+trainingId+"',completiondate='"+Completiondate+"',NoAttempts='"+noAttempts+"',ExamCentre='"+examCentre+"',ModuleOpted='"+brokingModule+"',Appliedfor='"+appliedFor+"',insurancebackground='"+insurance+"' where id="+id+"";

                int k = 0;
                using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["DSN"]))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = con;
                        cmd.CommandText = "update NiaApplicants SET salutation = '" + salutation + "', Name='" + candidateName  + "',EmailID='" + email + "',DateofBirth='" + dob + "',Address='" + address + "',state = '" + state + "' ,Pin='" + pin + "', Mobile='" + mobile + "',Tel='" + tel + "',AdharCardNo='" + Adhar + "',  CompanyName='" + companylist + "',CmpAddress='" + cmpAddress + "', SpState='" + sponsorState + "',SpPin='" + sponsorPin + "',CmpContactPerson='" + contPerson + "', CmpPhone='" + cmpPhone + "',CmpEmailID='" + cmpEmail + "',ProfQualification='" + professionalQuali + "',carryingReinsurance='" + reinsuranceReActi + "',InsuranceConsultant='" + insuranceConsultant + "',principalUnderwriter='" + principleUnderwriter + "',ManagerNIA='" + positionOfManager + "',RequiredHours='" + reqHours + "',TrainingId='" + trainingId + "',NoAttempts='" + noAttempts + "',ExamCentre='" + examCentre + "',ModuleOpted='" + brokingModule + "',Appliedfor='" + appliedFor + "',insurancebackground='" + insurance + "' where id=" + id + "";
                        // Eq1 = '" + eqs[0] + "', Eq2 = '" + eqs[1] + "',Eq3 = '" + eqs[2] + "', Eq4 = '" + eqs[3] + "',Eq5 = '" + eqs[4] + "', Eq6 = '" + eqs[5] + "',Eq7 = '" + eqs[6] + "', Eq8 = '" + eqs[7] + "',Eq9 = '" + eqs[8] + "', Eq10 = '" + eqs[9] + "',Eq11 = '" + eqs[10] + "', Eq12 = '" + eqs[11] + "',Eq13 = '" + eqs[12] + "', Eq14 = '" + eqs[13] + "',Eq15 = '" + eqs[14] + "',
                        cmd.CommandType = CommandType.Text;
                        con.Open();
                        k = cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    if (k == 1)
                    {
                        this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('Record Updated successfully.')", true);

                    }
                }

                //}

                //  else
                //  {

                //      CHKagree.Focus();
                //      this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('please Confirm the Terms and Conditions')", true);
                //  }


            //}
            //else
            //{

            //    chkCourses.Focus();
            //    this.ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('please select atleast one educational qualification')", true);
            //}
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
                              //  CHKagree.Focus();
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
    }
}