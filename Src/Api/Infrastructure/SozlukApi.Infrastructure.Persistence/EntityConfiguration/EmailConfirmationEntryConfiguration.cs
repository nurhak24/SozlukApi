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
    public class EmailConfirmationEntryConfiguration : BaseEntityConfiguration<Api.Domain.Models.EmailConfirmation>
    {

        public override void Configure(EntityTypeBuilder<Api.Domain.Models.EmailConfirmation> builder)
        {
            base.Configure(builder);

            builder.ToTable("emailconfirmation", SozlukApiContext.DEFAULT_SCHEMA);


        }
    }
}
