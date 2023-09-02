using Even3.Store.Api.Models;
using Even3.Store.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Even3.Store.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClienteController : ControllerBase
{
    private ClienteService ClienteService { get; set; }
    public ClienteController(ClienteService clienteService)
    {
        ClienteService = clienteService;
    }
    [HttpGet]
    public async Task<IActionResult> RetornarTodos()
    {
        var resultado = await ClienteService.RetornarTodos();
        return Ok(resultado);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> RetornarCliente(long id)
    {
        var resultado = await ClienteService.Retornar(id);
        return Ok(resultado);
    }

    [HttpPost]
    public async Task<IActionResult> InserirCliente(Cliente cliente)
    {
        var resultado = await ClienteService.Inserir(cliente);
        return Ok(resultado);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Alterar(int id, Cliente cliente)
    {
        var resultado = await ClienteService.Atualizar(id, cliente);
        return Ok(resultado);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Excluir(int id)
    {
        await ClienteService.Excluir(id);
        return Ok(new {
            Resposta = "Cliente excluído!"
        });
    }
}
