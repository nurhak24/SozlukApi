using MediatR;
using SozlukApi.Common.Events.Entry;
using SozlukApi.Common.Infrastructure.Exceptions;
using SozlukApi.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SozlukApi.Api.Application.Features.Commands.Entry.DeleteVote
{
    public class DeleteEntryVoteCommandHandler : IRequestHandler<DeleteEntryVoteCommand, bool>
    {
        public Task<bool> Handle(DeleteEntryVoteCommand request, CancellationToken cancellationToken)
        {
            QueueFactory.SendMessageToExchange(exchangeName: SozlukConstants.DeleteEntryVoteQueueName, exchangeType: SozlukConstants.DefaultExchangeType
               , queueName: SozlukConstants.DeleteEntryVoteQueueName, obj: new DeleteEntryVoteEvent()
               {

                   EntryId = request.EntryId,
                   CreateBy = request.UserId


               });

            return Task.FromResult(true);
        }
    }
}
