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
        }
        public void AddChat(Chat chat)
        {
            Chats.Add(chat);
        }
        public void AddMessage(Message message)
        {
            Chat chat = Chats.Find(x => x.Endpoint == message.Endpoint);
            if(chat != null)
            {
                chat.AddMessage(message);
            }
            else
            {
                chat = new Chat(message.Endpoint, message.Endpoint, new List<Message>());
                chat.AddMessage(message);
                Chats.Add(chat);
            }
        }
        public void PostMessage(string endpoint_to, Message message)
        {
            HttpWebRequest httpRequest = (HttpWebRequest)HttpWebRequest.Create(endpoint_to + "/api/message");
            httpRequest.Method = "POST";
            httpRequest.ContentType = "Application/json";
            string messageAsJson = JsonConvert.SerializeObject(message);

            using (var streamWriter = new StreamWriter(httpRequest.GetRequestStream()))
            {
                streamWriter.Write(messageAsJson);
            }
            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
            }

        }
    }
}