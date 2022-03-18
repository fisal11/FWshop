using FWshop.BL.Interface;
using FWshop.BL.Repository;
using FWshop.Data.Database;
using FWshop.Mapper;
using FWshop.Repository;
using FWshop.Repository.IRepository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;
using System.Globalization;

namespace FWshop
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

            services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                // Default Password settings.
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 3;
                options.Password.RequiredUniqueChars = 0;
            })
                .AddEntityFrameworkStores<DbContainer>()
                .AddTokenProvider<DataProtectorTokenProvider<IdentityUser>>(TokenOptions.DefaultProvider);


            services.AddControllersWithViews()
                .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                .AddDataAnnotationsLocalization()
                .AddNewtonsoftJson(opt => {
                opt.SerializerSettings.ContractResolver = new DefaultContractResolver();
            });

            services.AddAutoMapper(typeof(FWShopMapper));
            services.AddScoped<IDepartment, DepartmentRepo>();
            services.AddScoped<IEmploee, EmploeeRepo>();
            services.AddScoped<ICountry, CountryRepo>();
            services.AddScoped<ICity, CityRepo>();
            services.AddScoped<IDistrict, DistirctRepo>();

            services.AddDbContext<DbContainer>
             (options => options.UseSqlServer
             (Configuration.GetConnectionString("FWSHOPDB")));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            var supportedCultures = new[] {
              new CultureInfo("ar-EG"),
              new CultureInfo("en-US"),
            };

            app.UseRequestLocalization(new RequestLocalizationOptions
            {

                DefaultRequestCulture = new RequestCulture("en-US"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures,
                RequestCultureProviders = new List<IRequestCultureProvider>
                {
                  new QueryStringRequestCultureProvider(),
                  new CookieRequestCultureProvider()
                }

            });
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Account}/{action=SignIn}/{id?}");
            });
        }
    }
}
