using Microsoft.EntityFrameworkCore;

namespace SistemaFinanceiro.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}
}