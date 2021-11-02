using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Rental.Web.API.DTOs
{
    public class ClientDTO
    {
        [Required]
        public string Name { get; set; }
    }
}
