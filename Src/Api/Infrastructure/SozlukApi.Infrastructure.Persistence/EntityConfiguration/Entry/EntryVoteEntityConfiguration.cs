using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SozlukApi.Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SozlukApi.Infrastructure.Persistence.EntityConfiguration.Entry
{
    public class EntryVoteEntityConfiguration: BaseEntityConfiguration<Api.Domain.Models.EntryVote>
    {
        public override void Configure(EntityTypeBuilder<Api.Domain.Models.EntryVote> builder)
        {
            base.Configure(builder);

            builder.ToTable("entryvote", SozlukApiContext.DEFAULT_SCHEMA);

            builder.HasOne(i => i.Entry).WithMany(i => i.EntryVotes).HasForeignKey(i => i.EntryId);
        }


    }
}
