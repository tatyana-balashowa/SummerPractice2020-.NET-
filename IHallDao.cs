using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
namespace Gym.DAL
{
    public interface IHallDao
    {
        IEnumerable<Hall> GetHalls();
        IEnumerable<Hall> GetNeedHalls(int idHall);
        IEnumerable<Hall> GetNeedHalls(string nameOfHall);
        void AddHall(Hall hall);
        void RemoveHall(int idHall);
    }
}
