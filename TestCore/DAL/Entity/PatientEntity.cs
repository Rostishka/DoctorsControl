using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using DAL.Models.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace DAL.Entity
{
    public class PatientEntity : IdentityUser
    {
        public string FullName { get; set; }
        public virtual List<AppointmentEntity> Apointments { get; set; } = new List<AppointmentEntity>();
        public virtual List<ReviewEntity> Reviews { get; set; } = new List<ReviewEntity>();

        /// <summary>
        /// Navigation property for the roles this user belongs to.
        /// </summary>
        public virtual ICollection<IdentityUserRole<string>> Roles { get; set; }

        /// <summary>
        /// Navigation property for the claims this user possesses.
        /// </summary>
        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }
    }
}
