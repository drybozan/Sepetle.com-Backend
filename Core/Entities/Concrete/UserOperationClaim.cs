using System.ComponentModel.DataAnnotations;

namespace Core.Entities.Concrete
{
    public class UserOperationClaim:IEntity
    {
        [Key]
        public int id { get; set; }
        public int userss_id { get; set; }
        public int operation_claim_id { get; set; }

    }
}
