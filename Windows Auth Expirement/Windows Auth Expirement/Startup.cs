using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.IISIntegration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WindowsAuthExpirement.Options;
using WindowsAuthExpirement.Security;

namespace Windows_Auth_Expirement
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
            var securityOptions = Configuration.GetSection("Security").Get<SecurityOptions>();

            services.AddAuthentication(IISDefaults.AuthenticationScheme);
            services.AddAuthorization(options =>
            {
                //doesn't work (as expected)
                //options.AddPolicy("OMS API Orig", policy =>
                //{
                //    policy.AddAuthenticationSchemes("Windows");
                //    policy.RequireAuthenticatedUser();
                //    policy.RequireRole("OMS API");
                //});

                options.AddPolicy("OMS API", policy =>
                {
                    policy.Requirements.Add(new OmsApiRequirement(securityOptions.OmsApiAllowedGroups));
                    policy.AddAuthenticationSchemes("Windows");
                });
            });
            services.AddSingleton<IAuthorizationHandler, OmsApiHandler>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
