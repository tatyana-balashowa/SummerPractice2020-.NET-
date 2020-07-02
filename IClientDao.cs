using System;
using System.Collections.Generic;
using Entities;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.DAL
{
    public interface IClientDao
    {
        IEnumerable<Client> GetClients();
        IEnumerable<Client> GetNeedClients(int idClient);
        void AddClient(Client client);
        void RemoveClient(int idClient);
    }
}
