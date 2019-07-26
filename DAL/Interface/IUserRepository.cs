using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entity;

namespace DAL.Interface
{
    public interface IUserRepository<T> where T : class
    {
        User Authenticate(User userData);
        bool Insert(User user);
    }
}