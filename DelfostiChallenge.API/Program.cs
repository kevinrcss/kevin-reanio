using DelfostiChallenge.API.Extensions.Authentication;
using DelfostiChallenge.API.Extensions.Swagger;
using DelfostiChallenge.API.Extensions.Versioning;
using DelfostiChallenge.Application.Implementations;
using DelfostiChallenge.Application.Interfaces;
using DelfostiChallenge.Application.Mapper;
using DelfostiChallenge.Core.Interfaces;
using DelfostiChallenge.Repository.Context;
using DelfostiChallenge.Repository.Repositories;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;

namespace DelfostiChallenge.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

            builder.Services.AddAutoMapper(opts =>
            {
                opts.AddProfile(new MapperProfile());
            });

            builder.Services.AddEndpointsApiExplorer();
            //builder.Services.AddSwaggerGen();
            builder.Services.AddSwagger();
            builder.Services.AddVersioning();
            builder.Services.AddAuthenticationJwt(builder.Configuration);

            builder.Services.AddScoped<IAuthApplication, AuthApplication>();
            builder.Services.AddScoped<IPedidoApplication, PedidoApplication>();

            builder.Services.AddScoped<IAuthRepository, AuthRepository>();
            builder.Services.AddScoped<IPedidoRepository, PedidoRepository>();
            builder.Services.AddScoped<ISecuenciaRepository, SecuenciaRepository>();

            var connectionString = builder.Configuration.GetConnectionString("DBMYSQL");
            builder.Services.AddDbContext<AppDbContext>(options => {
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    // Build a swagger endpoint for each discovered API version
                    var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
                    foreach (var description in provider.ApiVersionDescriptions)
                    {
                        c.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
                    }
                });
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
