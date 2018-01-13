﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Weapsy.Mediator.Domain;
using Weapsy.Mediator.EventStore.EF.Extensions;

namespace Weapsy.Mediator.EventStore.EF.Sqlite
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddWeapsyMediatorEventStore(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddWeapsyMediatorEF(configuration);

            var connectionString = configuration.GetConnectionString(Constants.EventStoreConnection);

            services.AddDbContext<EventStoreDbContext>(options =>
                options.UseSqlite(connectionString));

            services.AddTransient<IDataProvider, DataProvider>();

            return services;
        }
    }
}
