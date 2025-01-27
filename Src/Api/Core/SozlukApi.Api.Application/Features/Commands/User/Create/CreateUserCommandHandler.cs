﻿using AutoMapper;
using MediatR;
using SozlukApi.Api.Application.Interfaces;
using SozlukApi.Common;
using SozlukApi.Common.Events.User;
using SozlukApi.Common.Infrastructure.Exceptions;
using SozlukApi.Common.ViewModel.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SozlukApi.Api.Application.Features.Commands.User.Create
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand,Guid >
    {
        private readonly IMapper mapper;
        private readonly IUserRepository userRepository;

        public CreateUserCommandHandler(IMapper mapper , IUserRepository userRepository)
        {
            this.mapper = mapper;
            this.userRepository = userRepository;
        }

        public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var existsUser = await userRepository.GetSingleAsync(i => i.EmailAdress == request.EmailAddress);

            if (existsUser is not null)
                throw new Common.Infrastructure.Exceptions.DatabaseValidationException("user alread exist!");


            var dbUser = mapper.Map<Domain.Models.User>(request);

            var rows = await userRepository.AddAsync(dbUser);


            if (rows > 0)
            {

                var @event = new UserEmailChangedEvent()
                {
                    OldEmailAddress = null,
                    NewEmailAddress = dbUser.EmailAdress

                };

                QueueFactory.SendMessageToExchange(exchangeName: SozlukConstants.UserExchangeName, exchangeType: SozlukConstants.DefaultExchangeType, queueName:SozlukConstants.UserEmailChangedQueueName, obj: @event);
            }

            return dbUser.Id;
        }
    }
}
