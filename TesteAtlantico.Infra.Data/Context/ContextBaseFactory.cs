using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace TesteAtlantico.Infra.Data.Context
{
    public class ContextBaseFactory : IDesignTimeDbContextFactory<ContextBase>
    {
        public ContextBase CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ContextBase>();
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-7NNGT30;Initial Catalog=TesteAtlantico;User id=admin;Password=123456;");
            return new ContextBase(optionsBuilder.Options);
        }
    }
}
