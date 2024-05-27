using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SozlukApi.Api.Application.Interfaces;
using SozlukApi.Common.ViewModel;
using SozlukApi.Common.ViewModel.Page;
using SozlukApi.Common.ViewModel.Queries;
using SozlukApi.Common.Infrastructure.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SozlukApi.Api.Application.Features.Queries.GetMainPageEntries
{
    public class GetMainPageEntriesQueryHandler : IRequestHandler<GetMainPageEntriesQuery, PagedViewModel<GetEntryDetailViewModel>>
    {
        private readonly IEntryRepository entryRepository;
       

        public GetMainPageEntriesQueryHandler(IEntryRepository entryRepository)
        {
            this.entryRepository = entryRepository;
           
        }
        public async Task<PagedViewModel<GetEntryDetailViewModel>> Handle(GetMainPageEntriesQuery request, CancellationToken cancellationToken)
        {
            var query = entryRepository.AsQuaryable();
            query = query.Include(i => i.EntryFavorites)
                .Include(i => i.CreatedBy)
                .Include(i => i.EntryVotes);

            var list = query.Select(i => new GetEntryDetailViewModel()
            {

                Id = i.Id,
                Subject = i.Subject,
                Content = i.Content,
                IsFavorited = request.UserId.HasValue && i.EntryFavorites.Any(j => j.CreateById == request.UserId),
                FavoritedCount = i.EntryFavorites.Count,
                CreatedDate = i.CreateDate,
                CreatedByUserName = i.CreatedBy.UserName,
                VoteType = request.UserId.HasValue && i.EntryVotes.Any(j => j.CreateById == request.UserId) ? i.EntryVotes.FirstOrDefault(j=>j.CreateById == request.UserId).VoteType : Common.ViewModel.VoteType.None


            });
            var entries = await list.GetPaged(request.Page, request.PageSize);

            return entries;
        }
    }
}
