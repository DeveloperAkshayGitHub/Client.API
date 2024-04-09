using Client.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Client.Service
{
    public class ClientService : IClientService
    {
        private readonly List<ClientModel> _clients = new List<ClientModel>
        {
            new ClientModel
            {
                Id=1,
                FirstName = "John",
                LastName = "Doe",
                MobileNumber = "1234567890",
                IDNumber = "7803147453088",
                PhysicalAddress = "123 Main St, City"
            },
            new ClientModel
            {
                 Id=2,
                FirstName = "Jane",
                LastName = "Smith",
                MobileNumber = "9876543210",
                IDNumber = "7803142044080",
                PhysicalAddress = "456 Elm Ave, Town"
            },
            new ClientModel
            {
                 Id=3,
                FirstName = "Mohan",
                LastName = "Robet",
                MobileNumber = "1234567880",
                IDNumber = "7001015009087",
                PhysicalAddress = "123 Main St, City"
            },
        };
        public ClientService()
        {

        }
        public ClientModel GetClientById(int clientId)
        {
            return _clients.FirstOrDefault(a => a.Id == clientId);
        }
        public List<ClientModel> SearchClients(string firstName, string idNumber, string phone)
        {
            var clients = _clients.Where(a => a.FirstName.Equals(firstName) || a.FirstName.Equals(idNumber) || a.FirstName.Equals(phone));
            return clients.ToList();
        }
        public ClientModel CreateClient(ClientModel client)
        {
            if (!IsValidSouthAfricanId(client.IDNumber))
                throw new ValidationException("Invalid South African Id");
            if (IsSouthAfricanIdExist(client.IDNumber))
                throw new ValidationException("South African Id already exist");
            else
            {
                _clients.Add(client);
                return client;
            }
        }
        public ClientModel UpdateClient(int clientId, ClientModel client)
        {
            if (!IsValidSouthAfricanId(client.IDNumber))
                throw new ValidationException("Invalid South African Id");
            if (IsSouthAfricanIdExist(clientId, client.IDNumber))
                throw new ValidationException("South African Id already exist");
            else
            {
                var existingClient = _clients.FirstOrDefault(a => a.Id == clientId);
                if (existingClient != null)
                {
                    _clients.Remove(existingClient);
                    existingClient.FirstName = client.FirstName;
                    existingClient.LastName = client.LastName;
                    existingClient.IDNumber = client.IDNumber;
                    existingClient.MobileNumber = client.MobileNumber;
                    existingClient.PhysicalAddress = client.PhysicalAddress;

                    // You can add additional validation or business logic here

                    _clients.Add(existingClient); // Successfully updated
                }
                return existingClient;
            }
        }

        public bool RemoveClient(int clientId)
        {
            var existingClient = _clients.FirstOrDefault(a => a.Id == clientId);
            if (existingClient != null)
            {
                _clients.Remove(existingClient);
                return true;
            }
            return false;
        }


        #region "HelperMethods"
        private bool IsSouthAfricanIdExist(string idNumber)
        {
            return _clients.Any(a => a.IDNumber.Equals(idNumber));
        }
        private bool IsSouthAfricanIdExist(int clientId, string idNumber)
        {
            return _clients.Any(a => a.IDNumber.Equals(idNumber) && a.Id != clientId);
        }
        private bool IsValidSouthAfricanId(string idNumber)
        {
            if (idNumber.Length != 13)
            {
                return false;
            }
            if (!idNumber.All(char.IsDigit))
            {
                return false;
            }
            // int sum = 0;

            //for (int i = 0; i < 12; i++)
            //{
            //    sum += int.Parse(idNumber[i].ToString()) * weights[i];
            //}

            //int controlDigit = 10 - (sum % 10);
            //if (controlDigit == 10)
            //{
            //    controlDigit = 0;
            //}
            //return controlDigit == int.Parse(idNumber[12].ToString());
            return true;
        }

        #endregion
    }

}
