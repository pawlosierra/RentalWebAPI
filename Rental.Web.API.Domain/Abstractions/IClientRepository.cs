using Rental.Web.API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Rental.Web.API.Domain.Abstractions
{
    public interface IClientRepository
    {
        Task<IEnumerable<Clients>> GetAll();
        Task<Clients> GetById(int id);
        Task<Clients> Insert(Clients client);
        Task<Clients> UpDate(Clients client, int id);
        Task<Clients> Delete(int id);
    }
}
