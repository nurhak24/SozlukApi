using MediatR;
using MediatR.Pipeline;
using SozlukApi.Common.Events.EntryComment;
using SozlukApi.Common.Infrastructure.Exceptions;
using SozlukApi.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SozlukApi.Api.Application.Features.Commands.EntryComment.DeleteVote
{
    public class DeleteEntryCommentVoteCommandHandler : IRequestHandler<DeleteEntryCommentVoteCommand, bool>
    {
        public Task<bool> Handle(DeleteEntryCommentVoteCommand request, CancellationToken cancellationToken)
        {
            QueueFactory.SendMessageToExchange(exchangeName: SozlukConstants.DeleteEntryVoteQueueName, exchangeType: SozlukConstants.DefaultExchangeType
               , queueName: SozlukConstants.DeleteEntryCommentVoteQueueName, obj: new DeleteEntryCommentVoteEvent()
               {

                   EntryCommentId = request.EntryCommentId,
                   CreatedBy = request.UserId


               });

            return Task.FromResult(true);
        }
    }
}
