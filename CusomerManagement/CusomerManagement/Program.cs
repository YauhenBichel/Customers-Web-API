using Microsoft.EntityFrameworkCore;
using CusomerManagement.Models;
using CusomerManagement;
using CusomerManagement.Repositories;
using CusomerManagement.Services;
using CusomerManagement.Validators;
using CusomerManagement.Mappers;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllers();
        builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
        builder.Services.AddScoped<ICustomerService, CustomerService>();
        builder.Services.AddScoped<ICustomerValidator, CustomerValidator>();
        builder.Services.AddDbContext<CustomerContext>(opt => opt.UseInMemoryDatabase("CustomerManagement"));
        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

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