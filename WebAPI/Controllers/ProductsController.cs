using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")] //Route de clientlerin bize nasıl istekte bulunacaklarını belirtiyor.
    [ApiController]  //[ApiController]'ı vermemiz gerekiyor. Bu ControllerBase için bir İMZA YÖNTEMİDİR. Ve ProductsController sınıfına diyorki SEN BİR CONTROLLERSIN o yüzden kendini ona göre yapılandır diye .NET'e haber veriyoruz.
    public class ProductsController : ControllerBase  //API isimlendirmelerinde hep çoğul takı eki olan 's' takısı eklenerek verilir.
                                                      //Bir Controller'ın ControllerBase'den inherit edilmesi gerekiyor.
                                                      //https://localhost:44314/api/products  buradaki "products" ProductsController'dan geliyor.
    {

        IProductService _productService; //Burada ProductManager'e olan bağımlılığımızı ortadan kaldırmış oluyoruz. HİÇBİR ZAMAN BİR KATMAN DİĞER KATMANIN SOMUTUNU YANİ MANAGER'İNİ TUTAMAZ

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("getall")]
        public IActionResult Get()  //Burası List<Product>'tı biz IActionResult'a çevirdik. IActionResult ile HTTP Statu Code olan 200 OK gibi 400 BadRequest() gibi durum kodlarını vereceği<.
        {
            var result = _productService.GetAll();
            if (result.Success)
            {
                return Ok(result); //Bu şekilde result dediğimizde hem işlemin sonucunu hem mesajı hemde DATA'yı dönüyor.
            }

            return BadRequest(result);

            //return result.Data; //IProductDal'ı Managerden kurtarmaya çalışsaydık ozman result.Data daki DATA'yı getiremeyecektik. Getirmek için mecbur IProductService kullanacağız.
        }

        [HttpGet("getbyid")]
        public IActionResult Get(int id)  //Burası List<Product>'tı biz IActionResult'a çevirdik. IActionResult ile HTTP Statu Code olan 200 OK gibi 400 BadRequest() gibi durum kodlarını vereceği<.
        {
            var result = _productService.GetById(id);
            if (result.Success)
            {
                return Ok(result); //Bu şekilde result dediğimizde hem işlemin sonucunu hem mesajı hemde DATA'yı dönüyor.
            }

            return BadRequest(result);

            //return result.Data; //IProductDal'ı Managerden kurtarmaya çalışsaydık ozman result.Data daki DATA'yı getiremeyecektik. Getirmek için mecbur IProductService kullanacağız.
        }

        
        [HttpPost("add")]
        public IActionResult Add(Product product)
        {
            var result = _productService.Add(product);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        //API İÇERİSİNDE HİÇ BİR ZAMAN SOMUT SINIFLAR KULLANILMAZ. HER ZAMAN SOYUT SINIFLAR KULLANARAK YANİ CONSTRUCTER OLUŞTURARAK İLERLERİZ.

        //Bu şekilde de Manager sınıfına OLAN BAĞLILIĞI KALDIRMIŞ OLDUK.

        //[HttpGet]
        //public List<Product> Get()
        //  {
        //      return new List<Product> //Bu ürünleri POSTMAN'da dizilerde tutarak getirir. RESTFUL mimariler %99.99 JSON formatı üzerinde ilerler.
        //      {
        //          new Product{ ProductId = 1, ProductName = "Elma"},
        //          new Product{ ProductId = 2, ProductName="Armut"},
        //      };
        //  }

        //[HttpGet]
        //public List<Product> Get()
        //{
        //   ProductManager productService = new ProductManager(new EfProductDal()); //Burada bağımlığı ortadan kaldırmamız gerekiyor. Manager sınıflarına bağımlılığı ortadan kaldırmak için de IProductDal ile değil de IProductService ile constructer oluşturmamız gerekiyor.
        //   var result = productService.GetAll();
        //   return result.Data;



    }
}
