using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    /// <summary>
    /// Main Controller
    /// </summary>
    public class Controller
    {
        public List<Chat> Chats { set; get; }

        public Controller()
        {
            Chats = new List<Chat>();
        }
    }
}