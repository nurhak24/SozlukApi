﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SozlukApi.Common.ViewModel.RequestModels
{
    public class CreateEntryCommentVoteCommand : IRequest<bool>
    {

        public Guid EntryCommentId { get; set; }
        public VoteType VoteType { get; set; }
        public Guid CreatedBy { get; set; }
        public CreateEntryCommentVoteCommand(Guid entryCommentId, VoteType voteType, Guid createdBy)
        {
            EntryCommentId = entryCommentId;
            VoteType = voteType;
            CreatedBy = createdBy;
        }

        public CreateEntryCommentVoteCommand() { }



    }
}
