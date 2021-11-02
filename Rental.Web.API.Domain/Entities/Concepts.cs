using System;
using System.Collections.Generic;
using System.Text;

namespace Rental.Web.API.Domain.Entities
{
    public class Concepts
    {
        public int Quantity { get; set; }
        public long Unitprice { get; set; }
        public long Amount { get; set; }
        public int ProductId { get; set; }
    }
}
