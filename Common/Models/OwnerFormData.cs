using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models
{
    public class OwnerFormData
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string SortedId { get; set; }
        public bool SortedDesc { get; set; }
    }
}
