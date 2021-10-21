
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Core.Entities;

namespace Entities.Concrete
{
    public class Product:IEntity
    {
       
        [Key]
        public int product_id { get; set; }
        public int category_id { get; set; }
        public string product_name { get; set; }
        public int units_in_stock { get; set; }
        public double unit_price { get; set; }
    }
}
