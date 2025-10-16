using System.ComponentModel.DataAnnotations;

namespace SistemaFinanceiro.SistemaFinanceiro.Domain.Entities;

public class Cliente
{
    [Key]
    public int Id { get; set; }
    
    public string Nome { get; set; }
    
    public string CPF { get; set; }
    
    public string Email { get; set; }
    
    public string Telefone { get; set; }
    
    public string Endereco { get; set; }
    
    public DateTime DataNascimento { get; set; }
    
    public ICollection<Conta> Contas { get; set; }
}