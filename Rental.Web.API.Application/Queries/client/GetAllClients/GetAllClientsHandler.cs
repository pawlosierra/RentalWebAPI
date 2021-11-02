using MediatR;
using Rental.Web.API.Domain.Abstractions;
using Rental.Web.API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rental.Web.API.Application.Queries.client.GetAllClients
{
    public class GetAllClientsHandler : IRequestHandler<GetAllClients, IEnumerable<Domain.Entities.Clients>>
    {
        private readonly IClientRepository _clientRepository;

        public GetAllClientsHandler(IClientRepository clientRepository)
        {
            this._clientRepository = clientRepository;
        }

        public async Task<IEnumerable<Domain.Entities.Clients>> Handle(GetAllClients request, CancellationToken cancellationToken)
        {
            return await _clientRepository.GetAll();
        }
    }
}
