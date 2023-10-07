using System;
using System.Collections.Generic;

namespace MyApi.DA.EF
{
    public partial class Brand
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? Status { get; set; }
    }
}
