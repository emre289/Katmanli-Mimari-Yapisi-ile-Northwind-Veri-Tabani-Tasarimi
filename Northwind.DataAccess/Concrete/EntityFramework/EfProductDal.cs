using Northwind.DataAccess.Abstract;
using Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DataAccess.Concrete.EntityFramework
{
    // BENDEN ENTİTY İSTİYOR (Product,Category.. ), TCONTEXT İSTİYOR (NORTHWİNDCONTEX) OLUŞTURMUŞTUK
    public class EfProductDal :EfEntityRepositoryBase<Product,NorthwindContext>,IProductDal
    {

    }
}
