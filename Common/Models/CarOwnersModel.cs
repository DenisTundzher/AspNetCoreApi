using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models
{
    public class CarOwnersModel
    {
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public int CarId { get; set; }

        public virtual OwnerModel Owner { get; set; }
        public virtual CarModel Car { get; set; }
    }
}
