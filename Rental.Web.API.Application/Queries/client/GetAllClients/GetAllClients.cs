using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Rental.Web.API.Domain.Entities;

namespace Rental.Web.API.Application.Queries.client.GetAllClients
{
    public class GetAllClients : IRequest<IEnumerable<Domain.Entities.Clients>>
    {

    }
}
