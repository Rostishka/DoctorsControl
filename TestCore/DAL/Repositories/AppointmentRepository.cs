using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entity;

namespace DAL.Repositories
{
    public class AppointmentRepository : BaseRepository<AppointmentEntity, int>
    {
        public AppointmentRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
