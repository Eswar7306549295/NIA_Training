using System;
using System.Security.Cryptography;
using System.Text;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace NIAPRG.lib
{
    public partial class testBilldesk : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                msg.Text = "NIANEW|E0060013170105141441QGV1|NA|2.00|NA|NA|NA|INR|NA|R|nianew|NA|NA|F|9848919134|jxraju@thebostongroup.com|NA|NA|NA|NA|NA|https://e-learning.niapune.org.in/lib/courseordreturn.aspx";
              
            }
        }

        protected void btngenerate_Click(object sender, EventArgs e)
        {
            Server.Transfer("billdesk.aspx");
        }
       

    }
}