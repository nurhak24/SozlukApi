using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SozlukApi.Common
{
    public class SozlukConstants
    {
        public const string RabbitMQHost = "localhost";
        public const string DefaultExchangeType = "direct";
        public const string UserExchangeName = "UserExchange";
        public const string UserEmailChangedQueueName = "UserExchangedQueue";
        public const string FavExchangeName = "FavExchangeName";
        public const string CreateEntryCommentFavQueueName = "CreateEntryCommentFavQueue";
        public const string CreateEntryFavQueueName = "CreateEntryFavQueue";
        public const string DeleteEntryFavQueueName = "DeleteEntryFavQueue";
        public const string DeleteEntryVoteQueueName = "DeleteEntryFavQueue";
        public const string DeleteEntryCommentFavQueueName = "DeleteEntryCommentFavQueue";
        public const string CreateEntryVoteQueueName = "CreateEntryVoteQueue";
        public const string CreateEntryCommentVoteQueueName = "CreateEntryCommentVoteQueue";
        public const string DeleteEntryCommentVoteQueueName = "DeleteEntryCommentVoteQueue";
        public const string VoteExchangeName = "VoteExchangeName";
    }
}
