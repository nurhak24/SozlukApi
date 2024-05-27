using MediatR;
using SozlukApi.Common.ViewModel.Page;
using SozlukApi.Common.ViewModel.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SozlukApi.Api.Application.Features.Queries.GetEntriesComments
{
    public class GetEntryCommentsQuery : BasePagedQuery, IRequest<PagedViewModel<GetEntryCommentViewModel>>
    {
        public GetEntryCommentsQuery(Guid entryId,Guid? userId,int page, int pageSize) : base(page, pageSize)
        {
            UserId = userId;
            EntryId = entryId;
        }

        public Guid? UserId { get; set;}
        public Guid EntryId { get; set;}

    }
}
