using MediatR;
using SozlukApi.Common.Events.EntryComment;
using SozlukApi.Common.Infrastructure.Exceptions;
using SozlukApi.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SozlukApi.Common.Events.Entry;

namespace SozlukApi.Api.Application.Features.Commands.Entry.CreateFav
{
    public class CreateEntryFavCommandHandler : IRequestHandler<CreateEntryFavCommand, bool>
    {
        public Task<bool> Handle(CreateEntryFavCommand request, CancellationToken cancellationToken)
        {
            QueueFactory.SendMessageToExchange(exchangeName: SozlukConstants.FavExchangeName, exchangeType: SozlukConstants.DefaultExchangeType
               , queueName: SozlukConstants.CreateEntryFavQueueName, obj: new CreateEntryFavEvent()
               {

                   EntryId = request.EntryId.Value,
                   CreateBy = request.UserId

               });

            return Task.FromResult(true);
        }
    }
}
