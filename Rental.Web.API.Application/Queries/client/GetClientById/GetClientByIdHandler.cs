using MediatR;
using Rental.Web.API.Domain.Abstractions;
using Rental.Web.API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rental.Web.API.Application.Queries.client.GetClientById
{
    class GetClientByIdHandler : IRequestHandler<GetClientById, Clients>
    {
        private readonly IClientRepository _clientRepository;

        public GetClientByIdHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<Clients> Handle(GetClientById request, CancellationToken cancellationToken)
        {
            return await _clientRepository.GetById(request.Id);
        }
    }
}
