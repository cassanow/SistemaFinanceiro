using SistemaFinanceiro.SistemaFinanceiro.Domain.Entities;

namespace SistemaFinanceiro.SistemaFinanceiro.Application.Interfaces;

public interface IClienteRepository
{
    Task<bool> Add(Cliente cliente);
    
    Task<bool> Update(Cliente cliente);
    
    Task<bool> Delete(Cliente cliente);
    
    Task<Cliente> GetById(int id);
    
    Task<bool> ClienteExists(int id);
}