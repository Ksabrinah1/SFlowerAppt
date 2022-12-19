using Microsoft.AspNetCore.Identity;

namespace SapphireApp.Users
{
    public class MyUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
