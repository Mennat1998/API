using Microsoft.AspNetCore.Identity;

namespace Day3API.Data.Models
{
    public class UsersEntity : IdentityUser
    {
        public string UserDepartment { get; set; }= string.Empty;
    }
}
