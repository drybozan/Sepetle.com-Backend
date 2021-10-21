using Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class Category:IEntity
    {
        [Key]
        public int category_id { get; set; }
        public string category_name { get; set; }
    }
}
