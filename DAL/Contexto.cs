using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using RegistroEF2.Entidades;


namespace RegistroEF2.DAL
{
    class Contexto : DbContext
    {
        public DbSet<Persona> Personas { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server = ./SlqExpress; Database = PersobaDb; Trusted_Connection = true;");
        }
    }
}
