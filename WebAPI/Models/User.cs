using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class User
    {
        public User()
        {
            Name = "Test";
        }

        public long UserID { set; get; }
        public string Name { set; get; }
    }
}