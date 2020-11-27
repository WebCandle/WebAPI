using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Message
    {
        public long MessageID { set; get; }
        public string Text { set; get; }
        public List<Photo> Photos { set; get; }
        public DateTime Time { set; get; }
        public User Sender { set; get; }
    }
}