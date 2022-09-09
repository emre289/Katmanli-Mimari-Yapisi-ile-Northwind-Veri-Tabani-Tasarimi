using Ninject;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Busi.DependencyResolvers.ninject
{
    public class InstanceFactory
    {
        // T(concrete(somut)) GetInstance generic yaptık<Çalışağım Tipi Yazacam ör:IproducService>
        // Aşağıda get modülü ile BusinessModule gidecek
        // IProduct varsa onun newini oluşturacak ve onu return edeceks
        public static T GetInstance<T>()
        {
            var kernel = new StandardKernel(new BusinessModule());
            return kernel.Get<T>();
        }
    }
}
