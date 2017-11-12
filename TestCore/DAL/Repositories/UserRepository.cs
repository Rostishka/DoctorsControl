using System;
using System.Collections.Generic;
using System.Text;
using DAL.Models;

namespace DAL.Repositories
{
    public class UserRepository : BaseRepository<ApplicationUser, string>
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
