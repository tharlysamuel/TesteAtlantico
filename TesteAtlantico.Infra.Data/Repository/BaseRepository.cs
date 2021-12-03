using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TesteAtlantico.Domain.Interfaces.Repository;
using TesteAtlantico.Infra.Data.Context;

namespace TesteAtlantico.Infra.Data.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly ContextBase _context;
        private readonly DbSet<T> _dataSet;
        public BaseRepository(ContextBase context)
        {
            _context = context;
            _dataSet = _context.Set<T>();
        }

        public async Task Add(T Objeto)
        {
            await _dataSet.AddAsync(Objeto);
            await _context.SaveChangesAsync();

        }

        public async Task Delete(Guid Id)
        {
           var objeto = await GetEntityById(Id);
            _dataSet.Remove(objeto);
            await _context.SaveChangesAsync();
        }

        public async Task<T> GetEntityById(Guid Id)
        {
            return await _dataSet.FindAsync(Id);
        }

        public async Task<List<T>> List()
        {
            return await _dataSet.AsNoTracking().ToListAsync();
        }

        public async Task Update(T Objeto)
        {
            _dataSet.Update(Objeto);
            await _context.SaveChangesAsync();
        }
    }
}
