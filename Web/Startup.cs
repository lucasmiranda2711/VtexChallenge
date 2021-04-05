using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Vtex.Challenge.Application.Services.Carts;
using Vtex.Challenge.Application.Services.Cupoms;
using Vtex.Challenge.Application.Services.Items;
using Vtex.Challenge.Application.Services.Users;
using Vtex.Challenge.Database.Repository.Auth;
using Vtex.Challenge.Database.Repository.Carts;
using Vtex.Challenge.Database.Repository.Carts.Interfaces;
using Vtex.Challenge.Database.Repository.Cupoms;
using Vtex.Challenge.Database.Repository.Cupoms.Interfaces;
using Vtex.Challenge.Database.Repository.Items;
using Vtex.Challenge.Database.Repository.Items.Interfaces;
using Vtex.Challenge.Domain.Service.Auth;
using Vtex.Challenge.Web.Authorization;
using Vtex.Challenge.Web.Mappings;
using Vtex.Challenge.Web.Swagger;

namespace Vtex.Challenge
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            SwaggerConfiguration.AddSwagger(services);
            AutomapperConfig.RegisterMapping(services);

            AuthorizationConfiguration.AddAuthorizationConfiguration(services, Configuration);

            services.AddControllers();
            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddSingleton<ITokenService, TokenService>();
            services.AddSingleton<IUserService, UserService>();
            services.AddSingleton<ICartService, CartService>();
            services.AddSingleton<ICartRepository, CartRepository>();
            services.AddSingleton<ICupomService, CupomService>();
            services.AddSingleton<ICupomRepository, CupomRepository>();
            services.AddSingleton<IItemService, ItemService>();
            services.AddSingleton<IItemRepository, ItemRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Vtex Shop Cart");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}