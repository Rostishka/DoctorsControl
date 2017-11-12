using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using DAL.Models;
using DAL.Models.Interfaces;

namespace DAL.Entity
{
    public class ReviewEntity : IEntity<int>
    {
        public int Id { get; set; }
        public int Mark{ get; set; }
        public string Advantage { get; set; }
        public string Disadvantage { get; set; }
        public string Comment { get; set; }
        public string PatientEmail { get; set; }

        public ApplicationUser ApplicationUser{ get; set; }
        public string ApplicationUserId{ get; set; }

        public ApplicationUser Patient { get; set; }
        public string PatientId { get; set; }
        
    }
}
