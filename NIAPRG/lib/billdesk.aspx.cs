using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Web.UI.WebControls;

namespace NIAPRG
{
    public partial class billdesk : System.Web.UI.Page
    {
         public string ServerValue = String.Empty;
         public void Page_Load(object sender, EventArgs e)
         {

             
                 if (Page.PreviousPage != null)
                 {
                     string data = Convert.ToString(((TextBox)PreviousPage.FindControl("msg")).Text);
                     string sd = sample1(data);
                     checkSumValue.Text = sd.ToUpper();
                     ServerValue = data + "|" + sd.ToUpper();
                     createlog(ServerValue);

                 }
            


         }

         private void createlog(string ServerValue)
         {
             string message = string.Format("Time: {0}", DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"));
             message += Environment.NewLine;
             message += "-----------------------------------------------------------";
             message += Environment.NewLine;
             message += string.Format("paymentRequest: {0}", ServerValue);
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

        private string sample1(string data)
        {
            //string data = "NIANEW|21211311154444444|NA|2.00|NA|NA|NA|INR|NA|R|nianew|NA|NA|F|9848919134|jxraju@thebostongroup.com|NA|NA|NA|NA|NA|http://103.241.144.250/lib/courseordreturn.aspx";
            // String data = "MERCHANT|1000000000|NA|12.00|XXX|NA|NA|INR|DIRECT|R|NA|NA|NA|F|111111111|NA|NA|NA|NA|NA|NA|NA";

            // string data = "NIANEW|NIAREG001|NA|2.00|NA|NA|NA|INR|NA|R|nianew|NA|NA|F|9948919134|jraju@thebostongroup.com|NA|NA|NA|NA|NA|http://e-learning.niapune.org.in/lib/courseordreturn.aspx";

            string commonkey = "Ci3YPxsAclPH";
            //SHASample dataprg = new SHASample();
            string hash = String.Empty;
            hash = GetHMACSHA256(data, commonkey);
             return hash;
        }

       
        public string GetHMACSHA256(string text, string key)
        {
            UTF8Encoding encoder = new UTF8Encoding();

            byte[] hashValue;
            byte[] keybyt = encoder.GetBytes(key);
            byte[] message = encoder.GetBytes(text);

            HMACSHA256 hashString = new HMACSHA256(keybyt);
            string hex = "";

            hashValue = hashString.ComputeHash(message);
            foreach (byte x in hashValue)
            {
                hex += String.Format("{0:x2}", x);
            }
            return hex;
        }


    }
}