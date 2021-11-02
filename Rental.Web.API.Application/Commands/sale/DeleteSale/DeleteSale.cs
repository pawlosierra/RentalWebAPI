using MediatR;
using Rental.Web.API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rental.Web.API.Application.Commands.sale.DeleteSale
{
    public class DeleteSale : IRequest<Sales>
    {
        public DeleteSale(long id)
        {
            Id = id;
        }
        public long Id { get; set; }

    }
}
