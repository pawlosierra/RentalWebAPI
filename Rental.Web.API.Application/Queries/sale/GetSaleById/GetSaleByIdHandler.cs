using MediatR;
using Rental.Web.API.Domain.Abstractions;
using Rental.Web.API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rental.Web.API.Application.Queries.sale.GetSaleById
{
    public class GetSaleByIdHandler : IRequestHandler<GetSaleById, Sales>
    {
        private readonly ISaleRepository _saleRepository;
        public GetSaleByIdHandler(ISaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }

        public async Task<Sales> Handle(GetSaleById request, CancellationToken cancellationToken)
        {
            return await _saleRepository.GetById(request.Id);
        }
    }
}
