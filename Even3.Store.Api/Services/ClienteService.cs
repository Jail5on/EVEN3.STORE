using Even3.Store.Api.Models;

namespace Even3.Store.Api.Services;

public class ClienteService
{
    public List<Cliente> ClienteList { get; set; }
    public int Sequencia { get; set; }
    public ClienteService()
    {
        ClienteList = new List<Cliente>();
    }
    public async Task<Cliente> Inserir(Cliente cliente)
    {
        return await Task.Run(() =>
        {
            Sequencia++;
            cliente.Id = Sequencia;
            ClienteList.Add(cliente);
            return cliente;
        });
    }
    public async Task<Cliente?> Retornar(long id)
    {
        return await Task.Run(() =>
        {
            var clienteRecuperado = ClienteList
                                    .Where(c => c.Id == id)
                                    .FirstOrDefault();
            return clienteRecuperado;
        });
    }
    public async Task<Cliente[]> RetornarTodos()
    {
        return await Task.Run(() =>
        {
            var todos = ClienteList.ToArray();
            return todos;
        });
    }
    public async Task<Cliente?> Atualizar(int id, Cliente cliente)
    {
        var objetoAtual = await Retornar(id);

        if (objetoAtual != null)
        {
            var index = ClienteList.IndexOf(objetoAtual);

            cliente.Id = id;
            ClienteList[index] = cliente;
            return cliente;
        }

        return null;
    }
    public async Task Excluir(long id)
    {
        var clienteRecuperado = await Retornar(id);

        if (clienteRecuperado != null)
        {
            ClienteList.Remove(clienteRecuperado);
        }
    }
}

