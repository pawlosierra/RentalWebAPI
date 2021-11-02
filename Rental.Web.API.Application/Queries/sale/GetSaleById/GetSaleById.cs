using MediatR;
using Rental.Web.API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rental.Web.API.Application.Queries.sale.GetSaleById
{
    public class GetSaleById : IRequest<Sales>
    {
        public GetSaleById(long id)
        {
            Id = id;
        }
        public long Id { get; set; }

    }
}
