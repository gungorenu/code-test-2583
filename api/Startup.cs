namespace api
{
    using api.Services;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            // dependency injection stuff, straighforward, no magic needed
            services.AddScoped<IWebClient, api.Services.Implementations.WebClient>();
            services.AddScoped<IConversionService, api.Services.Implementations.ConversionService>();
            services.AddScoped<IExchangeRateService, api.Services.Implementations.ExchangeRateService>();
            services.AddScoped<IAccountService, api.Services.Implementations.AccountService>();
            services.AddScoped<ITransactionService, api.Services.Implementations.TransactionService>();
        }
    }
}