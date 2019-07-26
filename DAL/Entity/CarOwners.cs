using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Entity
{
    public class CarOwners
    {
        [Key]
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public int CarId { get; set; }

        public virtual Owner Owner { get; set; }
        public virtual Car Car { get; set; }
    }
}
