using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Rental.Web.API.Domain.Abstractions;
using Rental.Web.API.Domain.Entities;
using Rental.Web.API.Infrastructure.Data;
using Rental.Web.API.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rental.Web.API.Infrastructure.Repository
{
    public class ClientRepository : IClientRepository
    {
        private readonly LESAContext _lESAContext;
        private readonly IMapper _mapper;
        public ClientRepository(LESAContext lESAContext, IMapper mapper)
        {
            _lESAContext = lESAContext;
            _mapper = mapper;
        }

        public async Task<Clients> Delete(int id)
        {
            var clientExist = await ClientExist(id);
            _lESAContext.Clients.Remove(clientExist);
            await _lESAContext.SaveChangesAsync();
            return _mapper.Map<Clients>(clientExist);
        }

        public async Task<IEnumerable<Clients>> GetAll()
        {
            var lstClients = await _lESAContext.Clients
                .OrderByDescending(lst => lst.Id).ToListAsync();
            var resp = _mapper.Map<IEnumerable<Clients>>(lstClients);
            return resp;
        }

        public async Task<Clients> GetById(int id)
        {
            var clientExist = await ClientExist(id);
            var resp = _mapper.Map<Clients>(clientExist);
            return resp;


        }

        public async Task<Clients> Insert(Clients clients)
        {
            var client = _mapper.Map<Client>(clients);
            var resp = _lESAContext.Clients.Add(client);
            await _lESAContext.SaveChangesAsync();
            return clients;
        }

        public async Task<Clients> UpDate(Clients client, int id)
        {
            var clientExist = await ClientExist(id);
            clientExist.Name = client.Name;
            var resp = _lESAContext.Clients.Update(clientExist);
            await _lESAContext.SaveChangesAsync();
            return client;
        }
        
        //ClientExits?
        private async Task<Client> ClientExist(int id)
        {
            var clientExist = await _lESAContext.Clients.FindAsync(id);
            if(clientExist == null)
            {
                throw new Exception("The client is not found");
            }
            return clientExist;
        }
    }
}
