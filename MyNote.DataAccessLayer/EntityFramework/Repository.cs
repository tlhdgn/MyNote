using MyNote.DataAccessLayer;
using MyNote.DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyNote.DataAccessLayer.EntityFramework
{
    public class Repository<T> : RepositoryBase, IRepository<T> where T :class
    {
        //private DatabaseContext db = new DatabaseContext();
        //private DatabaseContext db;

        private DbSet<T> _objectSet;
        public Repository()
        {
            //db = RepositoryBase.CreateContext(); //repositorybase'den miras alınıyor
            _objectSet = context.Set<T>(); //db Repositorybase'deki protected'dan miras alınarak kullanılıyor
        }

        //istenen tabloya bağlı kayıtları listeleme
        public List<T> List()
        {
            return _objectSet.ToList();
        }

        //istenilen bir koşula göre bir kaydı getirme
        public List<T> List(Expression<Func<T,bool>> where)
        {
            return _objectSet.Where(where).ToList();
        }

        public int Insert(T obj)
        {
            _objectSet.Add(obj);
            return Save();
        }

        public int Update(T obj)
        {
            return Save();
        }

        public int Delete(T obj)
        {
            _objectSet.Remove(obj);
            return Save();                
        }

        public int Save()
        {
            return context.SaveChanges();
        }

        //verilen koşula uygun nesneyi bul ve geri döndür
        public T Find(Expression<Func<T, bool>> where)
        {
            return _objectSet.FirstOrDefault(where);
        }
    }
}
