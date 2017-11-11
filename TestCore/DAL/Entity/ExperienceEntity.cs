using System;
using System.Collections.Generic;
using System.Text;
using DAL.Models.Interfaces;

namespace DAL.Entity
{
    public class ExperienceEntity : IEntity
    {
        public int Id { get; set; }

        public DateTime StartTime{ get; set; }

        public DateTime? EndTime{ get; set; }

        public string Place{ get; set; }

        public string Description{ get; set; }
    }
}
