using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
   public class ProductDetailDto:IDto
    {
        public int product_id { get; set; }
        public string  product_name { get; set; }
        public string category_name { get; set; } //category tablosuna ait kolon bu join işlemine tabi tutulacak
        public int units_in_stock { get; set; }
    }
}
