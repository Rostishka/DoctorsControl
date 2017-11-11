using System;
using System.Collections.Generic;
using System.Text;
using DAL.Models.Interfaces;

namespace DAL.Entity
{
    public class AppointmentEntity : IEntity
    {
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public DoctorEntity Doctor{ get; set; }
        public string DoctorId{ get; set; }
        public PatientEntity Patient{ get; set; }
        public string PatientId { get; set; }
        public string Comment { get; set; }
        public AppointmentStatuse ReviewStatuse { get; set; }
    }
}
