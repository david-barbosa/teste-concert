﻿using Concert.Api.ConfigHub;
using Concert.Api.RabbitMQHelper;
using Concert.Domain.Commands.Handlers;
using Concert.Domain.Interfaces;
using Concert.Infra.Context;
using Concert.Infra.Repositories;
using Concert.Infra.Transactions;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;

namespace Concert.Api.Configurations
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<ConcertDataContext, ConcertDataContext>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            //Repository
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<ICardRepository, CardRepository>();
            services.AddTransient<IUserStoryRepository, UserStoryRepository>();
            services.AddTransient<IVotesRepository, VotesRepository>();

            //Commands Handlers
            services.AddTransient<UserCommandHandler, UserCommandHandler>();
            services.AddTransient<CardCommandHandler, CardCommandHandler>();
            services.AddTransient<UserStoryCommandHandler, UserStoryCommandHandler>();

            services.AddTransient<IRabbitMQHelper, RabbitMQHelpers>();
        }
    }
}
