using System;
using AutoMapper;
using DAL.Models.Interfaces;
using DAL.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class AskForFavourRepository : BaseRepository<IEntity>
    {
        public IMapper Mapper{ get; set; }
        public AskForFavourRepository(ApplicationDbContext context, IMapper mapper) : base(context)
        {
            Mapper = mapper;
            //Context.AsksForFavour.Include(p => p.Favour).Load();
            //Context.AsksForFavour.Include(p => p.User).Load();
        }

        public override async void Update(int id, IEntity item)
        {
            var findItem = await DbSet.FirstOrDefaultAsync(x => x.Id.Equals(id));

            if (findItem is null)
                throw new Exception("Item not found");

            item.Id = id;

            Mapper.Map(item, findItem);
        }
    }
}
