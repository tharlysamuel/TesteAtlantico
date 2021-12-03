using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TesteAtlantico.Domain.Entities;
using TesteAtlantico.Domain.Interfaces.Repository;
using TesteAtlantico.Domain.Interfaces.Services;

namespace TesteAtlantico.Service
{
    public class UsuarioService : IUsuarioService
    {
        private IUsuarioRepository _repository;
        public UsuarioService(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public async Task Add(Usuario Objeto)
        {
            await _repository.Add(Objeto);
        }
        public async Task Delete(Guid Id)
        {
            await _repository.Delete(Id);
        }
        public async Task<Usuario> GetEntityById(Guid Id)
        {
            return await _repository.GetEntityById(Id);
        }

        public async Task<List<Usuario>> List()
        {
            return await _repository.List();
        }

        public async Task Update(Usuario Objeto)
        {
            await _repository.Update(Objeto);
        }

    }

    


}
