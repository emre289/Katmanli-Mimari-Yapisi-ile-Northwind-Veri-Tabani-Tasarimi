using Ninject.Modules;
using Northwind.Busi.Abstract;
using Northwind.Busi.Concrete;
using Northwind.DataAccess.Abstract;
using Northwind.DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Busi.DependencyResolvers.ninject
{
    public class BusinessModule : NinjectModule  // <>
    {
        public override void Load()
        {
            // KULLANICI NEYİ İSTİYORSA ONU VER ANLAMINDA
            // BU ŞEKİL ENTİTY DIŞINDA KULLANACAĞIMIZ ŞEYLERDE SADECE BURADA DEĞİŞTİRMEMİZ YETERLİ
            // .InSingletonScope() Bir Nesneyi Bir Kişi Üretirsen Herkese Aynı Nesneyi Verir
            Bind<IProductService>().To<ProductManager>().InSingletonScope(); 
            Bind<IProductDal>().To<EfProductDal>().InSingletonScope();
            Bind<ICategoryService>().To<CategoryManager>().InSingletonScope();
            Bind<ICategoryDal>().To<EfCategoryDal>().InSingletonScope();
        }
    }
}
