using FluentValidation;
using Northwind.Busi.Abstract;
using Northwind.Busi.Utilities;
using Northwind.Busi.ValidationRules.FluentValidation;
using Northwind.DataAccess.Abstract;
using Northwind.DataAccess.Concrete;
using Northwind.DataAccess.Concrete.EntityFramework;
using Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Busi.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;


        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void Add(Product product)
        {
            ValidationTool.Validate(new ProductValidator(), product);
            // GELEN BİLGİYİ EKLE
            _productDal.Add(product);
        }
        public void Update(Product product)
        {
            ValidationTool.Validate(new ProductValidator(), product);
            _productDal.Update(product);
        }

        public void Delete(Product product)
        {
            // Northwind İlişkisel Veri Tabanı Olduğu İçin Diğerleri Silerken Hata Alıyoruz
            // HATAYI KULLANICIYA SÖYLEMEMİZ LAZIM
            try
            {
                _productDal.Delete(product);
            }
            
            catch
            {

                throw new Exception("Silme Gerçekleşemedi");
            }
            
        }


        // SADECE BU OPERASYONU IProductService İçerisine Aldım
        public List<Product> GetAll()
        {

            return _productDal.GetAll();

        }

        public List<Product> GetProductsByCategory(int categoryId)
        {
            // GET OLDA FİLTRE YAPABİLİRİZ DİYE İZİN VERMİŞTİK- DELEGE YAZACAZ
            return _productDal.GetAll(p => p.CategoryID == categoryId);
        }

        public List<Product> GetProductsByProductName(string productName)
        {
            // BÜYÜK KÜÇÜK HARFE DUYARLILIK İÇİN HER İKİSİNİDE KÜÇÜLTÜK
            return _productDal.GetAll(p => p.ProductName.ToLower().Contains(productName.ToLower()));
        }

      

    }
}
