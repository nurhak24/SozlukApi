using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SozlukApi.Api.Application.Extensions
{
    public static class Registration 
    {

        public static IServiceCollection AddAplicationRegistration(this IServiceCollection service) 
        { 
            var assm = Assembly.GetExecutingAssembly();

            service.AddMediatR(assm);
            service.AddAutoMapper(assm);
            service.AddValidatorsFromAssembly(assm);
            return service;

        
        
        }

    }
}
