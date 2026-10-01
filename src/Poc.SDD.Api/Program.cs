using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Use Autofac as DI container
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
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
});

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddApiVersioning(options =>
{
    options.ApiVersionReader = new HeaderApiVersionReader("api-version");
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.DefaultApiVersion = new ApiVersion(1, 0);
});
builder.Services.AddControllers();

// Only add Swagger in non-test environments
if (!builder.Environment.IsEnvironment("Testing"))
{
    builder.Services.AddSwaggerGen();
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsEnvironment("Testing"))
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();

public partial class Program { }