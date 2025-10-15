using System.ComponentModel.DataAnnotations;

namespace SistemaFinanceiro.SistemaFinanceiro.Domain.Entities;

public class Conta
{
    [Key]
    public int Id { get; set; }
    
    public string Numero { get; set; }
    
    public decimal Saldo { get; set; }
    
    public DateTime DataAberturaa { get; set; }
    
    public int ClienteId { get; set; }
    
    public Cliente Cliente { get; set; } = null;
}