using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Interceptors
{
    public abstract class MethodInterception : MethodInterceptionBaseAttribute
    {
        protected virtual void OnBefore(IInvocation invocation) { }
        protected virtual void OnAfter(IInvocation invocation) { }
        protected virtual void OnException(IInvocation invocation, System.Exception e) { }
        protected virtual void OnSuccess(IInvocation invocation) { }
        public override void Intercept(IInvocation invocation)                            //Burası bizim çalıştırmak istediğimiz metodunuz.
        {
            var isSuccess = true;
            OnBefore(invocation);                        //Metodun başında çalıştır. %90 bu alan kullanılıyor yazılımlarda.
            try
            {
                invocation.Proceed();
            }
            catch (Exception e)
            {
                isSuccess = false;
                OnException(invocation, e);                        //Hata aldığımda çalışır.
                throw;
            }
            finally
            {
                if (isSuccess)
                {
                    OnSuccess(invocation);                                //Tüm hepsinin sonunda yani başarılı olursa burası çalışsın
                }
            }
            OnAfter(invocation);                             //Metodtan sonra çaışsın istersekte burayı yazıyoruz.
        }
    }
}

//Bunlardan hangisini doldurursak bizim için o çalışacak.
//BURASI BİZİM BÜTÜN METOTLARIMIZIN ÇATISIDIR.