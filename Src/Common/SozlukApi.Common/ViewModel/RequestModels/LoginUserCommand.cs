﻿using MediatR;
using SozlukApi.Common.ViewModel.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SozlukApi.Common.ViewModel.RequestModels
{
    public class LoginUserCommand : IRequest<LoginUserViewModel>
    {

        public string EmailAddress { get; set; }

        public string Password { get; set; }

        public LoginUserCommand(string emailAddress, string password)
        {
            
            EmailAddress = emailAddress;
            Password = password;

        }


    }
}
