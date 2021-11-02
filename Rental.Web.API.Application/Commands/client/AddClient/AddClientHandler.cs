using MediatR;
using Rental.Web.API.Domain.Abstractions;
using Rental.Web.API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rental.Web.API.Application.Commands.client.AddClient
{
    public class AddClientHandler : IRequestHandler<AddClient, Clients>
    {
        private readonly IClientRepository _clientRepository;

        public AddClientHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }
        public async Task<Clients> Handle(AddClient request, CancellationToken cancellationToken)
        {
            return await _clientRepository.Insert(request.Clients);
        }
    }
}
