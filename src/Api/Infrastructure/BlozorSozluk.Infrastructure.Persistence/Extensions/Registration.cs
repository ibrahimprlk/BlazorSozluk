using BlozorSozluk.Api.Application.Interfaces.Repositories;
using BlozorSozluk.Infrastructure.Persistence.Context;
using BlozorSozluk.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BlozorSozluk.Infrastructure.Persistence.Extensions
{
    public static class Registration
    {
        public static IServiceCollection AddInfrastructureRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            var connStr = configuration["BlazorEksiSozlukDbConnectionString"].ToString();
            services.AddDbContext<BlazorSozlukContext>(conf =>
            {
                conf.UseSqlServer(connStr, opt =>
                {
                    opt.EnableRetryOnFailure();
                });
            });

            // Bogus kutuphanesi yardimiyla seed datalarin olusturulmasi icin
            //* Bir kere calistirdigimiz icin bir daha calistirmaya gerek yok
            // var seedData = new SeedData();
            // seedData.SeedAsync(configuration).GetAwaiter().GetResult();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IEntryRepository, EntryRepository>();
            services.AddScoped<IEmailConfirmationRepository, EmailConfirmationRepository>();
            services.AddScoped<IEntryCommentRepository, EntryCommentRepository>();

            return services;


        }

    }
}
