using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string UserAdded="Kullanıcı eklendi.";
        public static string ProductAdded = "Ürün eklendi";
        public static string ProductNameNoAdded = "Ürün ismi geçersiz"; //Türkçesi product ismi geçersiz demek
        public static string ProductListed = "Ürünler listelendi";
        public static string MaintenanceTime = "Sistem bakımda";
        public static string ProductNameInValid = "Ürün ismi aynı";
        public static string ProductCountOfCategoryError="Bir kategoride en fazla 15 ürün olabilir";
        public static string ProductNameAlreadyExists="Bu isimde bir ürün bulunmaktadır.";
        public static string CategoryLimitExceded="Kategori limiti aşıldı.";
        public static string AuthorizationDenied="Yetkiniz bulunmamaktadır.";
        public static string AccessTokenCreated="Token oluşturuldu.";
        public static string UserAlreadyExists="Bu kullanıcı adı veya şifresi sistemde kayıtlı";
        public static string SuccessfulLogin="Başarılı giriş yapıldı.";
        public static string PasswordError="Parola hatası";
        public static string UserNotFound="Kullanıcı bulunamadı";
        public static string UserRegistered="Kayıt oldunuz.";
        public static string UserSystemAdd="Kullanıcı sisteme eklendi.";
        public static string UserEmailClaim= "Kullanıcı email bilgisi.";
        public static string ProductUpdated="Ürün güncellendi";
        public static string ProductDeleted="Ürün silindi";
    }
}
