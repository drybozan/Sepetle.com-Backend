using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Entities.Concrete
{
    public class User:IEntity
    {
        [Key]
        public int userss_id { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
        public byte[] password_salt { get; set; }
        public byte[] password_hash { get; set; }
        public bool status { get; set; }
    }
}
