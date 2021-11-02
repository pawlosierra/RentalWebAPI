using Rental.Web.API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Rental.Web.API.Domain.Abstractions
{
    public interface ISaleRepository
    {
        Task<IEnumerable<Sales>> GetAll();
        Task<Sales> GetById(long id);
        Task<Sales> Insert(Sales sales);
        Task<Sales> UpDate(Sales sales, long id);
        Task<Sales> Delete(long id);
    }
}
