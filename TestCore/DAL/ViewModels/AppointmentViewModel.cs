using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entity;

namespace DAL.ViewModels
{
    public class AppointmentViewModel
    {
        public DateTime Time { get; set; }
        public string Comment { get; set; }
        public DoctorEntity Doctor { get; set; }
        public int DoctorId { get; set; }
        public PatientEntity Patient { get; set; }
        public int PatientId { get; set; }
    }
}
