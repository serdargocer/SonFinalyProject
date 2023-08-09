using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results.Concrete
{
    public class SuccessResult : Result
    {
        public SuccessResult(string message) : base(true, message) //base classı bizim Result sınıfımızdır. Ve DATA almaz. Adı üzerinden IDataResult ve DataResult data alır.
                                                                   //True 'yi ise SuccessResult başarılı dönsün diye verdik yani TRUE Result'a bu yapının başarılı olduğunu söylüyor.
                                                                   //Aynı zamanda TRUE Result sınıfındaki (bool success)'in karşılığıdır.
                                                                   //(string message) ile de burada mesaj alsın diyoruz.
        {

        }
    }
}
