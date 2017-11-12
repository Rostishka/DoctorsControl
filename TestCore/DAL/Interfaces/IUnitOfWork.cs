using System.Threading.Tasks;
using AutoMapper;
using DataAccessLayer.Repositories;
using DAL.Repositories;

namespace DAL.Interfaces
{
    public interface IUnitOfWork
    {
        ApplicationDbContext Context{ get; set; }
        IMapper Mapper { get; set; }

       // AskForFavourRepository AskForFavourRepository { get; }
     //   FavourRepository FavourRepository { get; }
        ReviewsRepository ReviewsRepository { get; }

        UserRepository UserRepository { get; }

        AppointmentRepository AppointmentRepository { get; }

        void Dispose();
        void Save();
        Task<int> SaveAsync();
    }
}