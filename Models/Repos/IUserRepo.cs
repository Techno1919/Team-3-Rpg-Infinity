using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RpgInfinity.Models.Repos
{
    public interface IUserRepo
    {
        IEnumerable<User> GetAllUsers();

        bool SignUp(User user);
    }
}