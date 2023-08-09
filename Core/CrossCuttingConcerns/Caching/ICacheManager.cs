using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Caching
{
    public interface ICacheManager
    {
        /// <summary>
        /// Ben sana bir key vereyim sen bana bu key'e karşılık gelen DATA'yı ver demektir.
        /// </summary>
        /// <returns></returns>
        T Get<T>(string key);           
        object Get(string key);         //Bu da yukarıdakinin generic olmayan versiyonudur.Bunu yaparsak tip dönüşümü yapmamız gerekiyor.

        /// <summary>
        /// Cache'ye ekleme yapacağız
        /// </summary>
        /// <param name="key">Cache verdiğimiz isimdir. Örneğin : Business.Concrete.ProductManager.GetAll</param>
        /// <param name="data">Gelecek data bir obje olsun. Çünkü obje bütün veritipleri ve kolleksiyonların BASE'dir.Dolayısıyla buraya herşeyi atabiliriz.</param>
        /// <param name="duration">Cache de ne kadar duracak.Genelde Dakika cinsinden</param>
        void Add(string key, object data, int duration);
        /// <summary>
        /// Ürün cache'de var mı? Eğer varsa Cache'den getir. Yoksa git veritabanından getir ama onu cache ekle diyeceğiz.
        /// </summary>
        /// <returns></returns>
        bool IsAdd(string key);
        void Remove(string key);

        /// <summary>
        /// Eğer metot birden fazla parametre alıyorsa biz ona hangi key'i vereceğiz.Dolayısıyla böyle bir pattern yazıyoruz ve diyoruz ki ismi GET ile başlayanlarıuçur. Başı sonu önemli değil içerisinde GET olanları uçur diyoruz.
        /// </summary>
        void RemoveByPattern (string pattern);
    }
}