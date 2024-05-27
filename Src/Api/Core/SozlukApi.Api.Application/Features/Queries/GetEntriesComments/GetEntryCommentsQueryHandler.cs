using MediatR;
using Microsoft.EntityFrameworkCore;
using SozlukApi.Api.Application.Interfaces;
using SozlukApi.Common.Infrastructure.Extensions;
using SozlukApi.Common.ViewModel.Page;
using SozlukApi.Common.ViewModel.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SozlukApi.Api.Application.Features.Queries.GetEntriesComments
{
    public class GetEntryCommentsQueryHandler : IRequestHandler<GetEntryCommentsQuery, PagedViewModel<GetEntryCommentViewModel>>
    {

        private readonly IEntryCommentRepository entryCommentRepository;


        public GetEntryCommentsQueryHandler(IEntryCommentRepository entryCommentRepository)
        {
            this.entryCommentRepository = entryCommentRepository;

        }

        public async Task<PagedViewModel<GetEntryCommentViewModel>> Handle(GetEntryCommentsQuery request, CancellationToken cancellationToken)
        {
            var query = entryCommentRepository.AsQuaryable();
            query = query.Include(i => i.EntryCommentFavorites)
                .Include(i => i.CreatedBy)
                .Include(i => i.EntryCommentVotes)
                .Include(i => i.EntryId == request.EntryId);
                

            var list = query.Select(i => new GetEntryCommentViewModel()
            {

                Id = i.Id,
                Content = i.Content,
                IsFavorited = request.UserId.HasValue && i.EntryCommentFavorites.Any(j => j.CreateById == request.UserId),
                FavoritedCount = i.EntryCommentFavorites.Count,
                CreatedDate = i.CreateDate,
                CreatedByUserName = i.CreatedBy.UserName,
                VoteType = request.UserId.HasValue && i.EntryCommentVotes.Any(j => j.CreateById == request.UserId) ? i.EntryCommentVotes.FirstOrDefault(j => j.CreateById == request.UserId).VoteType : Common.ViewModel.VoteType.None


            });
            var entries = await list.GetPaged(request.Page, request.PageSize);

            return entries;
        }
    }
}
