using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TesteAtlantico.Domain.Interfaces.Repository
{
    public interface IBaseRepository<T> where T : class
    {
        Task Add(T item);
        Task Update(T item);
        Task Delete(Guid Id);
        Task<T> GetEntityById(Guid Id);
        Task<List<T>> List();
    }
}
