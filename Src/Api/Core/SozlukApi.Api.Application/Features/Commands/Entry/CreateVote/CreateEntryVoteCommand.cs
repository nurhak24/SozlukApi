using MediatR;
using SozlukApi.Common.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SozlukApi.Api.Application.Features.Commands.Entry.CreateVote
{
    public class CreateEntryVoteCommand : IRequest<bool>
    {

        public Guid EntryId { get; set; }

        public CreateEntryVoteCommand(Guid entryId,VoteType voteType,Guid createdBy)
        {
            EntryId = entryId;
            VoteType = voteType;
            CreatedBy = createdBy;
        }

        public VoteType VoteType { get; set; }
        public Guid CreatedBy { get; set; }
    }
}
