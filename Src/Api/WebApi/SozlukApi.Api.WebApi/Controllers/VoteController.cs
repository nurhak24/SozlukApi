﻿using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SozlukApi.Api.Application.Features.Commands.Entry.CreateVote;
using SozlukApi.Api.Application.Features.Commands.Entry.DeleteVote;
using SozlukApi.Common.ViewModel;
using SozlukApi.Common.ViewModel.RequestModels;

namespace SozlukApi.Api.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoteController : BaseController
    {
        private readonly IMediator mediator;

        public VoteController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        [Route("Entry/{entryId}")]
        public async Task<IActionResult> CreateEntryVote(Guid entryId,VoteType voteType= VoteType.UpVote)
        {
            var result = await mediator.Send(new CreateEntryVoteCommand(entryId,voteType,UserId.Value));
            return Ok(result);
        }

        [HttpPost]
        [Route("EntryComment/{entryCommentId}")]
        public async Task<IActionResult> CreateCommentEntryVote(Guid entryCommentId, VoteType voteType = VoteType.UpVote)
        {
            var result = await mediator.Send(new CreateEntryCommentVoteCommand(entryCommentId, voteType, UserId.Value));
            return Ok(result);
        }

        [HttpPost]
        [Route("DeleteEntryVote/{entryId}")]
        public async Task<IActionResult> DeleteEntryVote(Guid entryId)
        {
            var result = await mediator.Send(new DeleteEntryVoteCommand(entryId, UserId.Value));
            return Ok();
        }

        [HttpPost]
        [Route("DeleteEntryCommentVote/{entryCommentId}")]
        public async Task<IActionResult> DeleteEntryCommentVote(Guid entryCommentId)
        {
            var result = await mediator.Send(new DeleteEntryVoteCommand(entryCommentId, UserId.Value));
            return Ok();
        }

    }
}
