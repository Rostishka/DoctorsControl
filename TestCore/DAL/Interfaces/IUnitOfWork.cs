using System.Threading.Tasks;
using AutoMapper;
using DataAccessLayer.Repositories;
using DAL;
using DAL.Repositories;
using DAL.Repositories.Interfaces;

namespace DAL.Interfaces
{
    public interface IUnitOfWork
    {
        ApplicationDbContext Context{ get; set; }
        IMapper Mapper { get; set; }

       // AskForFavourRepository AskForFavourRepository { get; }
        FavourRepository FavourRepository { get; }
        ICustomerRepository Customers { get; }


        void Dispose();
        void Save();
        Task<int> SaveAsync();
    }
}