using Microsoft.AspNetCore.Identity;
using OnlineShop.Data;

namespace OnlineShop.Models
{
    public class RegisteredPerson : IdentityUser
    {
        public string FirstName{ get; set; }
        public string LastName { get; set; }
        public BloodGroup BloodGroup { get; set; }       
    } 
}
