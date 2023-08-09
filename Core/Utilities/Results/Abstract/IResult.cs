using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results.Abstract
{
    public interface IResult  //IResult içerisinde DATA bulunmaz. Datalarımızı IDataResult içerisinde yazarız.
                              //IResult içerisinde direk işlem sonucunu veririz birde vermek istersek mesajımızı veririz.
    {
        bool Success { get; } //{get;} demek sadece okunabilir demektir.
        string Message { get; }
    }
}
