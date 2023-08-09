using Core.DataAccess;
using Core.Entities.DTOs;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IProductDal:IEntityRepository<Product> // T çalışma tipini Product olarak belirledik bundan sonra Add,Delete,Update,GetAll() işlemlerinde artık product veri tipini kullanacakmış.
    {
        List<ProductDetailDto> GetProductDetails();
    }
}
