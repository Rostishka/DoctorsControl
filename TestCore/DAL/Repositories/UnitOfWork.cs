using System;
using System.Threading.Tasks;
using AutoMapper;
using DataAccessLayer.Repositories;
using DAL;
using DAL.Repositories;
using IUnitOfWork = DAL.Interfaces.IUnitOfWork;

namespace DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public ApplicationDbContext Context { get; set; }// = new MSContext("Server=ROSTIKASUS; Database=MagnisSpaceDB; Integrated Security=True");

        //private AskForFavourRepository _askForFavourRepository;

        //private FavourRepository _favourRepository;

        private ReviewsRepository _reviewsRepository;

        private UserRepository _userRepository;

        private AppointmentRepository _appointmentRepository;
        public IMapper Mapper{ get; set; }

        public UnitOfWork(/*IMapper mapper, */ApplicationDbContext context)
        {
           // Mapper = mapper;
            Context = context;
        }

        //public AskForFavourRepository AskForFavourRepository
        //{
        //    get
        //    {
        //        if (_askForFavourRepository != null) return _askForFavourRepository;
        //        else
        //        {
        //            return new AskForFavourRepository(Context, Mapper);
        //        }
        //    }
        //}

        //public FavourRepository FavourRepository
        //{
        //    get
        //    {
        //        return _favourRepository ?? new FavourRepository(Context);
        //    }
        //}

        public ReviewsRepository ReviewsRepository
        {
            get
            {
                return _reviewsRepository ?? new ReviewsRepository(Context);
            }
        }

        public UserRepository UserRepository
        {
            get
            {
                return _userRepository ?? new UserRepository(Context);
            }
        }

        public AppointmentRepository AppointmentRepository
        {
            get
            {
                return _appointmentRepository ?? new AppointmentRepository(Context);
            }
        }

        public async Task<int> SaveAsync()
        {
            return await Context.SaveChangesAsync();
        }

        public void Save()
        {
            Context.SaveChanges();
        }

        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
