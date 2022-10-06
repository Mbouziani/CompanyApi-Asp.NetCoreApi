using System;
using System.Collections.Generic;

namespace CompanyApi.Models
{
    public partial class Company
    {
        public int CompanyId { get; set; }
        public long CompanyNumber { get; set; }
        public string? CompanyName { get; set; }
        public string CompanyAddress { get; set; } = null!;
        public string CompanyTaxNumber { get; set; } = null!;
        public string CompanyPhone { get; set; } = null!;
        public string CompanyCommercial { get; set; } = null!;
    }
}
