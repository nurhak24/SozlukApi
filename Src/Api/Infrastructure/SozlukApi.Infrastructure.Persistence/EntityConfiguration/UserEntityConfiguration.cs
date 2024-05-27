using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SozlukApi.Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SozlukApi.Infrastructure.Persistence.EntityConfiguration
{
    public class UserEntityConfiguration : BaseEntityConfiguration<Api.Domain.Models.User>
    {
        public override void Configure(EntityTypeBuilder<Api.Domain.Models.User> builder)
        {
            base.Configure(builder);

            builder.ToTable("user", SozlukApiContext.DEFAULT_SCHEMA);


        }
    }
}
