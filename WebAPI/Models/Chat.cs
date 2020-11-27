using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Chat
    {
        public long ChatID { set; get; }
        public string RoomName { set; get; }
        public List<Message> Messages { set; get; }

        public Chat()
        {
            ChatID = 0;
            RoomName = "<RoomName>";
            Messages = new List<Message>();
        }
        public Chat( long chatID)
        {
            //get Chat from the DB
            ChatID = 0;
            RoomName = "<RoomName>";
            Messages = new List<Message>();
            //WebApiApplication
        }

        #region Worker
        public void AddMessage(Message message)
        {
            Messages.Add(message);
        }
        #endregion

    }
}