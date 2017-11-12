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
        public string DoctorId { get; set; }
        public string PatientId { get; set; }
    }
}
