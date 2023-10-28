using Microsoft.EntityFrameworkCore;
using CustomerManagement.Models;
using CustomerManagement;
using CustomerManagement.Repositories;
using CustomerManagement.Services;
using CustomerManagement.Validators;
using CustomerManagement.Mappers;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllers().AddNewtonsoftJson();
        builder.Services.AddScoped<ICustomerRepository, CustomerDbContextRepository>();
        builder.Services.AddScoped<IAddressRepository, AddressDbContextRepository>();
        builder.Services.AddScoped<ICustomerService, CustomerService>();
        builder.Services.AddScoped<IAddressService, AddressService>();
        builder.Services.AddScoped<IAddressRequestValidator, AddressRequestValidator>();
        builder.Services.AddDbContext<CustomerMngmContext>(opt => opt.UseInMemoryDatabase("CustomerManagement"));
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