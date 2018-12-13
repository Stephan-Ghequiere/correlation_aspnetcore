﻿using Microsoft.Extensions.DependencyInjection;
using System;

namespace Digipolis.Correlation
{
    public static class CorrelationServiceCollectionExtensions
    {
        public static IServiceCollection AddCorrelation(this IServiceCollection services, Action<CorrelationOptions> setupAction = null)
        {
            if (setupAction == null)
                setupAction = options => { };

            services.Configure<CorrelationOptions>(setupAction);
            services.AddScoped<ICorrelationContext, CorrelationContext>();
            services.AddTransient<AddCorrelationHeaderHandler>();
            
            return services;
        }
    }
}
