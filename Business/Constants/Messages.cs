using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    // TOOL görevi görüyor bu class - Basit metinler topluğu.
   public static class Messages
    {
        public static string AuthorizationDenied = "Yetkiniz Yok";
        public static string MaintenanceTime = "Sistem Bakımda Sonra Gel :) --SMTcoder ";
        public static string SuccessAdded = "Ekleme başarılı.";
        public static string SuccessUpdated = "Güncelleme başarılı.";
        public static string SuccessDeleted = "Silme başarılı.";
        public static string SuccessListed = "Listeleme başarılı.";

        public static string RentalInvalid = "Kiralama başarısız.";

        
        public static string CarImageLimit = "Bir arabaya 5'ten fazla resim eklenemez.";
        public static string CarCountOfBrandLimit="Bu markaya daha fazla araba eklenmez.";
        public static string CarAdded= "Araba Eklendi";
        public static string CardAdded = "Card eklendi";

        public static string findexPointMax = "Findeks Puanınız 1900";
        public static string findexPointAdd = "20 Findeks Puanı Eklendi";
        public static string SuccessfullyPaid = "Başarılı Ödeme";
    }
}
