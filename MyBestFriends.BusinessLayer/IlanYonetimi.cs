using MyBestFriends.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBestFriends.BusinessLayer
{
    public class IlanYonetimi
    {
        private Repository<Ilan> repo_ilan = new Repository<Ilan>();
        public List<Ilan> getIlanlar()
        {
            return repo_ilan.List();
        }
        public List<Ilan> GetHayvanById(int id, bool onay)
        {
            if (onay == true)
            {
                return repo_ilan.List(x => x.Cins.HayvanID == id && x.IlanTuru == onay);
            }
            //return repo_ilan.Find(x => x.Cins.HayvanID == id);
            return repo_ilan.List(x => x.Cins.HayvanID == id && x.IlanTuru == onay);
        }
    }
}
