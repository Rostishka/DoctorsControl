using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using DAL.Models.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace DAL.Entity
{
    public class PatientEntity : IEntity<int>
    {
        public int Id{ get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ICollection<AppointmentEntity> Apointments { get; set; }
        public ICollection<ReviewEntity> Reviews { get; set; } 




        /// <summary>
        /// Navigation property for the roles this user belongs to.
        /// </summary>
        //public virtual ICollection<IdentityUserRole<string>> Roles { get; set; }
        /// <summary>
        /// Navigation property for the claims this user possesses.
        /// </summary>
        //public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }
    }
}
