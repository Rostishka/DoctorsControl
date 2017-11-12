using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DAL.Entity;

namespace DAL.Models.ManageViewModels
{
    public class IndexViewModel
    {
        public string Username { get; set; }

        public bool IsEmailConfirmed { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }

        public int Age { get; set; }
        public string JobTitle { get; set; }
        public string Information { get; set; }
        public string Location { get; set; }
        public string CurrentWorkPlace { get; set; }
        public string Procedures { get; set; }
        public string Educations { get; set; }
        public string PreviousExperience { get; set; }

        public string StatusMessage { get; set; }
    }
}
