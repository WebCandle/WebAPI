using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
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
            Chat = new Chat(ChatID);
            lblChatRoom.Text = Chat.RoomName;
        }

        protected void Tmr_Tick(object sender, EventArgs e)
        {
            foreach(Message message in Chat.Messages)
            {

            }
        }
    }
}