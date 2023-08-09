using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.DTOs
{
    //Çıplak classımız olmayacaktı. IEntity buraya olmaz, çünkü IEntity demek sen bir veritabanı tablosusun demekti
    //ancak ProductDetailDto bir veritabanı tablosu değil, veritabanındaki tabloları JOIN yapan bir yapı sadece.
    //Buraya DTO sınıflarnı tanımlayacak bir ABSTRACT "IDto" oluşturacağız.
    //Niye böyle yapıyoruz çünkü kafasına göre gidip Context'e Dto yapılarını eklemesin diye.
    //Çünkü bu bir tablo değil bir kaç tablonun  kolonlarını getiriyor.
    public class ProductDetailDto :IDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public short UnitsInStock { get; set; }
    }
}
