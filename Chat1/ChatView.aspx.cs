using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Chat1.Models;

namespace Chat1
{
    public partial class ChatView : System.Web.UI.Page
    {
        protected void BtnSend_Click(object sender_objekt, EventArgs e)
        {
            string from = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority);
            string to = txtEndpointTo.Text;
            string senderName = txtSenderName.Text;
            string text = TxtMessage.Text;
            DateTime dateTime = DateTime.Now;
            Message message = new Message(from, to, senderName, text, dateTime);
            Global.MainController.PostMessage(message);
            //Response.Redirect(Request.RawUrl);
        }
        public void loadChat()
        {
            foreach (Chat chat in Global.MainController.Chats)
            {
                if (chat.Messages != null)
                {
                    GridView gridView = new GridView();
                    Pnl.Controls.Add(gridView);
                    gridView.DataSource = chat.Messages;
                    gridView.DataBind();
                }
            }
        }

        protected void ChatTimer_Tick(object sender, EventArgs e)
        {
            loadChat();
        }
    }
}