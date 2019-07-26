using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entity;

namespace BL
{
    public interface IUserService
    {
        User UserAuthenticate(User userParam);
        bool AddUser(User user);
    }
}
