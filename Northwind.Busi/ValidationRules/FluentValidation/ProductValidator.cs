using FluentValidation;
using Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Busi.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(P => P.ProductName).NotEmpty().WithMessage("ProductName BOŞ OLAMAZ !");
            RuleFor(P => P.CategoryID).NotEmpty().WithMessage("CATEGORYID BOŞ OLAMAZ !");
            RuleFor(P => P.UnitPrice).NotEmpty().WithMessage("UnitPrice  BOŞ OLAMAZ !");
            RuleFor(P => P.QuantityPerUnit).NotEmpty().WithMessage("QuantityPerUnit  BOŞ OLAMAZ !");
            RuleFor(P => P.UnitsInStock).NotEmpty().WithMessage("UnitsInStock  BOŞ OLAMAZ !"); ;

            RuleFor(P => P.UnitPrice).GreaterThan(0).WithMessage("UnitPrice 0 DAN BÜYÜK OLMALI !");
            RuleFor(P => P.UnitPrice).GreaterThan(10).When(P => P.CategoryID == 2);

            // KENDİMİZDE KURAL BELİRLEYEBİLİRİZ
            RuleFor(P => P.ProductName).Must(startWitA).WithMessage("ProductName A İLE BAŞLAMALI !"); ;
        }

        private bool startWitA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
