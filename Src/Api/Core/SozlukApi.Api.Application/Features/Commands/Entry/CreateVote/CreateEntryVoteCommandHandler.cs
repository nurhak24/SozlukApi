using MediatR;
using SozlukApi.Common.Events.Entry;
using SozlukApi.Common.Infrastructure.Exceptions;
using SozlukApi.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SozlukApi.Api.Application.Features.Commands.Entry.CreateVote
{
    public class CreateEntryVoteCommandHandler : IRequestHandler<CreateEntryVoteCommand, bool>
    {
        public Task<bool> Handle(CreateEntryVoteCommand request, CancellationToken cancellationToken)
        {
            QueueFactory.SendMessageToExchange(exchangeName: SozlukConstants.VoteExchangeName, exchangeType: SozlukConstants.DefaultExchangeType
               , queueName: SozlukConstants.CreateEntryVoteQueueName, obj: new CreateEntryVoteEvent()
               {

                   EntryId = request.EntryId,
                   CreateBy = request.CreatedBy,
                   VoteType = request.VoteType  

               });

            return Task.FromResult(true);

        }
    }
}
