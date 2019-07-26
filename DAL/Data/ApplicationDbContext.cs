using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entity;
using DAL.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAL.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public Microsoft.EntityFrameworkCore.DbSet<User> UsersApi { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Owner> Owners { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Car> Cars { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<CarOwners> CarOwners { get; set; }
    }
}
