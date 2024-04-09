using Client.Model;

namespace Client.Service
{
    public interface IClientService
    {
        ClientModel CreateClient(ClientModel newClient);
        ClientModel GetClientById(int clientId);
        List<ClientModel> SearchClients(string firstName, string idNumber, string phone);
        ClientModel UpdateClient(int clientId, ClientModel client);
        bool RemoveClient(int clientId);
    }
}