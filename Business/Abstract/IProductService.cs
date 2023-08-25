using Core.Entities.DTOs;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductService
    {
        IDataResult<List<Product>> GetAll(); //Listelemek için bir tane boş list oluşturduk. IDataResult'ta jeneric olarak verdiğimiz T'mi burazda bizim List<Product>'a karşılık geliyor.Yani bunu alıyor.
        IDataResult<List<Product>> GetAllByCategoryId(int id);
        IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max);
        IDataResult<List<ProductDetailDto>> GetProductDetails();
        IDataResult<Product> GetById(int productId);   //Bir tane tek başına ürün döndürür. Bunu gerçek hayatta bir tane alışveriş sitesinde bir ürüne tıkladığımızda o ürünle ilgili ürünün detayını getirir.
        IResult Add(Product product); //ProductService'te herhangi bir implemente işlemi gerçekleştirmediğimiz için IEntityRepository içerisindeki jeneric ifadeceleri kullanamıyoruz. Onun için burada Add metodunu tekrar yazmak zorunda kalıyoruz.
        IResult Update(Product product);
        IResult Delete(Product product);
        IResult TransactionalOperation(Product product);
    }
}
