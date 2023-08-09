using Core.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    public interface IEntityRepository<T> where T: class, IEntity, new()
    {
        List<T> GetAll(Expression<Func<T, bool>> filter=null); //Filtre vermeyebilirsin demektir. Yani filtre vermemişse yani null ise TÜMÜNÜ GETİR DEMEKTİR.
        T Get(Expression<Func<T, bool>>filter); //TEK BİR DATA GETİRMEK İÇİN KULLANILIR. Bu bir sistemde bir şeyin detayına girmektir. Burada sadece filtre dediği için FİLTRELEYİP GETİRECEK.
        void Add(T Entity); //T hangi veri tipini kullanacaksak onu veriyor. Entity ise bunların bir veritabanı nesnesi olduğunu veriyor Entities katmanındaki Entity
        void Delete (T Entity); //T hangi veri tipini kullanacaksak onu veriyor. Entity ise bunların bir veritabanı nesnesi olduğunu veriyor Entities katmanındaki Entity
        void Update(T Entity); //T hangi veri tipini kullanacaksak onu veriyor. Entity ise bunların bir veritabanı nesnesi olduğunu veriyor Entities katmanındaki Entity

    }
}
