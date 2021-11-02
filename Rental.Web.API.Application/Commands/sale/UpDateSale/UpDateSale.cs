using MediatR;
using Rental.Web.API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rental.Web.API.Application.Commands.sale.UpDateSale
{
    public class UpDateSale : IRequest<Sales>
    {
        public UpDateSale(Sales sales, long id)
        {
            this.sales = sales;
            Id = id;
        }
        public Sales sales { get; set; }
        public long Id { get; set; }
    }
}
