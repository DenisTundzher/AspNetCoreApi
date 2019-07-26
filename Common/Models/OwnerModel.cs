using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models
{
    public class OwnerModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public int Postcode { get; set; }

        public ICollection<CarModel> Cars { get; set; }
    }
}
