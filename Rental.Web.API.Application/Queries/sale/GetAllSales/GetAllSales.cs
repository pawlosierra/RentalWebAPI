using MediatR;
using Rental.Web.API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rental.Web.API.Application.Queries.sale.GetAllSales
{
    public class GetAllSales : IRequest<IEnumerable<Sales>>
    {
    }
}
