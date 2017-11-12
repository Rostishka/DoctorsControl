using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Entity;
using DAL.Models.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace DAL.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser, IEntity<string>
    {
        public override string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string JobTitle { get; set; }
        public string Information { get; set; }
        public string Location { get; set; }
        public string CurrentWorkPlace { get; set; }
        public string Procedures { get; set; }
        public string Educations { get; set; }
        public string PreviousExperience { get; set; }
        public ICollection<ReviewEntity> Reviews { get; set; }
        public UserRole Role { get; set; }
    }
}
