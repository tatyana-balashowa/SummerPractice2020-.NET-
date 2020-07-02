using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
namespace Gym.DAL
{
    public interface IGroupDao
    {
        IEnumerable<Group> GetGroups();
        IEnumerable<Group> GetNeedGroups(string name);
        IEnumerable<Group> GetNeedGroups(int idGroup);
        IEnumerable<int> GetDeletedGroups(string name);
        IEnumerable<int> GetNeedClientByGroup(int idClient, string nameGroup);
        void AddGroup(Group Group);
        void AddClientByGroup(string nameGroup, int idClient);
        void RemoveGroup(int idGroup);

    }
}
