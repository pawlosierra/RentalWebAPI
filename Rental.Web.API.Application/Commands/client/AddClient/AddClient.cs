using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Rental.Web.API.Domain.Entities;

namespace Rental.Web.API.Application.Commands.client.AddClient
{
    public class AddClient : IRequest<Clients>
    {
        public AddClient(Clients clients)
        {
            Clients = clients;
        }
        public Clients Clients { get; set; }
    }
}
