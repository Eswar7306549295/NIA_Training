using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NIAPRG.lib
{
    public partial class testorder2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (WebClient client = new WebClient())
            {

                byte[] response =
                client.UploadValues("courseordreturn.aspx", new NameValueCollection()
       {
           { "msg", "Cosby1234" }
       });

                string result = System.Text.Encoding.UTF8.GetString(response);
            }
        }
    }
}