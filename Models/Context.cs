using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EstacionamentoWeb.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace EstacionamentoWeb.Models
{
    public class Context : IdentityDbContext<User>
    {
        public Context(DbContextOptions options) : base(options) { }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<Estacionamento> Estacionamentos { get; set; }
        public DbSet<Estacionar> Estacionados { get; set; }
        public DbSet<UsuarioCNPJ> UsuariosCnpj { get; set; }
    }
}
