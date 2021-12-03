using System;
using System.Collections.Generic;
using System.Text;

namespace TesteAtlantico.Domain.Entities
{
    public class Usuario
    {
        public Guid Id { get; set; } =  Guid.NewGuid();
        public string Nome { get; set; }
        public string Senha { get; set; }
        public int Idade { get; set; }

    }
}
