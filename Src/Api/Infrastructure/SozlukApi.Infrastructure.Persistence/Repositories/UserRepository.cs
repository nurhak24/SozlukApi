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
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(SozlukApiContext dbContext) : base(dbContext)
        {
        }
    }
}
