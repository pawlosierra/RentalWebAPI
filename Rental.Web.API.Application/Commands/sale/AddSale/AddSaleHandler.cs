using MediatR;
using Rental.Web.API.Domain.Abstractions;
using Rental.Web.API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rental.Web.API.Application.Commands.sale.AddSale
{
    public class AddSaleHandler : IRequestHandler<AddSale, Sales>
    {
        private readonly ISaleRepository _saleRepository;

        public AddSaleHandler(ISaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }

        public async Task<Sales> Handle(AddSale request, CancellationToken cancellationToken)
        {
            return await _saleRepository.Insert(request.sales);
        }
    }
}
