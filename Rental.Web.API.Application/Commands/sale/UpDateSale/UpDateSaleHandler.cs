using MediatR;
using Rental.Web.API.Domain.Abstractions;
using Rental.Web.API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rental.Web.API.Application.Commands.sale.UpDateSale
{
    public class UpDateSaleHandler : IRequestHandler<UpDateSale, Sales>
    {
        private readonly ISaleRepository _saleRepository;

        public UpDateSaleHandler(ISaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }

        public async Task<Sales> Handle(UpDateSale request, CancellationToken cancellationToken)
        {
            return await _saleRepository.UpDate(request.sales, request.Id);
        }
    }
}
