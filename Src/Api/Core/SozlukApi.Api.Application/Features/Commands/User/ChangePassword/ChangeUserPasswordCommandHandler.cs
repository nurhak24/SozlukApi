﻿using MediatR;
using SozlukApi.Api.Application.Interfaces;
using SozlukApi.Common.Events.User;
using SozlukApi.Common.Infrastructure;
using SozlukApi.Common.Infrastructure.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SozlukApi.Api.Application.Features.Commands.User.ChangePassword
{
    public class ChangeUserPasswordCommandHandler : IRequestHandler<ChangeUserPasswordCommand, bool>
    {
        private readonly IUserRepository userRepository;

        public ChangeUserPasswordCommandHandler(IUserRepository userRepository)
        {
            this.userRepository = userRepository;

        }


        public async Task<bool> Handle(ChangeUserPasswordCommand request, CancellationToken cancellationToken)
        {
            if(!request.UserId.HasValue)
                throw new ArgumentNullException(nameof(request.UserId));

            var dbUser = await userRepository.GetByIdAsync(request.UserId.Value);

            if (dbUser is null)
                throw new DatabaseValidationException("User not found!");

            var encPass = PasswordEncryptor.Encrpt(request.OldPassword);
            if (dbUser.Password != encPass)
                throw new DatabaseValidationException("Old Password wrong!");

            dbUser.Password = PasswordEncryptor.Encrpt(request.NewPassword);
            await userRepository.UpdateAsync(dbUser);

            return true;
        }
    }
}
