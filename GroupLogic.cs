using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Gym.DAL;
namespace Gym.BLL
{
    public class GroupLogic:IGroupLogic
    {
        private IGroupDao groupDao;
        public GroupLogic()
        {
            groupDao = new GroupDaoDB();
        }
        public IEnumerable <Group> GetGroups()
        {
            return groupDao.GetGroups();
        }
        public IEnumerable <Group> GetNeedGroups(int idGroup)
        {
            return groupDao.GetNeedGroups(idGroup);
        }
        public IEnumerable <Group> GetNeedGroups (string name)
        {
            return groupDao.GetNeedGroups(name);
        }
        public IEnumerable<int> SelectDeletedGroup (string name)
        {
            return groupDao.GetDeletedGroups(name);
        }
        public IEnumerable<int> GetNeedClientByGroup(string nameGroup, int idClient)
        {
            return groupDao.GetNeedClientByGroup(idClient, nameGroup);
        }
        public void AddGroup (Group group)
        {
            groupDao.AddGroup(group);
        }
        public void AddClientByGroup(string name, int idCoach)
        {
            groupDao.AddClientByGroup(name, idCoach);
        }
        public void RemoveGroup (int idGroup)
        {
            groupDao.RemoveGroup(idGroup);
        }
    }
}
