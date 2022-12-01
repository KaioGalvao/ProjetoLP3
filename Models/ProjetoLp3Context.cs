using Microsoft.EntityFrameworkCore;

namespace ProjetoLp3.Models;

public class ProjetoLp3Context : DbContext
{
    public DbSet<Cliente>? Clientes { get; set; }
    public DbSet<Vendedor>? Vendedores { get; set; }

    public DbSet<Peca>? Pecas { get; set; }

    public DbSet<Carro>? Carros { get; set; }

    public DbSet<Moto>? Motos { get; set; }

    public DbSet<Roda>? Rodas { get; set; }
    
    public ProjetoLp3Context(DbContextOptions<ProjetoLp3Context> options) : base(options)
    {
        
    }
}