using System;
using System.Collections.Generic;

namespace CompanyApi.Models
{
    public partial class Client
    {
        public Client()
        {
            ClientCompanies = new HashSet<ClientCompany>();
        }

        public int ClientId { get; set; }
        public string? ClientName { get; set; }
        public string ClientEmail { get; set; } = null!;
        public string ClientPhone { get; set; } = null!;
        public int ClientActiveStatus { get; set; }
        public string CreateAt { get; set; } = null!;

        public virtual ICollection<ClientCompany> ClientCompanies { get; set; }
    }
}
