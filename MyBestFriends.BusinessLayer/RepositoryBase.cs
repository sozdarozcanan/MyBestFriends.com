using MyBestFriends.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBestFriends.BusinessLayer
{  //SIGLETON PATTERN=  HERHANGİ BİR NESNEYİ 1 KERE "new"lemek
   public class RepositoryBase
    {
        protected static  DatabaseContext db; //miras alındıgında alınır
        private static object _kilit = new object();
        protected RepositoryBase()    // tekrar oluşmasını önlemek bir kere oluşturması için yapıldı.
        {
            //constructor oluşturulamayacak
             CreateContext();
        }
        private static void CreateContext()  // static metodlar bir kere çalışır.
        {
            if (db==null) //null ise oluştursun
            {
                lock (_kilit)
                {
                    if (db==null)
                    {
                    db = new DatabaseContext();
                    }
            
                }
                
            }
            
        }
    }
}
