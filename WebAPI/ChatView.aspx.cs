using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Http;
using WebAPI.Models;

namespace WebAPI.Views
{
    public partial class ChatView : System.Web.UI.Page
    {
        public long ChatID { get; set; }
        public Chat Chat { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];
            if (!string.IsNullOrEmpty(id))
            {
                ChatID = long.Parse(id);
            }
            else
            {
                ChatID = 0;
            }
            Chat chat = Global.MainController.Chats.Find(x => x.ChatID == ChatID);
            if(chat != null)
            {
                lblChatRoom.Text = chat.RoomName;
                GWChat.DataSource = chat.Messages;
                GWChat.DataBind();
            }
            else
            {
                lblChatRoom.Text = "Not Fround!!!!!";
            }

        }

        protected void Tmr_Tick(object sender, EventArgs e)
        {
            foreach(Message message in Chat.Messages)
            {

            }
        }

        protected void BtnSend_Click(object sender, EventArgs e)
        {
            string endpoint = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority);
            long senderid = 1;
            long messageid = 55;
            Message message = new Message(messageid, TxtMessage.Text, DateTime.Now, senderid);
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = httpClient.PostAsXmlAsync(endpoint+"/api/message/"+ChatID.ToString(), message).Result;
            if(response.IsSuccessStatusCode)
            {
                Response.Redirect(Request.RawUrl, true);
            }
        }
    }
}