using Microsoft.EntityFrameworkCore;
using SistemaFinanceiro.Context;
using SistemaFinanceiro.SistemaFinanceiro.Application.Interfaces;
using SistemaFinanceiro.SistemaFinanceiro.Domain.Entities;

namespace SistemaFinanceiro.SistemaFinanceiro.Infrastructure.Repository;

public class ClienteRepository : IClienteRepository
{
    private readonly AppDbContext _context;

    public ClienteRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<bool> Add(Cliente cliente)
    {
        _context.Cliente.Add(cliente);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> Update(Cliente cliente)
    {
        var retorno = _context.Entry(cliente).State == EntityState.Modified;
        await _context.SaveChangesAsync();
        return retorno;
    }

    public async Task<bool> Delete(Cliente cliente)
    {
        _context.Cliente.Remove(cliente);
        await _context.SaveChangesAsync();
        return true;
    }
    public async Task<IEnumerable<Cliente>> GetAll()
    {
        return await _context.Cliente.ToListAsync();
    }
    public async Task<Cliente> GetById(int id)
    {
        return await _context.Cliente.Where(c => c.Id == id).FirstOrDefaultAsync();
    }

    public async Task<Cliente> GetByCPF(string cpf)
    {
        return await _context.Cliente.Where(c => c.CPF == cpf).FirstOrDefaultAsync();
    }

    public async Task<bool> ClienteExists(int id)
    {
        return await _context.Cliente.AnyAsync(c => c.Id == id);
    }
}