using System.Reflection;
using Application.Features.ProgrammingLanguage.Rules;
using Application.Features.ProgrammingLanguageTechnology.Rules;
using Application.Features.User.Rules;
using Application.Features.UserInfo.Rules;
using Core.Application.Pipelines.Validation;
using Core.Security.JWT;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationService(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(Assembly.GetExecutingAssembly());

        services.AddScoped<ProgrammingLanguageBusinessRules>();
        services.AddScoped<ProgrammingLanguageTechnologyBusinessRules>();
        services.AddScoped<UserBusinessRules>();
        services.AddScoped<UserInfoBusinessRules>();
        
        services.AddScoped<ITokenHelper, JwtHelper>();

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
        
        return services;
    }
} 