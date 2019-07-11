using MyBestFriends.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBestFriendsWebApp.Models
{
    public class KayitliSession
    {
        public static Kullanici Kullanici //şuanki kullanıcıyı gonderir.
        {
            get
            {
                return Get<Kullanici>("login");
            }
        }
     
        public static T Get<T>(string anahtar)
        {
            if (HttpContext.Current.Session[anahtar] != null)               
            {
             return (T) HttpContext.Current.Session[anahtar];
         }
            return default(T);
        }
    }
}