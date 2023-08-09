using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.CCS;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Entities.DTOs;
using Core.Utilities.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService  //IProductService base sınıf oluyor ve ProductManager'e diyorki bu base sınıfından türet
    {
        IProductDal _productDal;
        ICategoryService _categoryService;

        public ProductManager(IProductDal productDal, ICategoryService categoryService)
        {
            _productDal = productDal;
            _categoryService = categoryService;
            
        }

        //[SecuredOperation("admin")]
        [ValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect("IProductService.Get")]

        public IResult Add(Product product)
        {
            IResult result = BusinessRules.Run(CheckIfProductCountOfCategoryCorrect(product.CategoryId), 
                CheckIfProductNameExists(product.ProductName), CheckIfCategoryLimitExceded());    //Run, çalıştır demek. Yani BusinessRules içerisindeki Run() metodunu çalıştıracak

            if (result != null)
            {
                return result;
            }

            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded); // IResult içerisinde gelen SUCCESS ve MESSAGE metotlarını geri döndürüp Result() içerisine yerleştirmemiz için NEW() ile newlememiz gerekiyor.
                                                             // Results klasörü içerisindeki IResult'ı ProductManager içerisinde kullandığımız için de new()'liyoruz.
                                                             // Yani burası Result results = new Result() demektir.
        }

        [CacheAspect]
        public IDataResult<List<Product>> GetAll()
        {
            //if (DateTime.Now.Hour == 21)
            //{
            //    return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            //}
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductListed); //(_productDal.GetAll()) ile döndürdüğüm DATA'yı ben List<Product> veri tipi ile çağıracağım yani bir aray listesi olarak çağıracağım diyoruz.
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id));
        }

        [CacheAspect]
        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max)); //ikisine de == yapsaydım bana ozamna sadece en minimum ve en maksimum iki değeri getirecekti.
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }

        private IResult CheckIfProductCountOfCategoryCorrect(int categoryid)
        {
            var result = _productDal.GetAll(p => p.CategoryId == categoryid).Count;

            if (result >= 15)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            }
            return new SuccessResult(null);
        }

        private IResult CheckIfProductNameExists(string productName)
        {
            var result = _productDal.GetAll(p => p.ProductName == productName).Any();
            if (result)
            {
                return new ErrorResult(Messages.ProductNameAlreadyExists);
            }
            return new SuccessResult(null);
        }
        private IResult CheckIfCategoryLimitExceded()
        {
            var result = _categoryService.GetList();     //Burada zaten tümünü getiriyor o yüzden LINQ kullanmadım.
            if (result.Data.Count>=15)
            {
                return new ErrorResult(Messages.CategoryLimitExceded);
            }
            return new SuccessResult(null);
        }

        [CacheRemoveAspect("IProductService.Get")]
        public IResult Update(Product product)
        {
            _productDal.Update(product);
            return new SuccessResult(Messages.ProductUpdated);
        }

        public IResult Delete(Product product)
        {
            _productDal.Delete(product);
            return new SuccessResult(Messages.ProductDeleted);
        }
    }
}
