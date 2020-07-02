using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Gym.DAL;
namespace Gym.BLL
{
    public class HallLogic:IHallLogic
    {
        private IHallDao hallDao;
        public HallLogic()
        {
            hallDao = new HallDaoDB();
        }
        public IEnumerable <Hall> GetHalls()
        {
            return hallDao.GetHalls();
        }
        public IEnumerable <Hall> GetNeedHalls(int idHall)
        {
            return hallDao.GetNeedHalls(idHall);
        }
        public IEnumerable <Hall> GetNeedHalls(string nameOfHall)
        {
            return hallDao.GetNeedHalls(nameOfHall);
        }
        public void AddHall (Hall hall)
        {
            hallDao.AddHall(hall);
        }
        public void RemoveHall (int idHall)
        {
            hallDao.RemoveHall(idHall);
        }
    }
}
