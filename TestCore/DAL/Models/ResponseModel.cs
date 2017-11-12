using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class ResponseModel<T>
    {
        public T Data{ get; set; }
        public bool IsDoctor{ get; set; }
    }
}
