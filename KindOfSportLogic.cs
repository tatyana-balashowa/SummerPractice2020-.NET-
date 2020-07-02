using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Gym.DAL;
namespace Gym.BLL
{
    public class KindOfSportLogic: IKindOfSportLogic
    {
        private IKindOfSportDao kindOfSportDao;
        public KindOfSportLogic ()
        {
            kindOfSportDao = new KindOfSportDaoDB();
        }
        public IEnumerable <KindOfSport> GetKindOfSports()
        {
            return kindOfSportDao.GetKindOfSports();
        }
        public IEnumerable <KindOfSport> GetNeedKindOfSports(int idKind)
        {
            return kindOfSportDao.GetNeedKindOfSports(idKind);
        }
        public IEnumerable <KindOfSport> GetNeedKindOfSports (string name)
        {
            return kindOfSportDao.GetNeedKindOfSports(name);
        }
        public IEnumerable<string> Schedule(string nameOfKind, int day)
        {
            return kindOfSportDao.Schedule(nameOfKind, day);
        }
        public void AddKindOfSport (KindOfSport kindOfSport)
        {
            kindOfSportDao.AddKindOfSport(kindOfSport);
        }
        public void RemoveKindOfSport (int idKindOfSport)
        {
            kindOfSportDao.RemoveKindOfSport(idKindOfSport);
        }
    }
}
