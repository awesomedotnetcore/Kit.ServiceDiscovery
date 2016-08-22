﻿using System.Linq;
using Chatham.ServiceDiscovery.Abstractions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Chatham.ServiceDiscovery.Consul;
using Consul;

namespace ServiceDiscoverySample
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddConsulServiceDiscovery();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IServiceSubscriberFactory serviceSubscriberFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async context =>
            {
                var factory = serviceSubscriberFactory.CreateSubscriber("consul");
                await context.Response.WriteAsync(string.Join(",", factory.EndPoints()));
            });
        }
    }
}
