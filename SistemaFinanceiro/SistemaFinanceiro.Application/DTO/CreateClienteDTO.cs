using System.ComponentModel.DataAnnotations;

namespace SistemaFinanceiro.SistemaFinanceiro.Application.DTO;

public class CreateClienteDTO
{
    [Required]
    [MaxLength(200)]
    public string Nome { get; set; }
    
    [Required]
    [StringLength(11, MinimumLength = 11)]
    public string CPF { get; set; }
    
    [Required]
    [EmailAddress(ErrorMessage = "Digite um email valido")]
    public string Email { get; set; }
    
    [Required]
    [StringLength(11, MinimumLength = 11)]
    public string Telefone { get; set; }
    
    [Required]
    public string Endereco { get; set; }
    
    [Required]
    public DateTime DataNascimento { get; set; } 
}