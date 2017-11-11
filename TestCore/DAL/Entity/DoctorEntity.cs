using System;
using System.Collections.Generic;
using System.Text;
using DAL.Models;
using DAL.Models.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace DAL.Entity
{
    public class DoctorEntity :  IdentityUser
    {
        public string FullName { get; set; }
        public string JobTitle { get; set; }
        public int Age{ get; set; }
        public string Information{ get; set; }
        public string Location { get; set; }
        public ExperienceEntity CurrentWorkPlace { get; set; }
        public string Procedures { get; set; }
        public ICollection<EducationEntity> Educations { get; set; }
        public ICollection<ExperienceEntity> PreviousExperience { get; set; }
        public ICollection<ReviewEntity> Reviews{ get; set; }
    }
}
