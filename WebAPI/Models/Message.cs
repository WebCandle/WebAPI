using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace WebAPI.Models
{
    public class Message
    {
        public string From { set; get; }
        public string To { set; get; }
        public string Sender { set; get; }
        public string Text { set; get; }
        public DateTime Time { set; get; }

        public Message(string from, string to, string sender, string text, DateTime dateTime)
        {
            From = from;
            To = to;
            Sender = sender;
            Text = text;
            Time = dateTime;
        }
    }
}