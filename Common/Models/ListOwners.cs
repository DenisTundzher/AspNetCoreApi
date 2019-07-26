using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models
{
    public class ListOwners
    {
        public int TotalPages { get; set; }
        public IEnumerable<OwnerModel> Owners { get; set; }
    }
}
