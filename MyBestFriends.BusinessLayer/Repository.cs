using MyBestFriends.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyBestFriends.BusinessLayer
{
    public class Repository<T> : RepositoryBase where T:class
    {
                 //DatabaseContext db = new DatabaseContext();

                 //ilişkisel tablolarda ilişkiyi kuramayacağı için o bilgiyi alamayacagız.

        private DbSet<T> _SetNesnesi; //erişilemeyecek dbSet
        public Repository() //ornek alındıgında bir tane db.set getirsin
        {
            
            _SetNesnesi = db.Set<T>();
        }
        public List<T> List()
        {
            return _SetNesnesi.ToList();
            //db.set<T>().ToList();
        }
        public List<T> List(Expression<Func<T,bool>> where)
        {
            return _SetNesnesi.Where(where).ToList();
        }
        public int Insert(T obj)
        {
            _SetNesnesi.Add(obj);
            //db.set<T>().add(obj);
            return Save();
        }
        public int Update(T obj)
        {
            return Save();
        }
        public int Delete(T obj)
        {
            _SetNesnesi.Remove(obj);
            return Save();
        }



        private int Save()
        {
            return db.SaveChanges();
        }
        public T Find(Expression<Func<T, bool>> where)
        {
            return _SetNesnesi.FirstOrDefault(where);
        }
    }
}
