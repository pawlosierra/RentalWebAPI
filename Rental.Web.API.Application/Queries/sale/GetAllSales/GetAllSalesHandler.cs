using MediatR;
using Rental.Web.API.Domain.Abstractions;
using Rental.Web.API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rental.Web.API.Application.Queries.sale.GetAllSales
{
    public class GetAllSalesHandler : IRequestHandler<GetAllSales, IEnumerable<Sales>>
    {
        private readonly ISaleRepository _saleRepository;
        public GetAllSalesHandler(ISaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }

        public async Task<IEnumerable<Sales>> Handle(GetAllSales request, CancellationToken cancellationToken)
        {
            return await _saleRepository.GetAll();
         
        }
    }
}
