using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using MediatR;
using System.Reflection;
using System.Net.Http;
using Poc.SDD.Api;

namespace Poc.SDD.Api.Tests;

public class CustomWebApplicationFactory : WebApplicationFactory<Program>
{
    protected override IHostBuilder CreateHostBuilder()
    {
        var builder = Host.CreateDefaultBuilder()
            .UseContentRoot("D:\\dev\\PoC\\SDD\\poc-sdd-api")
            .UseServiceProviderFactory(new AutofacServiceProviderFactory())
            .ConfigureContainer<ContainerBuilder>(containerBuilder =>
            {
                // Register MediatR handlers from Application assembly
                var applicationAssembly = Assembly.Load("Poc.SDD.Application");
                containerBuilder.RegisterAssemblyTypes(applicationAssembly)
                    .AsClosedTypesOf(typeof(IRequestHandler<,>))
                    .AsImplementedInterfaces();
                
                containerBuilder.RegisterAssemblyTypes(applicationAssembly)
                    .AsClosedTypesOf(typeof(IRequestHandler<>))
                    .AsImplementedInterfaces();
                
                // Register MediatR mediator
                containerBuilder.RegisterType<Mediator>()
                    .As<IMediator>()
                    .InstancePerLifetimeScope();
                
                containerBuilder.Register<Func<Type, object>>(ctx =>
                {
                    var c = ctx.Resolve<IComponentContext>();
                    return t => c.Resolve(t);
                });
                
                // Register AutoMapper
                var mappingAssembly = Assembly.Load("Poc.SDD.Application");
                containerBuilder.RegisterAssemblyTypes(Assembly.Load("Poc.SDD.Application"))
                    .Where(t => typeof(Profile).IsAssignableFrom(t))
                    .As<Profile>();
                
                containerBuilder.Register(context =>
                {
                    var profiles = context.Resolve<IEnumerable<Profile>>();
                    var config = new MapperConfiguration(cfg =>
                    {
                        foreach (var profile in profiles)
                        {
                            cfg.AddProfile(profile);
                        }
                    });
                    return config.CreateMapper();
                }).As<IMapper>().SingleInstance();
            })
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseContentRoot("D:\\dev\\PoC\\SDD\\poc-sdd-api");
                webBuilder.UseEnvironment("Testing");
                webBuilder.ConfigureServices(services =>
                {
                    services.AddEndpointsApiExplorer();
                    services.AddApiVersioning(options =>
                    {
                        options.ApiVersionReader = new HeaderApiVersionReader("api-version");
                        options.AssumeDefaultVersionWhenUnspecified = true;
                        options.DefaultApiVersion = new ApiVersion(1, 0);
                    });
                    services.AddControllers()
                        .AddApplicationPart(typeof(Poc.SDD.Api.Controllers.V1.ClientsController).Assembly);
                });
                webBuilder.Configure(app =>
                {
                    app.UseHttpsRedirection();
                    app.UseRouting();
                    app.UseEndpoints(endpoints =>
                    {
                        endpoints.MapControllers();
                    });
                });
            });
        
        return builder;
    }

    protected override void ConfigureClient(HttpClient client)
    {
        base.ConfigureClient(client);
        client.DefaultRequestHeaders.Add("api-version", "1.0");
    }
}