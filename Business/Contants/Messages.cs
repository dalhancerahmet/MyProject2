using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Contants
{
    static class Messages
    {
        public static string ProductAdded = "Ürün Eklendi.";
        public static string ProductNameInvalid = "Ürün adı geçersiz.";
        public static string ProductListed = "Ürünler Listelendi";
        public static string MaintenanceTime = "Bakım molası";
        public static string GetByCategoryIdListed = "Kategoriye Göre listelendi.";
        public static string ProductListedByUnitPrice = "Birim fiyata göre ürünler listelendi.";
        public static string ProductListedByName = "Ürün adına göre listelendi";
        public static string ProductListedByDetails = "Ürünler istenilen tabloya göre listelendi.";

        public static string CategoryLimitedExceeded = "Kategori limiti aşıldı.";

        public static string AuthorizationDenied = "Yetkiniz yoktur.";

        public static string UserRegistered = "Kullanıcı kaydı başarılı";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Şifre hatalı";
        public static string SuccessfulLogin = "Giriş başarılı";
        public static string UserAlreadyExists = "Kullanıcı zaten var";
        public static string AccessTokenCreated = "Token oluşturuldu.";

        public static string ProductNameAlreadyExist = "Bu isimde ürün zaten var.";

        public static string ProductUpdated = "Ürün güncellendi.";

        public static string ProductDeleted = "Ürün silindi.";

        public static string CategoryAdded = "Kategori Eklendi.";

        public static string CategoryNameAlreadyExist = "Aynı isimde kategori zaten var.";
    }
}
