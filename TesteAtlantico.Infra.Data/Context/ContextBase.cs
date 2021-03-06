using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TesteAtlantico.Domain.Entities;
using TesteAtlantico.Infra.Data.Config;

namespace TesteAtlantico.Infra.Data.Context
{
    public class ContextBase : DbContext
    {
        public ContextBase(DbContextOptions<ContextBase> options) : base(options)
        {
        }
        public DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>(new UsuarioConfiguration().Configure);

        }
    }

}
