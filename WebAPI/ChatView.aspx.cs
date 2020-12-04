using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading;
using WebAPI.Models;

namespace WebAPI.Views
{
    public partial class ChatView : System.Web.UI.Page
    {
        public long ChatID { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];
            if (!string.IsNullOrEmpty(id))
            {
                ChatID = long.Parse(id);
            }
            else
            {
                ChatID = 1;
            }
        }

        protected void BtnSend_Click(object sender, EventArgs e)
        {
            long senderid = 1;
            long messageid = 55;
            Message message = new Message(messageid, TxtMessage.Text, DateTime.Now, senderid);
            Global.MainController.PostMessage(ChatID, message);
            //Response.Redirect(Request.RawUrl);
        }
        public void loadChat()
        {
            Chat chat = Global.MainController.GetChat(ChatID);
            lblChatRoom.Text = chat.RoomName;
            GWChat.DataSource = chat.Messages;
            GWChat.DataBind();
        }

        protected void btnLoadChat_Click(object sender, EventArgs e)
        {
            loadChat();
        }
    }
}