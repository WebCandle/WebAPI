using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Chat
    {
        public string Endpoint { set; get; }
        public string Name { set; get; }
        public List<Message> Messages { set; get; }

        public Chat(string endpoint, string name, List<Message> messages)
        {
            Endpoint = endpoint;
            Name = name;
            Messages = messages;
        }
        #region Worker
        public void AddMessage(Message message)
        {
            Messages.Add(message);
        }
        #endregion

    }
}