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
    public class EntryCommentEntityConfiguration : BaseEntityConfiguration<Api.Domain.Models.EntryComment>
    {

        public override void Configure(EntityTypeBuilder<Api.Domain.Models.EntryComment> builder)
        {
            base.Configure(builder);

            builder.ToTable("entrycomment", SozlukApiContext.DEFAULT_SCHEMA);

            builder.HasOne(i => i.CreatedBy).WithMany(i => i.EntryComments).HasForeignKey(i => i.CreatedById).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(i => i.Entry).WithMany(i => i.EntryComments).HasForeignKey(i => i.EntryId);
        }
    }
}
