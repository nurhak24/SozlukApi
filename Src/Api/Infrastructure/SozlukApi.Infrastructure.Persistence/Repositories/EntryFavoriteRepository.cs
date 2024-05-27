using SozlukApi.Api.Application.Interfaces;
using SozlukApi.Api.Domain.Models;
using SozlukApi.Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SozlukApi.Infrastructure.Persistence.Repositories
{
    public class EntryFavoriteRepository : GenericRepository<EntryFavorite>, IEntryFavoriteRepository
    {
        public EntryFavoriteRepository(SozlukApiContext dbContext) : base(dbContext)
        {
        }
    }
}
