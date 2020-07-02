using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Gym.DAL;
namespace Gym.BLL
{
    public class CoachLogic: ICoachLogic
    {
        private ICoachDao coachDao;
        public CoachLogic ()
        {
            coachDao = new CoachDaoDB();
        }
        public IEnumerable <Coach> GetCoaches()
        {
            return coachDao.GetCoaches();
        }
        public IEnumerable <Coach> GetNeedCoaches(int idCoach)
        {
            return coachDao.GetNeedCoaches(idCoach); 
        }
        public IEnumerable <int> SelectIdNeedCoaches(string firstName, string lastName)
        {
            return coachDao.SelectIdNeedCoaches(firstName, lastName);
        }
        public IEnumerable <int> GetSportsByCoach (int idCoach)
        {
            return coachDao.GetSportsByCoach(idCoach);
        }
        public IEnumerable<string> GetNamesOfSportsByCoach(int idOfKind)
        {
            return coachDao.GetNamesOfSportsByCoach(idOfKind);
        }
        public IEnumerable<int> GetNeedNote(string nameGroup, int idCoach)
        {
            return coachDao.GetNeedNote(nameGroup, idCoach);
        }
        public int CountOfPeople(int idCoach, int day)
        {
            return coachDao.CountOfPeople(idCoach, day);
        }
        public void AddCoach(Coach coach)
        {
            coachDao.AddCoach(coach);
        }
        public void AddSportByCoach(int idCoach, string nameOfKind)
        {
            coachDao.AddSportByCoach(idCoach, nameOfKind);
        }
        public void AddGroupByCoach(int idCoach, string nameGroup)
        {
            coachDao.AddGroupByCoach(idCoach, nameGroup);
        }
        public void RemoveCoach (int idCoach)
        {
            coachDao.RemoveCoach(idCoach);
        }
    }
}
