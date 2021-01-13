using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using lojaCet500.Data;
using lojaCet500.Dados;
using FluentAssertions.Common;

namespace lojaCet500
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
            services.AddDbContext<DataContext>(cfg =>
            {
                cfg.UseSqlServer(this.Configuration.GetConnectionString("DefaultConnection"));
            });


            services.AddTransient<SeedDb>();
            services.AddScoped<IRepository, Repository>();


            {
                services.Configure<CookiePolicyOptions>(options =>
                {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                    options.MinimumSameSitePolicy = SameSiteMode.None;
                });


                services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

                services.AddDbContext<lojaCet500Context>(options =>
                        options.UseSqlServer(Configuration.GetConnectionString("lojaCet500Context")));
            }

            // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
            public void Configure(IApplicationBuilder app, IHostingEnvironment env)
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

                app.UseHttpsRedirection();
                app.UseStaticFiles();
                app.UseCookiePolicy();

                app.UseMvc(routes =>
                {
                    routes.MapRoute(
                        name: "default",
                        template: "{controller=Home}/{action=Index}/{id?}");
                });
            }

    internal struct NewStruct
        {
            public object Item1;
            public object Item2;

            public NewStruct(object item1, object item2)
            {
                Item1 = item1;
                Item2 = item2;
            }

            public override bool Equals(object obj)
            {
                return obj is NewStruct other &&
                       EqualityComparer<object>.Default.Equals(Item1, other.Item1) &&
                       EqualityComparer<object>.Default.Equals(Item2, other.Item2);
            }

            public override int GetHashCode()
            {
                return HashCode.Combine(Item1, Item2);
            }

            public void Deconstruct(out object item1, out object item2)
            {
                item1 = Item1;
                item2 = Item2;
            }

            public static implicit operator (object, object)(NewStruct value)
            {
                return (value.Item1, value.Item2);
            }

            public static implicit operator NewStruct((object, object) value)
            {
                return new NewStruct(value.Item1, value.Item2);
            }
        }
    }

