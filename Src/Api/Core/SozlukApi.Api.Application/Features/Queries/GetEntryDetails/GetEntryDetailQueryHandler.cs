using MediatR;
using MediatR.Pipeline;
using Microsoft.EntityFrameworkCore;
using SozlukApi.Api.Application.Interfaces;
using SozlukApi.Common.Infrastructure.Extensions;
using SozlukApi.Common.ViewModel.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SozlukApi.Api.Application.Features.Queries.GetEntryDetails
{
    public class GetEntryDetailQueryHandler : IRequestHandler<GetEntryDetailQuery, GetEntryDetailViewModel>
    {

        private readonly IEntryRepository entryRepository;


        public GetEntryDetailQueryHandler(IEntryRepository entryRepository)
        {
            this.entryRepository = entryRepository;

        }
        public async Task<GetEntryDetailViewModel> Handle(GetEntryDetailQuery request, CancellationToken cancellationToken)
        {
            var query = entryRepository.AsQuaryable();
            query = query.Include(i => i.EntryFavorites)
                .Include(i => i.CreatedBy)
                .Include(i => i.EntryVotes)
                .Include(i => i.Id == request.EntryId);


            var list = query.Select(i => new GetEntryDetailViewModel()
            {

                Id = i.Id,
                Subject = i.Subject,
                Content = i.Content,
                IsFavorited = request.UserId.HasValue && i.EntryFavorites.Any(j => j.CreateById == request.UserId),
                FavoritedCount = i.EntryFavorites.Count,
                CreatedDate = i.CreateDate,
                CreatedByUserName = i.CreatedBy.UserName,
                VoteType = request.UserId.HasValue && i.EntryVotes.Any(j => j.CreateById == request.UserId) ? i.EntryVotes.FirstOrDefault(j => j.CreateById == request.UserId).VoteType : Common.ViewModel.VoteType.None


            });

            return await list.FirstOrDefaultAsync(cancellationToken: cancellationToken);
        }
    }
}
