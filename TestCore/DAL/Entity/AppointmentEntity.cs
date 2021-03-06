﻿using System;
using System.Collections.Generic;
using System.Text;
using DAL.Models;
using DAL.Models.Interfaces;

namespace DAL.Entity
{
    public class AppointmentEntity : IEntity<int>
    {
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public ApplicationUser Doctor { get; set; }
        public string DoctorId{ get; set; }
        public ApplicationUser Patient { get; set; }
        public string PatientId { get; set; }
        public string Comment { get; set; }
        public AppointmentStatuse ReviewStatuse { get; set; }

        public AppointmentEntity(AppointmentEntity entity)
        {
            Id = entity.Id;
            Time = entity.Time;
            Doctor = entity.Doctor;
            DoctorId = entity.DoctorId;
            Patient = entity.Patient;
            PatientId = entity.PatientId;
            Comment = entity.Comment;
            ReviewStatuse = entity.ReviewStatuse;
        }

        public AppointmentEntity()
        {
            
        }
    }
}
