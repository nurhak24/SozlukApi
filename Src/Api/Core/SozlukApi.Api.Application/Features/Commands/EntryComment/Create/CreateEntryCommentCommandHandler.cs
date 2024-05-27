using AutoMapper;
using MediatR;
using SozlukApi.Api.Application.Interfaces;
using SozlukApi.Common.ViewModel.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SozlukApi.Api.Application.Features.Commands.EntryComment.Create
{
    public class CreateEntryCommentCommandHandler : IRequestHandler<CreateEntryCommentCommand, Guid>
    {
        private readonly IEntryCommentRepository entryCommentRepository;
        private readonly IMapper mapper;

        public CreateEntryCommentCommandHandler(IEntryCommentRepository entryCommentRepository, IMapper mapper)
        {
            this.entryCommentRepository = entryCommentRepository;
            this.mapper = mapper;
        }

        public async Task<Guid> Handle(CreateEntryCommentCommand request, CancellationToken cancellationToken)
        {
            var dbEntryComment = mapper.Map<Domain.Models.EntryComment>(request);

            await entryCommentRepository.AddAsync(dbEntryComment);

            return dbEntryComment.Id;
        }
    }
}
