using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Tomskeda.Date;
using Tomskeda.Services.Interfaces;
using Tomskeda.Services.Services;

namespace Tomskeda
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddControllers();
            services.AddControllersWithViews();
            services.AddDbContext<ProductContext>(options =>
                 options.UseMySql("server=localhost;UserId=root;Password=;database=u0687251_tomskeda;"));
            services.AddDbContext<UserContext>(options =>
                 options.UseMySql("server=localhost;UserId=root;Password=;database=u0687251_tomskeda;"));
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IDateService, DateService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICookieService, CookieService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            var options = new RewriteOptions().AddRedirect("Order/OrderSend", "Order")
                .AddRedirect("order/OrderSend", "Order");


            app.UseRewriter(options);
            app.UseStaticFiles();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Index}/{action=Index}");

                endpoints.MapControllerRoute(
                name: "OrderSend",
                pattern: "{controller=Order}/{action=OrderSend}");
            });
        }
    }
}
