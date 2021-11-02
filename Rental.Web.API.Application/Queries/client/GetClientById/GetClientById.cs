using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Rental.Web.API.Domain.Entities;

namespace Rental.Web.API.Application.Queries.client.GetClientById
{
    public class GetClientById : IRequest<Clients>
    {
        public GetClientById(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
