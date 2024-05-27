using Dapper;
using Microsoft.Data.SqlClient;
using SozlukApi.Common.Events.Entry;
using SozlukApi.Common.Events.EntryComment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SozlukApi.Projections.FavoriteService.Services
{
    public class FavoriteService
    {
        private readonly string ConnectionString;

        public FavoriteService(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public async Task CreateEntryFav(CreateEntryFavEvent @event)
        {

            using var connection = new SqlConnection(ConnectionString);
            await connection.ExecuteAsync("INSERT INTO entryFavorite (Id, EntryId, CreatedById,CreateDate) VALUES(@Id,@EntryId,@CreatedBy,GETDATE())",
                new
                {
                    Id = Guid.NewGuid(),
                    EntryId = @event.EntryId,
                    CreatedbyId = @event.CreateBy

                });

        }

        public async Task CreateEntryCommentFav(CreateEntryCommentFavEvent @event)
        {

            using var connection = new SqlConnection(ConnectionString);
            await connection.ExecuteAsync("INSERT INTO entryCommentFavorite (Id, EntryCommentId, CreatedById,CreateDate) VALUES(@Id,@EntryCommentId,@CreatedBy,GETDATE())",
                new
                {
                    Id = Guid.NewGuid(),
                    EntryId = @event.EntryCommentId,
                    CreatedbyId = @event.CreateBy

                });

        }

        public async Task DeleteEntryFav(DeleteEntryFavEvent @event)
        {

            using var connection = new SqlConnection(ConnectionString);
            await connection.ExecuteAsync("DELETE FROM EntryFavorite WHERE EntryId = @EntryId AND CreatedById = @CreatedById",
                new
                {
                    Id = Guid.NewGuid(),
                    EntryId = @event.EntryId,
                    CreatedById = @event.CreateBy

                });

        }
        public async Task DeleteEntryCommentFav(DeleteEntryCommentFavEvent @event)
        {

            using var connection = new SqlConnection(ConnectionString);
            await connection.ExecuteAsync("DELETE FROM EntryCommentFavorite WHERE EntryCommentId = @EntryCommentId AND CreatedById = @CreatedById",
                new
                {
                    Id = Guid.NewGuid(),
                    EntryId = @event.EntryCommentId,
                    CreatedById = @event.CreatedBy

                });

        }

    }
}
