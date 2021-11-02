using MediatR;
using Rental.Web.API.Domain.Abstractions;
using Rental.Web.API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rental.Web.API.Application.Commands.client.UpDateClient
{
    public class UpDateClientHandler : IRequestHandler<UpDateClient, Clients>
    {
        private readonly IClientRepository _clientRepository;
        public UpDateClientHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<Clients> Handle(UpDateClient request, CancellationToken cancellationToken)
        {
            return await _clientRepository.UpDate(request.Clients, request.Id);
        }
    }
}
