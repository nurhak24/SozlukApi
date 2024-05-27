using MediatR;
using SozlukApi.Api.Application.Interfaces;
using SozlukApi.Common.Infrastructure.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SozlukApi.Api.Application.Features.Commands.User.ConfirmEmail
{
    public class ConfirmEmailCommandHandler : IRequestHandler<ConfirmEmailCommand, bool>
    {
        private readonly IUserRepository userRepository;
        private readonly IEmailConfirmationRepository emailConfirmationRepository;

        public ConfirmEmailCommandHandler(IEmailConfirmationRepository emailConfirmationRepository,IUserRepository userRepository)
        {
            this.emailConfirmationRepository = emailConfirmationRepository;
            this.userRepository = userRepository;
        }

        public async Task<bool> Handle(ConfirmEmailCommand request, CancellationToken cancellationToken)
        {
            var confirmation = await emailConfirmationRepository.GetByIdAsync(request.ConfirmationId);
            if (confirmation is null)
                throw new DatabaseValidationException("Confirmation not found!");

            var dbUser = await userRepository.GetSingleAsync(i => i.EmailAdress == confirmation.NewEmailAddress);

            if (dbUser is null)
                throw new DatabaseValidationException("User not found with this email");

            if (dbUser.EmailConfirmed)
                throw new DatabaseValidationException("Email address is alread confirmed");

            dbUser.EmailConfirmed = true;
            await userRepository.UpdateAsync(dbUser);

            return true;
        }
    }
}
