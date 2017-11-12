using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entity;

namespace DAL.Repositories
{
    public class ReviewsRepository : BaseRepository<ReviewEntity, int>
    {
        public ReviewsRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
