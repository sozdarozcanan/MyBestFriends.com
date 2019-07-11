using MyBestFriends.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBestFriends.DataAccessLayer
{
   public  class MyInitiliazer : DropCreateDatabaseIfModelChanges<DatabaseContext>
    {
        //public MyInitiliazer() 
        //{
        //    Database.SetInitializer<DatabaseContext>(new MigrateDatabaseToLatestVersion<DatabaseContext, MyBestFriends.DataAccessLayer.Migrations.Configuration>());
        //}
    }
}

