using MediatR;
using SozlukApi.Common.ViewModel.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SozlukApi.Api.Application.Features.Queries.GetEntryDetails
{
    public class GetEntryDetailQuery : IRequest<GetEntryDetailViewModel>
    {
        public Guid EntryId { get; set; }
        public Guid? UserId { get; set; }

        public GetEntryDetailQuery(Guid entryId, Guid? userId)
        {
            EntryId = entryId;
            UserId = userId;
        }
    }
}
