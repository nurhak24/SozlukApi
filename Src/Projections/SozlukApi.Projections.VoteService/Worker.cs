using Microsoft.Extensions.Configuration;
using SozlukApi.Common.Events.Entry;
using SozlukApi.Common.Infrastructure.Exceptions;
using SozlukApi.Common;
using SozlukApi.Common.Events.EntryComment;

namespace SozlukApi.Projections.VoteService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IConfiguration configuration;

        public Worker(ILogger<Worker> logger,IConfiguration configuration)
        {
            _logger = logger;
            this.configuration = configuration;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var connStr = configuration.GetConnectionString("SqlServer");

            var voteService = new Services.VoteServices(connStr);

            QueueFactory.CreateBasicConsumer()
                .EnsureExchange(SozlukConstants.VoteExchangeName)
                .EnsureQueue(SozlukConstants.CreateEntryVoteQueueName, SozlukConstants.VoteExchangeName)
                .Receive<CreateEntryVoteEvent>(vote =>
                {
                    voteService.CreateEntryVote(vote).GetAwaiter().GetResult();
                    _logger.LogInformation($"Recived EntryId {vote.EntryId}");


                }).StartConsuming(SozlukConstants.CreateEntryVoteQueueName);


            QueueFactory.CreateBasicConsumer()
                .EnsureExchange(SozlukConstants.VoteExchangeName)
                .EnsureQueue(SozlukConstants.DeleteEntryVoteQueueName, SozlukConstants.VoteExchangeName)
                .Receive<DeleteEntryVoteEvent>(vote =>
                {
                    voteService.DeleteEntryVote(vote.EntryId,vote.CreateBy).GetAwaiter().GetResult();
                    _logger.LogInformation($"Recived EntryId {vote.EntryId}");


                }).StartConsuming(SozlukConstants.DeleteEntryVoteQueueName);


            QueueFactory.CreateBasicConsumer()
                .EnsureExchange(SozlukConstants.VoteExchangeName)
                .EnsureQueue(SozlukConstants.CreateEntryCommentVoteQueueName, SozlukConstants.VoteExchangeName)
                .Receive<CreateEntryCommentVoteEvent>(vote =>
                {
                    voteService.CreateEntryCommentVote(vote).GetAwaiter().GetResult();
                    _logger.LogInformation($"Recived EntryId {vote.EntryCommentId}");


                }).StartConsuming(SozlukConstants.CreateEntryCommentVoteQueueName);

            QueueFactory.CreateBasicConsumer()
                .EnsureExchange(SozlukConstants.VoteExchangeName)
                .EnsureQueue(SozlukConstants.DeleteEntryCommentVoteQueueName, SozlukConstants.VoteExchangeName)
                .Receive<DeleteEntryCommentVoteEvent>(vote =>
                {
                    voteService.DeleteEntryCommentVote(vote.EntryCommentId, vote.CreatedBy).GetAwaiter().GetResult();
                    _logger.LogInformation($"Recived EntryId {vote.EntryCommentId}");


                }).StartConsuming(SozlukConstants.DeleteEntryCommentVoteQueueName);
        }

    }
}
