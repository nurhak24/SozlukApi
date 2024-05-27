using MediatR;
using MediatR.Pipeline;
using SozlukApi.Common.Events.Entry;
using SozlukApi.Common.Infrastructure.Exceptions;
using SozlukApi.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SozlukApi.Common.Events.EntryComment;

namespace SozlukApi.Api.Application.Features.Commands.EntryComment.DeleteFav
{
    public class DeleteEntryCommentFavCommandHandler : IRequestHandler<DeleteEntryCommentFavCommand, bool>
    {
        public Task<bool> Handle(DeleteEntryCommentFavCommand request, CancellationToken cancellationToken)
        {
            QueueFactory.SendMessageToExchange(exchangeName: SozlukConstants.DeleteEntryFavQueueName, exchangeType: SozlukConstants.DefaultExchangeType
                , queueName: SozlukConstants.DeleteEntryCommentFavQueueName, obj: new DeleteEntryCommentFavEvent()
                {

                    EntryCommentId = request.EntryCommentId,
                    CreatedBy = request.UserId


                });

            return Task.FromResult(true);
        }
    }
}
