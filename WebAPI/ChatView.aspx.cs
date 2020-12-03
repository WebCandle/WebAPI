using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Http;
using Newtonsoft.Json;
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
            if(!Page.IsPostBack)
            {
                loadChat();
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
        public void loadChat()
        {
            string endpoint = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority);
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = httpClient.GetAsync(endpoint + "/api/chat/" + ChatID.ToString()).Result;
            if (response.IsSuccessStatusCode)
            {
                try
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    Chat chat = JsonConvert.DeserializeObject<Chat>(result);
                    lblChatRoom.Text = chat.RoomName;
                    GWChat.DataSource = chat.Messages;
                    GWChat.DataBind();
                }
                catch(Exception ex)
                {
                    lblChatRoom.Text = ex.Message;
                }
            }
        }
        protected void timerChat_Tick(object sender, EventArgs e)
        {
            //GWChat.DataBind();
        }

        protected void btnLoadChat_Click(object sender, EventArgs e)
        {
            loadChat();
        }
    }
}