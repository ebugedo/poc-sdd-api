using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using MediatR;
using System.Reflection;

namespace Poc.SDD.Api.Tests;

public class TestProgram
{
    public static IHostBuilder CreateHostBuilder(string[] args)
    {
        return Host.CreateDefaultBuilder(args)
            .UseServiceProviderFactory(new AutofacServiceProviderFactory())
            .ConfigureContainer<ContainerBuilder>(containerBuilder =>
            {
                var applicationAssembly = Assembly.Load("Poc.SDD.Application");
                containerBuilder.RegisterAssemblyTypes(applicationAssembly)
                    .AsClosedTypesOf(typeof(IRequestHandler<,>))
                    .AsImplementedInterfaces();
                
                containerBuilder.RegisterAssemblyTypes(applicationAssembly)
                    .AsClosedTypesOf(typeof(IRequestHandler<>))
                    .AsImplementedInterfaces();
                
                containerBuilder.RegisterType<Mediator>()
                    .As<IMediator>()
                    .InstancePerLifetimeScope();
                
                containerBuilder.Register<Func<Type, object>>(ctx =>
                {
                    var c = ctx.Resolve<IComponentContext>();
                    return t => c.Resolve(t);
                });
                
                var mappingAssembly = Assembly.Load("Poc.SDD.Application");
                containerBuilder.RegisterAssemblyTypes(mappingAssembly)
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
                webBuilder.ConfigureServices(services =>
                {
                    services.AddEndpointsApiExplorer();
                    services.AddApiVersioning();
                });
                webBuilder.Configure(app =>
                {
                    app.UseHttpsRedirection();
                });
            });
    }
}