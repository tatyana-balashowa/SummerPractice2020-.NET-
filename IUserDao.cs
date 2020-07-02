using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Gym.DAL
{
    public interface IUserDao
    {
        void registerUser(User user);

    }
}
