using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace WebAPI.Models
{
    public class Message
    {
        public string Endpoint { set; get; }
        public string Text { set; get; }
        public DateTime Time { set; get; }

        public Message(string endpoint, string text, DateTime dateTime)
        {
            Endpoint = endpoint;
            Text = text;
            Time = dateTime;
        }
    }
}