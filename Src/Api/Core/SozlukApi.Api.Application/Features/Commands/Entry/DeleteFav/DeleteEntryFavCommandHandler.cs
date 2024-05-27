using MediatR;
using SozlukApi.Common.Events.Entry;
using SozlukApi.Common.Infrastructure.Exceptions;
using SozlukApi.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SozlukApi.Api.Application.Features.Commands.Entry.DeleteFav
{
    public class DeleteFavEntryCommandHandler : IRequestHandler<DeleteEntryFavCommand, bool>
    {
        public Task<bool> Handle(DeleteEntryFavCommand request, CancellationToken cancellationToken)
        {
            QueueFactory.SendMessageToExchange(exchangeName: SozlukConstants.DeleteEntryFavQueueName, exchangeType: SozlukConstants.DefaultExchangeType
                , queueName: SozlukConstants.DeleteEntryFavQueueName, obj: new DeleteEntryFavEvent()
                {

                    EntryId = request.EntryId,
                    CreateBy = request.UserId
                    

                });

            return Task.FromResult(true);
        }
    }
}
