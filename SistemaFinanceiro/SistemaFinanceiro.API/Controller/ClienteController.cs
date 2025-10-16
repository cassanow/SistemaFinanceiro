using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaFinanceiro.SistemaFinanceiro.Application.DTO;
using SistemaFinanceiro.SistemaFinanceiro.Application.Interfaces;
using SistemaFinanceiro.SistemaFinanceiro.Domain.Entities;

namespace SistemaFinanceiro.SistemaFinanceiro.API.Controller;

[Route("v1/[controller]")]
[ApiController]
public class ClienteController : Microsoft.AspNetCore.Mvc.Controller
{
    private readonly IClienteRepository _clienteRepository;

    public ClienteController(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }
    
    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAllClientes()
    {
        var clientes = await _clienteRepository.GetAll();
        
        if(!clientes.Any())
            return NotFound();
        
        return Ok(clientes);
    }

    [HttpGet("GetById/{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var cliente = await _clienteRepository.GetById(id);

        var existe = await _clienteRepository.ClienteExists(id);
        
        if(!existe)
            return NotFound();
        
        return Ok(cliente);
    }

    [HttpPost("Register")]
    public async Task<IActionResult> RegisterCliente([FromBody] CreateClienteDTO dto)
    {
        var cliente = await _clienteRepository.GetByCPF(dto.CPF);

        var existe = await _clienteRepository.ClienteExists(cliente.Id);
        
        if(existe)
            return BadRequest();
        
        if(!ModelState.IsValid)
           return BadRequest(ModelState);
       
        cliente.CPF = dto.CPF;
        cliente.Nome = dto.Nome;
        cliente.Email = dto.Email;
        cliente.Telefone = dto.Telefone;
        cliente.Endereco = dto.Endereco;
        cliente.DataNascimento = dto.DataNascimento;
        
       await _clienteRepository.Add(cliente);
        
       return Ok(dto);
    }

    [HttpPost("Update/{id:int}")]
    public async Task<IActionResult> UpdateCliente(int id, CreateClienteDTO dto)
    {
        var cliente = await _clienteRepository.GetById(id);
        
        var existe = await _clienteRepository.ClienteExists(cliente.Id);
        
        if(!existe)
            return NotFound();
        
        cliente.Nome = dto.Nome;
        cliente.Email = dto.Email;
        cliente.Telefone = dto.Telefone;
        cliente.Endereco = dto.Endereco;
        cliente.DataNascimento = dto.DataNascimento;
        await _clienteRepository.Update(cliente);
        
        return Ok(dto);
    }
    
    [HttpDelete("Delete/{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var cliente = await _clienteRepository.GetById(id);
        
        var existe = await _clienteRepository.ClienteExists(cliente.Id);
        
        if(!existe)
            return NotFound();

        await _clienteRepository.Delete(cliente);
        
        return Ok();
    }
}