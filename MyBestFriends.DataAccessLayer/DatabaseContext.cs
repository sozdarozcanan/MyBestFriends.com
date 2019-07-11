using MyBestFriends.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBestFriends.DataAccessLayer
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<Ilan> Ilanlar { get; set; }
        public DbSet<HayvanCins> HayvanCinsler { get; set; }
        public DbSet<Hayvan> Hayvanlar { get; set; }
        public DbSet<Sehir> Sehirler { get; set; }

        public DatabaseContext()
        {
            Database.SetInitializer(new MyInitiliazer());
        }
    }
}
