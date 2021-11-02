using MediatR;
using Rental.Web.API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rental.Web.API.Application.Commands.client.DeleteClient
{
    public class DeleteClient : IRequest<Clients>
    {
        public DeleteClient(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
