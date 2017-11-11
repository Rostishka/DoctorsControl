using System;
using System.Collections.Generic;
using System.Text;
using DAL.Models.Interfaces;

namespace DAL.Entity
{
    public class EducationEntity : IEntity
    {
        public int Id { get; set; }
        public string Place{ get; set; }
        public string Speciality{ get; set; }
        public int GraduateYear{ get; set; }
    }
}
