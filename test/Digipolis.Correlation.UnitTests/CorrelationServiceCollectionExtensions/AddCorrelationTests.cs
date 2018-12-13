﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Digipolis.Correlation;
using Xunit;

namespace Digipolis.Correlation.UnitTests.CorrelationIdServiceCollectionExtensions
{
    public class AddCorrelationIdTests
    {
        [Fact]
        private void CorrelationContextIsRegistratedAsScoped()
        {
            var services = new ServiceCollection();
            services.AddCorrelation();

            var registrations = services.Where(sd => sd.ServiceType == typeof(ICorrelationContext) && 
                                                     sd.ImplementationType == typeof(CorrelationContext))
                                        .ToArray();

            Assert.Single(registrations);
            Assert.Equal(ServiceLifetime.Scoped, registrations[0].Lifetime);
        }

        [Fact]
        private void CorrelationOptionsIsRegistratedAsSingleton()
        {
            var services = new ServiceCollection();
            services.AddCorrelation();

            var registrations = services.Where(sd => sd.ServiceType == typeof(IConfigureOptions<CorrelationOptions>))
                                        .ToArray();

            Assert.Single(registrations);
            Assert.Equal(ServiceLifetime.Singleton, registrations[0].Lifetime);
        }
    }
}
