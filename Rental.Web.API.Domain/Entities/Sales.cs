using System;
using System.Collections.Generic;
using System.Text;

namespace Rental.Web.API.Domain.Entities
{
    public class Sales
    {
        public Sales()
        {
            Date = DateTime.UtcNow;
        }
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public int ClientId { get; set; }
        public long Total { get; set; }
        public List<Concepts> Concepts { get; set; }

        public long TotaSaleCalculation(List<Concepts> concepts)
        {
            long calcul = 0;
            long total = 0;
            foreach (var item in concepts)
            {
                calcul = item.Quantity * item.Unitprice;
                total = total + calcul;
            }
            return total;
        }
    }
}
