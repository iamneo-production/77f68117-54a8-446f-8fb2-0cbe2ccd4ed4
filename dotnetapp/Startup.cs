using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
<<<<<<< HEAD
=======
///
using dotnetapp.Context;
using dotnetapp.Core;
using dotnetapp.Core.Interfaces;
using NLog;

//using Microsoft.AspNetCore.Authentication.JwtBearer;
///
>>>>>>> ce8665c87d36bb2bf5997e3d7212fca6efe7b14a
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using dotnetapp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
<<<<<<< HEAD
using dotnetapp.Context;
using dotnetapp.Core.Interfaces;
using dotnetapp.Core;
=======
>>>>>>> ce8665c87d36bb2bf5997e3d7212fca6efe7b14a

namespace dotnetapp
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
            string connectionString = Configuration.GetConnectionString("myconnstring");
            services.AddDbContext<EducationLoanContext>(opt => opt.UseSqlServer(connectionString));
<<<<<<< HEAD
            //services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ILoan, LoanServices>();
            services.AddCors();

=======
           // services.AddScoped<IProductService, ProductService>();
            services.AddCors();
            services.AddScoped<IUser, UserServices>(); 
            services.AddScoped<IDocument, DocumentCore>();
            services.AddScoped<ILoan, LoanServices>();
>>>>>>> ce8665c87d36bb2bf5997e3d7212fca6efe7b14a
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "dotnetapp", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "dotnetapp v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

<<<<<<< HEAD
=======
            //app.Authentication();

>>>>>>> ce8665c87d36bb2bf5997e3d7212fca6efe7b14a
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
