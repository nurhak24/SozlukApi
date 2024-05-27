using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SozlukApi.Api.Application.Features.Queries.GetEntries;
using SozlukApi.Api.Application.Features.Queries.GetEntriesComments;
using SozlukApi.Api.Application.Features.Queries.GetEntryDetails;
using SozlukApi.Api.Application.Features.Queries.GetMainPageEntries;
using SozlukApi.Api.Application.Features.Queries.GetUserEntries;
using SozlukApi.Common.ViewModel.Queries;
using SozlukApi.Common.ViewModel.RequestModels;

namespace SozlukApi.Api.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntryController : BaseController
    {

        private readonly IMediator mediator;

        public EntryController(IMediator mediator)
        {
            this.mediator = mediator;

        }

        [HttpPost]
        [Route("CreateEntry")]
        public async Task<IActionResult> CreateEntry([FromBody] CreateEntryCommand command)
        {
            if (!command.CreatedById.HasValue)
                command.CreatedById = UserId;

            var result = await mediator.Send(command);
            return Ok(result);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await mediator.Send(new GetEntryDetailQuery(id,UserId));
            return Ok(result);

        }

        [HttpGet]
        [Route("Comments/{id}")]
        public async Task<IActionResult> GetEntryComments(Guid id,int page,int pageSize)
        {
            var result = await mediator.Send(new GetEntryCommentsQuery(id, UserId,page,pageSize));
            return Ok(result);

        }

        [HttpGet]
        [Route("UserEntries")]
        public async Task<IActionResult> GetUserEntries(string userName,Guid userId , int page, int pageSize)
        {
            if (userId == Guid.Empty && string.IsNullOrEmpty(userName))
                userId = UserId.Value;

            var result = await mediator.Send(new GetUserEntriesQuery(userId, userName, page, pageSize));
            return Ok(result);

        }

        [HttpGet]
        public async Task<IActionResult> GetEntries([FromQuery] GetEntriesQuery query)
        {
            var entries =  await mediator.Send(query);
            return Ok(entries);

        }
        [HttpGet]
        [Route("MainPageEntries")]
        public async Task<IActionResult> GetMainPageEntries(int page, int pageSize)
        {
            var entries = await mediator.Send(new GetMainPageEntriesQuery(UserId,page,pageSize));
            return Ok(entries);

        }

        [HttpPost]
        [Route("CreateEntryComment")]
        public async Task<IActionResult> CreateCommentEntry([FromBody] CreateEntryCommentCommand command)
        {
            if (!command.CreatedById.HasValue)
                command.CreatedById = UserId;


            var result = await mediator.Send(command);
            return Ok(result);

        }

        [HttpGet]
        [Route("Search")]
        public async Task<IActionResult> Search([FromBody] SearchEntryQuery query)
        {
            
            var result = await mediator.Send(query);
            return Ok(result);

        }


    }
}
