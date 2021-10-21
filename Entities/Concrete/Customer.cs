
using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Concrete
{
    public class Customer:IEntity
    {
        [Key]
        public string customer_id { get; set; }
        public string contact_name { get; set; }
        public string company_name { get; set; }
        public string city { get; set; }
    }
}
