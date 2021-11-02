using MediatR;
using Rental.Web.API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rental.Web.API.Application.Commands.sale.AddSale
{
    public class AddSale : IRequest<Sales>
    {
        public Sales sales;
        public AddSale(Sales sales)
        {
            this.sales = sales;
        }
    }
}
