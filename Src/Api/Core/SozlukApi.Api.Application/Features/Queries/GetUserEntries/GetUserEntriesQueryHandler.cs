using AutoMapper;
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

namespace SozlukApi.Api.Application.Features.Queries.GetUserEntries
{
    public class GetUserEntriesQueryHandler : IRequestHandler<GetUserEntriesQuery, PagedViewModel<GetUserEntriesDetailViewModel>>
    {
        private readonly IEntryRepository entryRepository;
        

        public GetUserEntriesQueryHandler(IEntryRepository entryRepository)
        {
            this.entryRepository = entryRepository;
        }

        public async Task<PagedViewModel<GetUserEntriesDetailViewModel>> Handle(GetUserEntriesQuery request, CancellationToken cancellationToken)
        {
            var query = entryRepository.AsQuaryable();

            if (request.UserId != null && request.UserId.HasValue && request.UserId != Guid.Empty)
                query = query.Where(i => i.CreatedById == request.UserId);
            else if (!string.IsNullOrEmpty(request.UserName))
                query = query.Where(i => i.CreatedBy.UserName == request.UserName);
            else return null;

            query = query.Include(i => i.EntryFavorites)
                    .Include(i => i.CreatedBy);

            var list = query.Select(i => new GetUserEntriesDetailViewModel()
            {

                Id = i.Id,
                Subject = i.Subject,
                Content = i.Content,
                IsFavorited = true,
                FavoritedCount = i.EntryFavorites.Count,
                CreatedDate = i.CreateDate,
                CreatedByUserName = i.CreatedBy.UserName,

            });

            var entries = await list.GetPaged(request.Page, request.PageSize);

            return entries;
        }
    }
}
