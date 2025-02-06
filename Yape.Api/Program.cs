
using Yape.Api.Core.Interfaces;
using Yape.Api.Infrastructure.Repositories;
using Yape.Api.Infrastructure.Services;

namespace Yape.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddScoped<IClientRepository>(sp => new ClientRepository(connectionString));

            string wcfEndpoint = builder.Configuration["WcfService"];
            builder.Services.AddScoped<IPersonService>(sp => new PersonService(wcfEndpoint));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
