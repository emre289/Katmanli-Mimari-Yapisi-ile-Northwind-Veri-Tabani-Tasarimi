using FluentValidation;
using Northwind.Busi.ValidationRules.FluentValidation;
using Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Busi.Utilities
{
    // SIKLIKLA KULLANCAĞIM İÇİN STATİK YAPTIM
    public static class ValidationTool
    {
        public static void Validate(IValidator validator, object entity)
        {
            // VAL HATASI 0 İSE HATA FIRLAT
           
            var result = validator.Validate(entity);
            if (result.Errors.Count > 0)
            {
                throw new ValidationException(result.Errors);
            }
        }

        
    }
}
