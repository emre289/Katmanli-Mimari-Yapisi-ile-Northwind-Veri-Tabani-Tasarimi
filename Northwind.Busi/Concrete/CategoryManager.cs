using Northwind.Busi.Abstract;
using Northwind.DataAccess.Abstract;
using Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Busi.Concrete
{
    public class CategoryManager:ICategoryService
    {
        private ICategoryDal _categoryDal;


        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }


        // SADECE BU OPERASYONU IProductService İçerisine Aldım
        public List<Category> GetAll()
        {

            return _categoryDal.GetAll();

        }
    }
}
