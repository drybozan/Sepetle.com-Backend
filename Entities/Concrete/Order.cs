using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Concrete
{
    public class Order:IEntity
    {
        [Key]
        public int order_id { get; set; }
        public int customer_id { get; set; }
        public int employee_id { get; set; }
        public DateTime order_date { get; set; }
        public string ship_city { get; set; }
    }
}
