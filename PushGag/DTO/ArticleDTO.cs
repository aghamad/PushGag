using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PushGag.DTO
{
    public enum EnumType { picture, video, text };
    public enum EnumCategorie { wtf, movie, anime, gaming, girl, boy, gif, darkhumor, food, prank, arabic, french, sport, quebec, party, love, texto, traveling, riddle, wordgame};

    public class ArticleDTO {

        public int ArticleID {
            get; set;
        }

        public EnumType Type {
            get; set;
        }

        public EnumCategorie Categorie {
            get; set;
        }

        public DateTime DatePublished {
            get; set;    
        }

        public string Data {
            get; set;
        }

        public string Title {
            get; set;
        }

        public int Pulled {
            get; set;
        }

    }
}