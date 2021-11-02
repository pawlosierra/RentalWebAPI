using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Rental.Web.API.Domain.Abstractions;
using Rental.Web.API.Domain.Entities;
using Rental.Web.API.Infrastructure.Data;
using Rental.Web.API.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rental.Web.API.Infrastructure.Repository
{
    public class SaleRepository : ISaleRepository
    {
        private readonly LESAContext _lESAContext;
        private readonly IMapper _mapper;

        public SaleRepository(LESAContext lESAContext, IMapper mapper)
        {
            _lESAContext = lESAContext;
            _mapper = mapper;
        }
        public async Task<Sales> Delete(long id)
        {
            var saleExist = await SaleExist(id);
            bool saleExistInConcepts = true;
            saleExistInConcepts = await SaleExistInConcepts(saleExist);
                
            _lESAContext.Sales.Remove(saleExist);
            await _lESAContext.SaveChangesAsync();
            var resp = _mapper.Map<Sales>(saleExist);
           return resp;
             
            
        }

        public async Task<IEnumerable<Sales>> GetAll()
        {
            var lstsales = await _lESAContext.Sales.ToListAsync();
            var resp = _mapper.Map<IEnumerable<Sales>>(lstsales);
            return resp;
        }

        public async Task<Sales> GetById(long id)
        {
            var saleExist = await SaleExist(id);
            var resp = _mapper.Map<Sales>(saleExist);
            return resp;
        }

        public async Task<Sales> Insert(Sales sales)
        {
            sales.Total = sales.TotaSaleCalculation(sales.Concepts);
         
            var sale = _mapper.Map<Sale>(sales);
            _lESAContext.Sales.Add(sale);
            await _lESAContext.SaveChangesAsync();
            return sales;
        }

        public async Task<Sales> UpDate(Sales sales, long id)
        {
            var saleExist = await SaleExist(id);
            var saleUpDate = _mapper.Map<Sale>(sales);
            saleExist.ClientId = saleUpDate.ClientId;
            _lESAContext.Sales.Update(saleExist);
            await _lESAContext.SaveChangesAsync();
            return sales;
        }

        private async Task<Sale> SaleExist(long id)
        {
            var salesExist = await _lESAContext.Sales.FindAsync(id);
            if (salesExist == null)
            {
                throw new ArgumentException("The Sale not exist");
            }
            return salesExist;
        }

        private async Task<bool> SaleExistInConcepts(Sale saleExist)
        {
            var saleExistInConcepts = _lESAContext.Concepts
                 .Where(x => x.SaleId == saleExist.Id).ToList();
            if(saleExistInConcepts != null)
            {
                foreach(var sale in saleExistInConcepts)
                {
                    _lESAContext.Concepts.Remove(sale);
                    await _lESAContext.SaveChangesAsync();
                }
            }
            return false;
        }
    }
}
