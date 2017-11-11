using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using DAL.Models.Interfaces;

namespace DAL.Entity
{
    public class ReviewEntity : IEntity
    {
        public int Id { get; set; }
        public int Mark{ get; set; }
        public string Advantage { get; set; }
        public string Disadvantage { get; set; }
        public string Comment { get; set; }
        public string PatientEmail { get; set; }

        public PatientEntity Patient { get; set; }
        public int PatientId { get; set; }
        
    }
}
