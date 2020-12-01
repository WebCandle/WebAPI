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
        public Chat(long chatID,string roomName, List<Message> messages)
        {
            ChatID = chatID;
            RoomName = roomName;
            Messages = messages;
        }
        public Chat( long chatID)
        {
            //get Chat from the DB or datasource
            Chat chat = Global.MainController.Chats.Find(x => x.ChatID == chatID);
            if(chat != null)
            {
                Assign(chat);
            }
            else
            {
                ChatID = 0;
                RoomName = "<RoomName>";
                Messages = new List<Message>();
            }
        }

        #region Worker
        public void Assign(Chat chat)
        {
            ChatID = chat.ChatID;
            RoomName = chat.RoomName;
            Messages = chat.Messages;
        }
        public void AddMessage(Message message)
        {
            message.MessageID = getNeuMessageId();
            Messages.Add(message);
        }
        private long getNeuMessageId()
        {
            Message lastMessage = Messages.OrderByDescending(item => item.MessageID).FirstOrDefault();
            long messageId = 1;
            if (lastMessage != null)
            {
                messageId = lastMessage.MessageID + 1;
            }
            return messageId;
        }
        #endregion

    }
}