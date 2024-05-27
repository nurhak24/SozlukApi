using MediatR.Pipeline;
using SozlukApi.Common.Events.Entry;
using SozlukApi.Common.Infrastructure.Exceptions;
using SozlukApi.Common;
using SozlukApi.Common.ViewModel.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SozlukApi.Common.Events.EntryComment;

namespace SozlukApi.Api.Application.Features.Commands.EntryComment.CreateVote
{
    public class CreateEntryCommentVoteHandler : IRequestExceptionHandler<CreateEntryCommentVoteCommand, bool>
    {


         
        public Task Handle(CreateEntryCommentVoteCommand request, Exception exception, RequestExceptionHandlerState<bool> state, CancellationToken cancellationToken)
        {
            QueueFactory.SendMessageToExchange(exchangeName: SozlukConstants.VoteExchangeName, exchangeType: SozlukConstants.DefaultExchangeType
               , queueName: SozlukConstants.CreateEntryCommentVoteQueueName, obj: new CreateEntryCommentVoteEvent()
               {

                   EntryCommentId = request.EntryCommentId,
                   CreateBy = request.CreatedBy,
                   VoteType = request.VoteType

               });

            return Task.FromResult(true);
        }
    }
}
