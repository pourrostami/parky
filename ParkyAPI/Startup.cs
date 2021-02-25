using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ParkyAPI.Data;
using ParkyAPI.Repository;
using ParkyAPI.Repository.IRepository;
using AutoMapper;
using ParkyAPI.MapperMapper.ParkyMapper;
using ParkyAPI.MapperMapper.BreadMapper;
using ParkyAPI.MapperMapper.TypeBreadMapper;
using System.Reflection;
using System.IO;

namespace ParkyAPI
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
            services.AddControllers();
            services.AddDbContext<ApplicationDbContext>
                (options => options.UseSqlServer(Configuration.GetConnectionString("NConnection")));

            services.AddAutoMapper(typeof(ParkyMappings));
            services.AddAutoMapper(typeof(BreadMappings));
            services.AddAutoMapper(typeof(TypeBreadMappings));

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("ParkyBread",
                    new Microsoft.OpenApi.Models.OpenApiInfo()
                    {
                        Title = "Parky Bread API",
                        Version = "1",
                        Description="الحمدلله",
                        //Contact=new Microsoft.OpenApi.Models.OpenApiContact
                        //{
                        //    Email="mohammad_pourrostami@yahoo.com",
                        //    Name="Mohammad",
                        //    Url=new Uri("A")
                        //}
                    });
                //var xmlCommentFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                //var cmlCommentsFullPath = Path.Combine(AppContext.BaseDirectory, xmlCommentFile);
                //options.IncludeXmlComments(cmlCommentsFullPath);
            });

            services.AddTransient<INtionalParkRepository, NtionalParkRepository>();
            services.AddTransient<ITypeBreadRepository, TypeBreadRepository>();
            services.AddScoped<IBreadRepository, BreadRepository>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/ParkyBread/swagger.json", "Parky Bread API");
                options.RoutePrefix = "";
            });
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
