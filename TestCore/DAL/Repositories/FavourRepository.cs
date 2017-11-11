using System.Threading.Tasks;
using DAL;
using DAL.Models.Interfaces;
using DAL.Repositories;

namespace DataAccessLayer.Repositories
{
    public class FavourRepository : BaseRepository<IEntity>
    {
        /// <summary>
        /// Here you create repository that operate your Entity that 
        /// inherits from IEntity interface
        /// </summary>
        /// <param name="context"></param>
        /// <param name="mapper"></param>
        public FavourRepository(ApplicationDbContext context) : base(context)
        {
            //Context.Favours.Include(f => f.AsksForFavours).Load();   
        }

        /// <summary>
        /// You can override methods defined in BaseRepository as you wish
        /// </summary>
        /// <param name="id">identificator of item to delete</param>
        /// <returns></returns>
        public override Task DeleteAsync(int id)
        {
            var identificator = id;
            return base.DeleteAsync(id);
        }
    }
}
