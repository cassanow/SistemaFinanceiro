using Microsoft.EntityFrameworkCore;
using SistemaFinanceiro.SistemaFinanceiro.Domain.Entities;

namespace SistemaFinanceiro.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}
    
    public DbSet<Cliente> Cliente { get; set; }
    
    public DbSet<Conta> Conta { get; set; }
}