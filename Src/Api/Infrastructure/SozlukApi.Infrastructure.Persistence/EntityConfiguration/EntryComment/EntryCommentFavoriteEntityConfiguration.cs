using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SozlukApi.Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SozlukApi.Infrastructure.Persistence.EntityConfiguration.EntryComment
{
    public class EntryCommentFavoriteEntityConfiguration : BaseEntityConfiguration<Api.Domain.Models.EntryCommentFavorite>
    {

        public override void Configure(EntityTypeBuilder<Api.Domain.Models.EntryCommentFavorite> builder)
        {
            base.Configure(builder);

            builder.ToTable("entrycommentfavorite", SozlukApiContext.DEFAULT_SCHEMA);

            builder.HasOne(i => i.EntryComment).WithMany(i => i.EntryCommentFavorites).HasForeignKey(i => i.EntryCommentId);
            builder.HasOne(i => i.CreatedUser).WithMany(i => i.EntryCommentFavorites).HasForeignKey(i => i.CreateById).OnDelete(DeleteBehavior.Restrict);


        }
    }
}

