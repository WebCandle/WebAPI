using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Message
    {
        private long _MessageID;
        private string _Text;
        private List<Photo> _Photos;
        private DateTime _Time;
        private User _Sender;
    }
}