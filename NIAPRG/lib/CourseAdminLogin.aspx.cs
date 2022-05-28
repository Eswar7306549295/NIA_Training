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
namespace NIAPRG.lib
{
    public partial class CourseAdminLogin : System.Web.UI.Page
    {

        SqlConnection cnn = new SqlConnection(ConfigurationManager.AppSettings["DSN"]);
        protected void Page_Load(object sender, EventArgs e)
        {
            // Encrypt("nia@020");
            //lblmsg.Text = "";


            if (!IsPostBack)
            {

            }
        }
        private string RandomString(int size)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            //if (lowerCase)
            //    return builder.ToString().ToLower();
            return builder.ToString();
        }
        private string GenerateHash(string input)
        {
            //password hashing MD5 concepts is used below...
            byte[] hs = new byte[50];
            StringBuilder sb = new StringBuilder();
            MD5 md5 = MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);
            for (int i = 0; i < hash.Length; i++)
            {
                hs[i] = hash[i];
                sb.Append(hs[i].ToString("x2"));
            }
            return salt1.Value = sb.ToString();
        }


        //password encription


        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            string Name = "";
            if (txtusername.Text != "" || txtloginpwd.Text != "")
            {
                try
                {
                    cnn.Open();
                    DataSet ds = new DataSet();
                    SqlCommand cmd = new SqlCommand("SP_CourseAdminLogin", cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Username", txtusername.Text.Trim().ToString());
                    cmd.Parameters.AddWithValue("@Password", txtloginpwd.Text.Trim().ToString());
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            Session["id"] = Convert.ToInt32(ds.Tables[0].Rows[i]["id"]);
                            Name = ds.Tables[0].Rows[i]["Name"].ToString();
                            Session["Username"] = ds.Tables[0].Rows[i]["courseusername"].ToString();
                            Session["Email"] = ds.Tables[0].Rows[i]["Email"].ToString();
                            Session["Mobile"] = ds.Tables[0].Rows[i]["Mobile"].ToString();
                        }

                        Response.Redirect("CourseAdminReg.aspx");

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMSG",
                                                         "alertify.alert(Invalid UserName / Password');",
                                                         true);
                        lblmsg.Text = "Invalid UserName / Password";
                        lblmsg.Visible = true;
                        //Response.Redirect("AdminLogin.aspx");
                        return;
                    }
                }
                catch(Exception ex)
                {
                    
                }
            }

            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMSG",
                                                     "alertify.alert(Invalid UserName / Password');",
                                                     true);
                lblmsg.Text = "Invalid UserName / Password";
                lblmsg.Visible = true;
                Response.Redirect("AdminLogin.aspx");
                return;
            }
            //}
            //else
            //{
            //    ScriptManager.RegisterStartupScript(this, GetType(), "alertMSG",
            //                                         "alertify.alert(Invalid UserName / Password');",
            //                                         true);
            //    lblmsg.Text = "Invalid UserName / Password";
            //    lblmsg.Visible = true;
            //    Response.Redirect("AdminLogin.aspx");
            //    return;


            //}

        }
    }





}

