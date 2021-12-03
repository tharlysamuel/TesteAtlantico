using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TesteAtlantico.Domain.Entities;

namespace TesteAtlantico.Infra.Data.Config
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Nome).HasMaxLength(200).IsRequired();
            builder.Property(u => u.Senha).HasMaxLength(200).IsRequired();
            builder.Property(u => u.Idade).IsRequired();
        }
    }
}
