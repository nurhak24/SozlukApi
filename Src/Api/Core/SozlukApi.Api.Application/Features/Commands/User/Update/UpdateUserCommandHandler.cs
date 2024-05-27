using AutoMapper;
using MediatR;
using SozlukApi.Api.Application.Interfaces;
using SozlukApi.Common.Events.User;
using SozlukApi.Common;
using SozlukApi.Common.Infrastructure.Exceptions;
using SozlukApi.Common.ViewModel.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SozlukApi.Api.Application.Features.Commands.User.Update
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Guid>
    {

        private readonly IMapper mapper;
        private readonly IUserRepository userRepository;

        public UpdateUserCommandHandler(IMapper mapper, IUserRepository userRepository)
        {
            this.mapper = mapper;
            this.userRepository = userRepository;
        }


        public async Task<Guid> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var dbUser = await userRepository.GetByIdAsync(request.Id);
            if (dbUser is null)
                throw new DatabaseValidationException("User not Found!");

            var dbEmailAddress = dbUser.EmailAdress;
            var emailChanged = string.CompareOrdinal(dbEmailAddress,request.EmailAddress) != 0;

            mapper.Map(request, dbUser);

            var rows = await userRepository.UpdateAsync(dbUser);

            if (emailChanged && rows>0)
            {

                var @event = new UserEmailChangedEvent()
                {
                    OldEmailAddress = null,
                    NewEmailAddress = dbUser.EmailAdress

                };

   
                QueueFactory.SendMessageToExchange(exchangeName: SozlukConstants.UserExchangeName, exchangeType: SozlukConstants.DefaultExchangeType, queueName: SozlukConstants.UserEmailChangedQueueName, obj: @event);

                dbUser.EmailConfirmed = false;
                await userRepository.UpdateAsync(dbUser);
            }



            return dbUser.Id;
        }
    }
}
