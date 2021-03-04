using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constans
{
   public static class Messages //static olunca new lemiyoruz
    {
        public static string BrandNameInvalid = "Marka ismi geçersiz en az (2<Marka ismi)";
        public static string BrandAdded = "Marka eklendi";
        public static string BrandDeleted = "Marka silindi";
        public static string BrandsListed = "Markalar listelendi";
        public static string BrandsUpteted = "Markalar güncellendi";
        public static string CarNameInvalid = "Araba ismi geçersiz en az (2<Marka ismi)";
        public static string CarAdded = "Araba eklendi";
        public static string CarDeleted = "Araba silindi";
        public static string CarsListed = "Arabalar listelendi";
        public static string CarUpdated = "Araba güncellendi";
        public static string ColorNameInvalid = "Renk ismi geçersiz en az (2<Marka ismi)";
        public static string ColorAdded = "Renk eklendi";
        public static string ColorDeleted = "Renk silindi";
        public static string ColorUpteted = "Renk güncellendi";
        public static string CustomerListed = "Müşteriler listelendi";
        public static string RentalInvalid = "Araba bulunamadı";
        public static string RentalAdded = "Kiralık Araba eklendi";
        public static string RentalAddedError = "Aracın kiraya verilebilmesi için önce teslim edilmesi gerekir.";
        public static string RentalListed = " Arabalar listelendi";
        public static string UserNameInvalid = "Kullanıcı ismi geçersiz en az (2<Kullanıcı Adı ve Soyadı)";
        public static string UserAdded = "Kullanıcı eklendi";
        public static string UserDeleted = "Kullanıcı silindi";
        public static string UserListed = " Kullanıcı listelendi";
        public static string UserUpteted = "Kullanıcı güncellendi";
        public static string RentalUpteted = "Kiralama güncellendi";
        public static string RentalDeleted = "Kiralama silindi";
        public static string CustomerAdded = "Müşteri eklendi";
        public static string CustomerDeleted = "Müşteri silindi";
        public static string CustomerUpteted = "Müşteri güncellendi";
        public static string CompanyNameInvalid = "Şirket ismi geçersiz en az (2<Şirket ismi)";
        public static string CarImagesAdded="Araba resmi eklendi ";
        public static string CarImagesUpdated="Arabanın resimi güncellendi";
        public static string CarImagesDeleted="Arabanın resimi silindi";
        public static string ImageLimitError="Resim limit aşımı";

        public static string AccessTokenCreated = "Erişim jetonu oluşturuldu";

        public static string PasswordError = "Parola hatalı";
        public static string SuccessfulLogin = "Giriş başarılı";
        public static string UserNotFound = "Kullanıcı bulunamadı";

        public static string UserRegistered = "Kullanıcı kayıtlı";

        public static string UserAlreadyExists = "Kullanıcı zaten kayıtlı";

        public static string AuthorizationDenied = "Yetkiniz yok";
    }
}
