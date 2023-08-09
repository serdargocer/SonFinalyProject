using Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Business
{
    public class BusinessRules
    {
        public static IResult Run(params IResult[] logics)                                             //Buraya IResult içeren iş kurallarımızı göndereceğiz. O yüzden burayı IResult yapıyoruz.
                                                                                                      //Run() demek çalıştır demektir. Yani IResult olan iş kurallarımı çalıştır.
                                                                                                     //ProductManager içerisine "BusinessRules.Run()" dediğimizde Core katmanındaki iş kurallarını Business katmanındaki ProductManager içerisinde çağırır.
        {
            foreach (var result in logics) 
            {
                if (!result.Success)  //Unutma bu DOĞRU DEĞİLSE anlamı katar.
                {
                    return result;
                }
            }
            return null;
        }
    }
}

//params: params kullandığımızda istediğimiz kadar parametreyi "BusinessRules.Run()" içerisine ekleyebiliriz.
//C# gönderdiğimiz bütün parametreleri Array haline getiriyor ve IResult[] içerisine atıyor.