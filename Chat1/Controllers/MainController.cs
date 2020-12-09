using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Chat1.Models;
using System.Net.Http;
using System.Threading;
using Newtonsoft.Json;
using System.Net;
using System.IO;

namespace Chat1.Controllers
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
            Chat chat = Chats.Find(x => x.Endpoint == message.From);
            if (chat != null)
            {
                chat.AddMessage(message);
            }
            else
            {
                chat = new Chat(message.From, message.Sender, new List<Message>());
                chat.AddMessage(message);
                Chats.Add(chat);
            }
        }
        public void PostMessage(Message message)
        {
            Chat chat = Chats.Find(x => x.Endpoint == message.To);
            if (chat != null)
            {
                chat.AddMessage(message);
            }
            else
            {
                chat = new Chat(message.To, message.Sender, new List<Message>());
                chat.AddMessage(message);
                Chats.Add(chat);
            }
            HttpWebRequest httpRequest = (HttpWebRequest)HttpWebRequest.Create(message.To + "/api/message");
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