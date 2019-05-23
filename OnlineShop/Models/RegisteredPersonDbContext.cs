using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Models
{
    public class RegisteredPersonDbContext : IdentityDbContext<RegisteredPerson>
    {
        public RegisteredPersonDbContext(DbContextOptions<RegisteredPersonDbContext> options)
           : base(options)
        {

        }
    }
}
