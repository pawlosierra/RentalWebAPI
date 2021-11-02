using MediatR;
using Rental.Web.API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rental.Web.API.Application.Commands.client.UpDateClient
{
    public class UpDateClient : IRequest<Clients>
    {
        public UpDateClient(Clients clients, int id)
        {
            Clients = clients;
            Id = id;
        }
        public Clients Clients { get; set; }
        public int Id { get; set; }
    }
}
