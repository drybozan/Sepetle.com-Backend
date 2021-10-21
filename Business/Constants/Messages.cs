using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
   public static class Messages //static class olduğu için newlemeye gerek yok
    {
        public static string ProductAdded = "Ürün eklendi";
        public static string ProductNameInvalid = "Ürün ismi en az 2 karekterden oluşmalıdır.";
        public static string ProductsListed = "Ürünler listelendi";

        public static string MaintenanceTime = "Sistem şuan bakımda ürün listeleyemiyoruz.";
    }
}
