using System;
using System.Collections.Generic;

#nullable disable

namespace Rental.Web.API.Infrastructure.Models
{
    public partial class Client
    {
        public Client()
        {
            Sales = new HashSet<Sale>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }
    }
}
