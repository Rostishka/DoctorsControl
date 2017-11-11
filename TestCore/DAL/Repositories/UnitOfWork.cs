using System;
using System.Threading.Tasks;
using AutoMapper;
using DAL;
using DAL.Interfaces;
using DAL.Repositories;
using DAL.Repositories.Interfaces;
using IUnitOfWork = DAL.Interfaces.IUnitOfWork;

namespace DataAccessLayer.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public ApplicationDbContext Context { get; set; }// = new MSContext("Server=ROSTIKASUS; Database=MagnisSpaceDB; Integrated Security=True");

        private AskForFavourRepository _askForFavourRepository;

        private FavourRepository _favourRepository;

        private ICustomerRepository _customers;

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

        public FavourRepository FavourRepository
        {
            get
            {
                return _favourRepository ?? new FavourRepository(Context);
            }
        }

        public ICustomerRepository Customers
        {
            get
            {
                if (_customers == null)
                    _customers = new CustomerRepository(Context);

                return _customers;
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
