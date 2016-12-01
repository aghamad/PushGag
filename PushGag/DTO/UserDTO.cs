using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PushGag.DTO
{
    public class UserDTO
    {
        public int ID {
            get; set;
        }

        public string Username {
            get; set;
        }

        public DateTime DateStart {
            get; set;
        }

        public string Password {
            get; set;
        }

        public string Email {
            get; set;
        }

    }

}