using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PushGag.DTO
{
    public class CommentsDTO
    {
        public int ID
        {
            get; set;
        }
        public int IdArticle
        {
            get; set;
        }

        public string Username
        {
            get; set;
        }

        public string Comment
        {
            get; set;
        }
    }
}