using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebAPI.Models;

namespace WebAPI
{
    public partial class ChatView : System.Web.UI.Page
    {
        protected void BtnSend_Click(object sender, EventArgs e)
        {
            string endpoint = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority);
            Message message = new Message(endpoint, TxtMessage.Text, DateTime.Now);
            Global.MainController.PostMessage(txtEndpointTo.Text, message);
            //Response.Redirect(Request.RawUrl);
        }
        public void loadChat()
        {
            GWChat.DataSource = Global.MainController.Chats;
            GWChat.DataBind();
        }

        protected void ChatTimer_Tick(object sender, EventArgs e)
        {
            loadChat();
        }
    }
}