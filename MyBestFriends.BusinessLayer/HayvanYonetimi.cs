using MyBestFriends.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBestFriends.BusinessLayer
{
   public class HayvanYonetimi
    {
        private Repository<Hayvan> repo_hayvan = new Repository<Hayvan>();
        public List<Hayvan> GetHayvanlar()
        {
            return repo_hayvan.List();
        }

        
    }
}
