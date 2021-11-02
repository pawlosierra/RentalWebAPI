using MediatR;
using Rental.Web.API.Domain.Abstractions;
using Rental.Web.API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rental.Web.API.Application.Commands.client.DeleteClient
{
    public class DeleteClientHandler : IRequestHandler<DeleteClient, Clients>
    {
        private readonly IClientRepository _clientRepository;
        public DeleteClientHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<Clients> Handle(DeleteClient request, CancellationToken cancellationToken)
        {
            return await _clientRepository.Delete(request.Id);
        }
    }
}
