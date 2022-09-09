using Northwind.Entities.Abstract;
using Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DataAccess.Abstract
{
    // GENERİCLERLE ÇALIŞIRIZ<> 
    // GENERİCLERİDE FİLTRELEYEBİLİRİZ CLASS OLSUN, NEW LENEBİLİR OLSUN TARZINDA
    public interface IEntityRepository<T> where T : class , IEntity, new()
    {
        // KULLANICI İSTERSE FİLTRELEME YAPARAK ÜRÜNLERİ GETİREBİLİR
        List<T> GetAll(Expression<Func<T,bool>> filter =null);
        
        // BURADA KULLANICI =null OLMADIĞI İÇİN BOŞ GEÇEMEZ FİLTRE YAPMALI
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
