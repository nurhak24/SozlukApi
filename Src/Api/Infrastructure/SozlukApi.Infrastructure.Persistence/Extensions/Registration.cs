using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SozlukApi.Api.Application.Interfaces;
using SozlukApi.Infrastructure.Persistence.Context;
using SozlukApi.Infrastructure.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SozlukApi.Infrastructure.Persistence.Extensions
{
    public static class Registration
    {
        public static IServiceCollection AddInfrastructureRegistration(this IServiceCollection services,IConfiguration configuration)
        {

            services.AddDbContext<SozlukApiContext>(conf =>
            {
                var connStr = configuration["ConnectionStrings"];

                conf.UseSqlServer(connStr, opt =>
                {
                    opt.EnableRetryOnFailure();

                });

            });

            //var seedData = new SeedData();
            //seedData.SeedAsync(configuration).GetAwaiter().GetResult();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IEntryVoteRepository, EntryVoteRepository>();
            services.AddScoped<IEntryCommentFavoriteRepository, EntryCommentFavoriteRepository>();
            services.AddScoped<IEntryFavoriteRepository, EntryFavoriteRepository>();
            services.AddScoped<IEntryCommentVoteRepository, EntryCommentVoteRepository>();
            services.AddScoped<IEntryCommentRepository, EntryCommentRepository>();
            services.AddScoped<IEmailConfirmationRepository, EmailConfirmationRepository>();
            services.AddScoped<IEntryRepository, EntryRepository>();

            return services;
        }

    }
}
