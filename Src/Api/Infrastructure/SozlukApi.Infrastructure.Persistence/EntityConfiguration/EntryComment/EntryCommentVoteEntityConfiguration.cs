﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SozlukApi.Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SozlukApi.Infrastructure.Persistence.EntityConfiguration.EntryComment
{
    public class EntryCommentVoteEntityConfiguration : BaseEntityConfiguration<Api.Domain.Models.EntryCommentVote>
    {
        public override void Configure(EntityTypeBuilder<Api.Domain.Models.EntryCommentVote> builder)
        {
            base.Configure(builder);

            builder.ToTable("entrycommentvote", SozlukApiContext.DEFAULT_SCHEMA);

            builder.HasOne(i => i.EntryComment).WithMany(i => i.EntryCommentVotes).HasForeignKey(i => i.EntryCommentId);
           
        }
    }
}
