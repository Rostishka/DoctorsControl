using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models.ReviewViewModels
{
    public class ReviewViewModel
    {
        public int Mark { get; set; }
        public string Advantage { get; set; }
        public string Disadvantage { get; set; }
        public string Comment { get; set; }
        public string PatientEmail { get; set; }
    }
}
