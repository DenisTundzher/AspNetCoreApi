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
        //private readonly ApplicationDbContext _context; 
        /*
        private List<User> _users = new List<User>
        {
            new User { Id = 1, FirstName = "Test", LastName = "User", UserName = "test", Password = "test"}
        };*/
        
        //private readonly AppSettings _appSettings;

        private readonly IUserRepository<User> _userRepository;
        
        public UserService(IUserRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }
        /*
        public UserService(IOptions<AppSettings> appSettings, ApplicationDbContext context)//, IUserRepository<Owner> ownerRepository)
        {
            _appSettings = appSettings.Value;
            _context = context;
        }*/

        public User UserAuthenticate(User userParam)
        {
            return _userRepository.Authenticate(userParam);
        }
        
        public bool AddUser(User user)
        {
            return _userRepository.Insert(user);
        }

        /*
        public User Authenticate(User userParam)//string username, string password)
        {
            var user = _context.UsersApi.SingleOrDefault(x => x.UserName == userParam.UserName && x.Password == userParam.Password);

            if (user == null)
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            user.Password = null;

            return user;
        }*/
        /*
        public IEnumerable<User> GetAll()
        {
            // return users without passwords
            return _context.Users.Select(x => {
                x.Password = null;
                return x;
            });
        }*/
        
            /*
        public bool AddUser(User user)
        {
            var userDb = _context.UsersApi.SingleOrDefault(x => x.UserName == user.UserName 
                                                               && x.Password == user.Password);
            if(userDb != null)
                return false;
            _context.UsersApi.Add(user);
            _context.SaveChanges();
            return true;
        }*/
    }
}
