using Dapper;
using Microsoft.Data.SqlClient;
using SozlukApi.Common.Events.Entry;
using SozlukApi.Common.Events.EntryComment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SozlukApi.Projections.VoteService.Services
{
    public class VoteServices
    {

        private readonly string ConnectionString;

        public VoteServices(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public async Task CreateEntryVote(CreateEntryVoteEvent vote)
        {
            await DeleteEntryVote(vote.EntryId, vote.CreateBy);

            using var connection = new SqlConnection(ConnectionString);

            await connection.ExecuteAsync("INSERT INTO ENTRYVOTE (Id, CreateDate,EntryId,VoteType,CreatedById) Values(@Id,GETDATE(),@EntryId,@VoteType,@CreatedBy)",
                new
                {

                    Id = Guid.NewGuid(),
                    EntryId = vote.EntryId,
                    VoteType = (int)vote.VoteType,
                    CreatedById = vote.CreateBy

                });

        }

        public async Task DeleteEntryVote(Guid entryId ,Guid userId)
        {

            using var connection = new SqlConnection(ConnectionString);
            await connection.ExecuteAsync("DELETE FROM EntryVote WHERE EntryId=@EntryId AND CREATEDBY =@UserId",
                new
                {
                    
                    EntryId = entryId,
                    UserId = userId

                });

        }

        public async Task CreateEntryCommentVote(CreateEntryCommentVoteEvent vote)
        {
            await DeleteEntryCommentVote(vote.EntryCommentId, vote.CreateBy);

            using var connection = new SqlConnection(ConnectionString);

            await connection.ExecuteAsync("INSERT INTO ENTRYVOTE (Id, CreateDate,EntryCommentId,VoteType,CreatedById) Values(@Id,GETDATE(),@EntryId,@VoteType,@CreatedBy)",
                new
                {

                    Id = Guid.NewGuid(),
                    EntryId = vote.EntryCommentId,
                    VoteType = (int)vote.VoteType,
                    CreatedById = vote.CreateBy

                });

        }

        public async Task DeleteEntryCommentVote(Guid entryCommentId, Guid userId)
        {

            using var connection = new SqlConnection(ConnectionString);
            await connection.ExecuteAsync("DELETE FROM EntryCommentVote WHERE EntryCommentId=@EntryCommentId AND CREATEDBY =@UserId",
                new
                {

                    EntryId = entryCommentId,
                    UserId = userId

                });

        }

    }
}
