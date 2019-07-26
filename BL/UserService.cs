using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using DAL;
using DAL.Data;
using DAL.Entity;
using DAL.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace BL
{
    public class UserService : IUserService
    {
        private readonly IUserRepository<User> _userRepository;
        
        public UserService(IUserRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }


        public User UserAuthenticate(User userParam)
        {
            return _userRepository.Authenticate(userParam);
        }
        
        public bool AddUser(User user)
        {
            return _userRepository.Insert(user);
        }
    }
}
