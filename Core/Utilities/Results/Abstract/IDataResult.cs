using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results.Abstract
{
    public interface IDataResult<T> : IResult //İşlem sonucu ve mesaj buradan alıyoruz. interface'yi interface ile interit ettiğimizde bu şekilde yapılıyor concrete sınıflarındaki classlar gibi inherit etmiyoruz.
    {
        T Data { get; } //İşlem sonucunu ve mesajın yanında bir de T tipinde bir DATA alacak. Bunu Data'yı alması için yazdık.
    }
}
