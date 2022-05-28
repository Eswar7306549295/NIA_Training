using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace PMI
{
    public partial class PrintData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["data"] != null)
            //{
                DataTable dt = new DataTable();
                dt = (DataTable)Session["data"];
                StringBuilder sb = new StringBuilder();
                //Generate Invoice (Bill) Header.
                sb.Append("<table align='center' width='60%' cellspacing='0' cellpadding='2' style=' border-collapse: collapse; border: 1px solid black' >");
                sb.Append("<tr><td align='center' style='background-color: #18B5F0' colspan = '2'><img width='100%' id='imgPhoto' height='80' src='./css/logo.png'  /></td></tr>");
                sb.Append("<tr><td align='center' style='background-color: #18B5F0' colspan = '2'><b>Visitors Form</b></td></tr>");
                sb.Append("<tr><td colspan = '2'></td></tr>");
                sb.Append("<tr><td><b>visitor No: </b>" + dt.Rows[0]["vid"].ToString() + " <br/><br/><b>Visitor Name : </b>" + dt.Rows[0]["name"].ToString() + " <br/><br/><b>Organization : </b>" + dt.Rows[0]["org"].ToString() + " <br/><br/><b>Whome to Meet: " + dt.Rows[0]["whomeToMeet"].ToString() + " </b>");
                sb.Append("</td><td >");
                sb.Append("<img width='150px' id='imgPhoto' height='130' src='" + dt.Rows[0]["Photo"].ToString() + "'  /> ");
                sb.Append("</td></tr>");

         
                //sb.Append("<tr><td><b>Visitor Name : </b>");
                ////sb.Append(companyName);
                //sb.Append("</td><td><b>Organization : </b>");
                //sb.Append(" </td></tr>");
                //sb.Append("<tr><td><b>Whome to Meet: </b>");
                //// sb.Append(dt.Rows[0]["vid"].ToString());
                //sb.Append("</td><td><b>Date: </b>");
                //sb.Append(DateTime.Now);
                //sb.Append(" </td></tr>");

                sb.Append("<tr><td><b>Address : </b>" + dt.Rows[0]["Address"].ToString() + "");
                sb.Append("</td><td><b>Mobile  : </b>" + dt.Rows[0]["Mobile"].ToString() + "");
                sb.Append(" </td></tr>");
                //sb.Append("<tr><td><b>Visitor Name : </b>" + dt.Rows[0]["vid"].ToString() + "");
                //sb.Append("</td><td><b>Organization : </b>" + dt.Rows[0]["vid"].ToString() + "");
                //sb.Append(" </td></tr>");
                sb.Append("<tr><td><b>Email Id : </b>" + dt.Rows[0]["EmailId"].ToString() + "");
                sb.Append("</td><td><b>Type of List  : </b>" + dt.Rows[0]["Typeof"].ToString() + "");
                sb.Append(" </td></tr>");
                sb.Append("<tr><td><b>In Time : </b>" + dt.Rows[0]["INTIME"].ToString() + "");
                sb.Append("</td><td><b>Other Info  : </b>" + dt.Rows[0]["Otherinfo"].ToString() + "");
                sb.Append(" </td></tr>");
                sb.Append("<tr><td><b> </b>");
                sb.Append("</td><td><b>Visitor's Signature </b><br/><br/>");
                sb.Append(" </td></tr>");
                sb.Append("<tr><td><b>Security Signature </b>");
                sb.Append("</td><td><b>Officer's Signature </b><br/><br/>");
                sb.Append(" </td></tr>");
                sb.Append("</table>");
                sb.Append("<br />");

                divdata.InnerHtml = sb.ToString();


           // }


            //Session["ctrl"] = Panel1;
            // ClientScript.RegisterStartupScript(this.GetType(), "onclick", "<script language=javascript>window.open('PrintData.aspx','PrintMe','height=300px,width=300px,scrollbars=1');</script>");
            //Control ctrl = (Control)Session["ctrl"];
            //string Script = string.Empty;
            //StringWriter stringWrite = new StringWriter();
            //System.Web.UI.HtmlTextWriter htmlWrite = new System.Web.UI.HtmlTextWriter(stringWrite);
            //if (ctrl is WebControl)
            //{
            //    Unit w = new Unit(100, UnitType.Percentage); ((WebControl)ctrl).Width = w;
            //}
            //Page pg = new Page();
            //pg.EnableEventValidation = false;
            //if (Script != string.Empty)
            //{
            //    pg.ClientScript.RegisterStartupScript(pg.GetType(), "PrintJavaScript", Script);
            //}
            //HtmlForm frm = new HtmlForm();
            //pg.Controls.Add(frm);
            //frm.Attributes.Add("runat", "server");
            //frm.Controls.Add(ctrl);
            //pg.DesignerInitialize();
            //pg.RenderControl(htmlWrite);
            //string strHTML = stringWrite.ToString();
            //HttpContext.Current.Response.Clear();
            //HttpContext.Current.Response.Write(strHTML);
            //HttpContext.Current.Response.Write("<script>window.print();</script>");
            //HttpContext.Current.Response.End();
        }
    }
}