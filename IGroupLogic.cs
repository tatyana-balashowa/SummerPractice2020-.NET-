using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
namespace Gym.BLL
{
    public interface IGroupLogic
    {
        IEnumerable<Group> GetGroups();
        IEnumerable<Group> GetNeedGroups(int idGroup);
        IEnumerable<Group> GetNeedGroups(string name);
        IEnumerable<int> SelectDeletedGroup(string name);
        IEnumerable<int> GetNeedClientByGroup(string nameGroup, int idClient);
        void AddGroup(Group group);
        void AddClientByGroup(string nameGroup, int idClient);
        void RemoveGroup(int idGroup);
    }
}
