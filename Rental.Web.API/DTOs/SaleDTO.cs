using Rental.Web.API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Rental.Web.API.DTOs
{
    public class SaleDTO
    {
        [Required(ErrorMessage = "The field CliendId is required")]
        public int ClientId { get; set; }
        public List<ConceptDTO> Concepts { get; set; }
    }
    public class ConceptDTO
    {
        public int Quantity { get; set; }
        public long Unitprice { get; set; }
        public long Amount { get; set; }
        public int ProductId { get; set; }
    }
}
