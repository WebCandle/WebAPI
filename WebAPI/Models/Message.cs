using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace WebAPI.Models
{
    public class Message
    {

        public long MessageID { set; get; }
        public string Text { set; get; }
        public DateTime Time { set; get; }
        public long SenderID { set; get; }

        public Message()
        {

        }
        public Message(long messageID, string text, DateTime time, long senderid)
        {
            MessageID = messageID;
            Text = text;
            Time = time;
            SenderID = senderid;
        }
        public Message(string text, long senderid)
        {
            Text = text;
            SenderID = senderid;
            Time = DateTime.Now;
        }
        //public Message(SerializationInfo info, StreamingContext context)
        //{
        //    SenderID = (long) info.GetValue("SenderID", typeof(long));
        //    Text = (string) info.GetValue("Text", typeof(string));
        //}

        //public void GetObjectData(SerializationInfo info, StreamingContext context)
        //{
        //    info.AddValue("SenderID", SenderID);
        //    info.AddValue("Text", Text);
        //}
    }
}