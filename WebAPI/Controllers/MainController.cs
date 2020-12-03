using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI.Models;
using System.Net;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

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
    }
}