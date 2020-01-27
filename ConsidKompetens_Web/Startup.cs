using System.Text;
using ConsidKompetens_Core.Interfaces;
using ConsidKompetens_Data.Data;
using ConsidKompetens_Services.DataServices;
using ConsidKompetens_Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using ConsidKompetens_Web.Data;
using ConsidKompetens_Web.Helpers;
using ConsidKompetens_Web.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;

namespace ConsidKompetens_Web
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddDbContext<UserDataContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("UserDataConnection")));

            services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddIdentityServer()
                .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();

            services.AddScoped<IGetUserDataService, GetUserDataService>();

            //var appSettingsSection = Configuration.GetSection("AppSettings");
            //services.Configure<AppSettings>(appSettingsSection);
            //var appSettings = appSettingsSection.Get<AppSettings>();
            //var key = Encoding.ASCII.GetBytes(appSettings.Secret);

            services.AddAuthentication()
                .AddIdentityServerJwt();
            {

                //services.AddAuthentication(x =>
                //{
                //    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                //    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                //}).AddJwtBearer(x =>
                //{
                //    x.RequireHttpsMetadata = false;
                //    x.SaveToken = true;
                //    x.TokenValidationParameters = new TokenValidationParameters
                //    {
                //        ValidateIssuerSigningKey = true,
                //        IssuerSigningKey = new SymmetricSecurityKey(key),
                //        ValidateIssuer = false,
                //        ValidateAudience = false
                //    };
                //});
            }

            services.AddControllersWithViews();
            //services.AddRazorPages();

            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();
            app.UseRouting();

            //var cookiePolicyOptions = new CookiePolicyOptions();

            //app.UseCookiePolicy(cookiePolicyOptions);
            //app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseAuthentication();
            app.UseIdentityServer();
            app.UseAuthorization();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }
    }
}
