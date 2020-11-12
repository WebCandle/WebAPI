using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;
using System.Text;

namespace WebAPI
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGetSend_Click(object sender, EventArgs e)
        {
            if(!txtURIGet.Text.Contains("http://"))
            {
                txtURIGet.Text = "http://" + txtURIGet.Text;
            }
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(txtURIGet.Text);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream receiveStream = response.GetResponseStream();
            StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);
            txtResponseGet.Text = readStream.ReadToEnd();
            response.Close();
            readStream.Close();
        }
    }
}