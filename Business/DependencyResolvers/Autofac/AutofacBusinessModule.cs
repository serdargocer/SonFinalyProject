using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.CCS;
using Business.Concrete;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.Jwt;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)  //Autofac ile geliyor.
        {
            builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance(); 
            builder.RegisterType<EfProductDal>().As<IProductDal>().SingleInstance();
            builder.RegisterType<CategoryManager>().As<ICategoryService>().SingleInstance();
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>().SingleInstance();

            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
            builder.RegisterType<EfUserDal>().As<IUserDal>().SingleInstance();

            builder.RegisterType<AuthManager>().As<IAuthService>().SingleInstance();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>().SingleInstance();

            var assembly=System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces().EnableInterfaceInterceptors
                (new Castle.DynamicProxy.ProxyGenerationOptions()
            {
                Selector = new AspectInterceptorSelector()
            }).SingleInstance();
        }
    }
} //.SingleInstance(); Ter bir tane instance ya da EfProductDal gibi ya da ProductManager gibi oluşturmayı yapıyor.
  //Böylelikle BAĞIMLILIKTAN KURTARMIŞ OLUYORUZ.
  //Bir tane instance oluşturuyor ve onu herkesle paylaşıyor. 100 bin kullanıcılı bir sistemde 100 bin instance oluşturmak yerine SingleInstance ile bir kere üretiyotuz ve o 100 bin instance ye paylaşıyoruz. Çünkü bunlar referans tip ve refeerans tipleri herkesle paylaşabiliyoruz.
