using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Gym.DAL;
namespace Gym.BLL
{
    public class UserLogic: IUserLogic
    {
        private IUserDao userDao;
        public UserLogic()
        {
            userDao = new UserDaoDB();
        }
        public void registerUser (User user)
        {
            userDao.registerUser(user);
        }
    }
}
