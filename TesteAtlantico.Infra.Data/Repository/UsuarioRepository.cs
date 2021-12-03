using System;
using System.Collections.Generic;
using System.Text;
using TesteAtlantico.Domain.Entities;
using TesteAtlantico.Domain.Interfaces.Repository;
using TesteAtlantico.Infra.Data.Context;

namespace TesteAtlantico.Infra.Data.Repository
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository 
    {
        public UsuarioRepository(ContextBase context) : base(context)
        {

        }
    }
}
