using Core.Entities.DTOs;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products; //Diyoruz ki bu projeyi başlatınca bellekte bir tane boş ürün listesi oluşturalım

        public InMemoryProductDal()
        {
            _products = new List<Product> // InMemory içerisinde arka planda boş bir ürün listesi oluşturduk. Ve içerisine teker teker ürünleri atıyoruz.
            {
                new Product{ProductId=1, CategoryId=1, ProductName="Bardak", UnitPrice=15, UnitsInStock=15},
                new Product{ProductId=1, CategoryId=1, ProductName="Kamera", UnitPrice=15, UnitsInStock=15},
                new Product{ProductId=1, CategoryId=1, ProductName="Telefon", UnitPrice=15, UnitsInStock=15},
                new Product{ProductId=1, CategoryId=1, ProductName="Tabak", UnitPrice=15, UnitsInStock=15},
            };
        }

        public void Add(Product product)
        {
            _products.Add(product); //(Product product)'tan gelen ürünü Ekle(nereye) _product'ın listelediği listeye ekle.
        }

        public void Delete(Product product)
        {
            Product productToDelete;
            productToDelete=_products.FirstOrDefault(p=> p.ProductId == product.ProductId);
            _products.Remove(productToDelete);
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _products; //Veritabanını Business katman için olduğu gibi döndürüyoruz.
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p=>p.CategoryId == categoryId).ToList(); 
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            Product productToUpdate = _products.FirstOrDefault(p=> p.ProductId == product.ProductId);   
            productToUpdate.ProductName=product.ProductName;
            productToUpdate.CategoryId=product.CategoryId;
            productToUpdate.UnitPrice=product.UnitPrice;
            productToUpdate.UnitsInStock=product.UnitsInStock;
        }
    }
}
