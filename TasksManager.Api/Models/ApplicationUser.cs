using Microsoft.AspNetCore.Identity;

namespace TasksManager.Api.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        /// <summary>
        /// Returns the full name of the user.
        /// </summary>
        /// <returns></returns>
        public override string ToString() => $"{FirstName} {LastName}";
    }
}
