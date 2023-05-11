using Autofac.Extensions.DependencyInjection;
using Autofac;
using FilmLibrary.API.Modules;
using FilmLibrary.Repository;
using Microsoft.EntityFrameworkCore;
using FilmLibrary.Configuration;
using System.Reflection;
using FilmLibrary.Service.Mapping;
using FilmLibrary.API.Middlewares;
using Autofac.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FluentValidation.AspNetCore;
using Swashbuckle.AspNetCore.Filters;
using FilmLibrary.Service.Validations;
using Microsoft.OpenApi.Models;
using FilmLibrary.API.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options => options.Filters.Add(new ValidateFilterAttribute())).AddFluentValidation(x =>
{
    x.RegisterValidatorsFromAssemblyContaining<FilmDtoValidator>();
});
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(MapProfile));


builder.Services.AddDbContext<AppDbContext>(x =>
{
    x.UseSqlServer(Constants.dbConn, option =>
    {
        option.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name);
    });

});

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    containerBuilder.RegisterModule(new RepoServiceModule());

    var tracer = new DefaultDiagnosticTracer();
    tracer.OperationCompleted += (sender, args) => Console.WriteLine(args.TraceContent);
    containerBuilder.RegisterBuildCallback(c =>
    {
        var container = c as IContainer;
        container.SubscribeToDiagnostics(tracer);
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCustomException();

app.UseAuthorization();

app.MapControllers();

app.Run();
