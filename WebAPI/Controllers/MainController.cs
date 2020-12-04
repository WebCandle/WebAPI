using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI.Models;
using System.Net.Http;
using System.Threading;
using Newtonsoft.Json;
using System.Net;
using System.IO;

namespace WebAPI.Controllers
{
    public class MainController
    {
        public List<Chat> Chats { get; set; }
        public MainController()
        {
            Chats = new List<Chat>();
            LoadChats();
        }
        public void LoadChats()
        {
            Chat chat1 = new Chat(1, "Fussbal", new List<Message>());
            AddChat(chat1);
            Chat chat2 = new Chat(2, "Handball", new List<Message>());
            AddChat(chat2);
            Chat chat3 = new Chat(3, "Tennis", new List<Message>());
            AddChat(chat3);
        }
        public void AddChat(Chat chat)
        {
            Chats.Add(chat);
        }
        public void AddMessage(long ChatID, Message message)
        {
            Chat chat = Chats.Find(x => x.ChatID == ChatID);
            if(chat != null)
            {
                chat.AddMessage(message);
            }
        }
        public Chat GetChat(long ChatID)
        {
            string endpoint = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(endpoint + "/api/chat/" + ChatID.ToString());
            request.Method = "GET";
            request.Accept = "application/json";
            //request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                string content =  reader.ReadToEnd();
                Chat chat = JsonConvert.DeserializeObject<Chat>(content);
                return chat;
            }
        }
        public async void PostMessage(long ChatID, Message message)
        {
            string endpoint = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority);
            HttpWebRequest request = (HttpWebRequest) HttpWebRequest.Create(endpoint+"/api/message/"+ChatID.ToString());
            request.Method = "POST";
            request.ContentType = "Application/Json";
            string messageAsString = JsonConvert.SerializeObject(message);
            var response  = request.GetResponse();

            //while (!task.IsCompleted)
            //{
            //    Thread.Sleep(5);
            //}
            //HttpResponseMessage response = task.Result;
            //if (response.IsSuccessStatusCode)
            //{
            //    //Response.Redirect(Request.RawUrl, true);
            //}
        }
    }
}