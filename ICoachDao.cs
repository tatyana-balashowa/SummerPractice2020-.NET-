using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
namespace Gym.DAL
{
    public interface ICoachDao
    {
        IEnumerable<Coach> GetCoaches();
        IEnumerable<Coach> GetNeedCoaches(int idCoach);
        IEnumerable<int> SelectIdNeedCoaches(string firstName, string lastName);
        IEnumerable<int> GetSportsByCoach(int idCoach);
        IEnumerable<string> GetNamesOfSportsByCoach(int idOfKind);
        IEnumerable<int> GetNeedNote(string nameGroup, int idCoach);
        int CountOfPeople(int idCoach, int day);
        void AddCoach(Coach coach);
        void AddSportByCoach(int idCoach, string nameOfKind);
        void AddGroupByCoach(int idCoach, string nameGroup);
        void RemoveCoach(int idCoach);
    } 
}
