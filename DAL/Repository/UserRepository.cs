using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using DAL.Data;
using DAL.Entity;
using DAL.Interface;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace DAL.Repository
{
    public class UserRepository : IUserRepository<User>
    {
        private readonly ApplicationDbContext _context;
        private readonly AppSettings _appSettings;

        public UserRepository(IOptions<AppSettings> appSettings, ApplicationDbContext context)
        {
            _appSettings = appSettings.Value;
            _context = context;
        }


        public User Authenticate(User userParam)
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
        }


        public bool Insert(User user)
        {
            var userDb = _context.UsersApi.SingleOrDefault(x => x.UserName == user.UserName
                                                                && x.Password == user.Password);
            if (userDb != null)
                return false;
            _context.UsersApi.Add(user);
            _context.SaveChanges();
            return true;
        }
    }
}
