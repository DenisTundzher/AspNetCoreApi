using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entity;

namespace BL
{
    public interface IUserService
    {
        //User Authenticate(User userParam);//string username, string password);
        //IEnumerable<User> GetAll();
        //bool AddUser(User user);

        User UserAuthenticate(User userParam);
        bool AddUser(User user);
    }
}
