using System.ComponentModel.DataAnnotations;

namespace Core.Entities.Concrete
{
    public class OperationClaim:IEntity
    {
        [Key]
        public int claim_id { get; set; }
        public string claim_name { get; set; }

    }
}
