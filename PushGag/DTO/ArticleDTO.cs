using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PushGag.DTO
{
    public enum EnumType {picture = 1, video = 2, text = 3};
    public enum EnumCategorie {wtf = 1, movie = 2, anime = 3, gaming = 4, girl = 5, boy = 6, gif = 7, darkhumor = 8, food = 9, prank = 10, arabic = 11, french = 12, sport = 13, quebec = 14, party = 15, love = 16, texto = 17, traveling = 18, riddle = 19, wordgame = 20};

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

        public static T ParseEnum<T>(string value) {
            return (T)Enum.Parse(typeof(T), value, true);
        }

        public override string ToString(){
            return String.Format("Type: {0} \n, Categorie: {1} \n, Title: {2} \n, Data: {3} \n",
                                 Type, Categorie, Title, Data);
        }

    }
}