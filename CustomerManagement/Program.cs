﻿using Microsoft.EntityFrameworkCore;
using CustomerManagement.Models;
using CustomerManagement;
using CustomerManagement.Repositories;
using CustomerManagement.Services;
using CustomerManagement.Validators;
using CustomerManagement.Mappers;
using System.Collections.Generic;
using System.Reflection.Metadata;
using CustomerManagement.Middleware;
using Serilog;
using Serilog.Formatting.Compact;
using Microsoft.Extensions.Configuration;

internal class Program
{
    private static void Main(string[] args)
    {
        // Get application base directory
        string baseDir = AppDomain.CurrentDomain.BaseDirectory;

        var builder = WebApplication.CreateBuilder(args);

        var logger = new LoggerConfiguration()
            .ReadFrom
            .Configuration(builder.Configuration)
            .Enrich
            .FromLogContext()
            .CreateLogger();
        builder.Services.AddLogging(logBuilder => logBuilder.AddSerilog(logger));

        // Add services to the container.
        builder.Services.AddControllers().AddNewtonsoftJson();
        builder.Services.AddScoped<ICustomerRepository, CustomerDbContextRepository>();
        builder.Services.AddScoped<IAddressRepository, AddressDbContextRepository>();
        builder.Services.AddScoped<ICustomerService, CustomerService>();
        builder.Services.AddScoped<IAddressService, AddressService>();
        builder.Services.AddScoped<IAddressRequestValidator, AddressRequestValidator>();
        builder.Services.AddScoped<IAddressValidator, AddressValidator>();
        builder.Services.AddScoped<ICustomerValidator, CustomerValidator>();
        builder.Services.AddDbContext<CustomerMngmContext>(opt => opt.UseInMemoryDatabase(Constants.DATABASE_NAME));
        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        builder.Services.AddResponseCaching();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        //app.UseHttpsRedirection();
        //useCors is before caching
        //app.useCors();
        //app.UseResponseCaching();

        app.UseMiddleware<UserExceptionHandlerMiddleware>();
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseAuthorization();
        app.MapControllers();

        app.Run();
    }
}