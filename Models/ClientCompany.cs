using System;
using System.Collections.Generic;

namespace CompanyApi.Models
{
    public partial class ClientCompany
    {
        public int CompanyId { get; set; }
        public long CompanyNumber { get; set; }
        public string? CompanyEmail { get; set; }
        public string? CompanyUsernam { get; set; }
        public string? CompanyPasswrod { get; set; }
        public string? CompanyName { get; set; }
        public string CompanyAddress { get; set; } = null!;
        public string CompanyTaxNumber { get; set; } = null!;
        public string CompanyPhone { get; set; } = null!;
        public string CompanyCommercial { get; set; } = null!;
        public int CompanyActiveStatus { get; set; }
        public string CreateAt { get; set; } = null!;
        public int? ClientId { get; set; }
        public int? CompanyZoneCount { get; set; }
        public string? CompanyLink { get; set; }

        public virtual Client? Client { get; set; }
    }
}
