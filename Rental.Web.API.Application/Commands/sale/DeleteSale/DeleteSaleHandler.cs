using MediatR;
using Rental.Web.API.Domain.Abstractions;
using Rental.Web.API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rental.Web.API.Application.Commands.sale.DeleteSale
{
    public class DeleteSaleHandler : IRequestHandler<DeleteSale, Sales>
    {
        private readonly ISaleRepository _saleRepository;

        public DeleteSaleHandler(ISaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }

        public async Task<Sales> Handle(DeleteSale request, CancellationToken cancellationToken)
        {
            return await _saleRepository.Delete(request.Id);
        }
    }
}
