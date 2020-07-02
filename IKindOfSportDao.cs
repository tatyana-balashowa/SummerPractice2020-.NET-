using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
namespace Gym.DAL
{
    public interface IKindOfSportDao
    {
        IEnumerable<KindOfSport> GetKindOfSports();
        IEnumerable<KindOfSport> GetNeedKindOfSports(int idKind);
        IEnumerable<KindOfSport> GetNeedKindOfSports(string name);
        IEnumerable <string> Schedule(string nameOfKind, int workingDay);
        void AddKindOfSport(KindOfSport kindOfSport);
        void RemoveKindOfSport(int idKindOfSport);
    }
}
