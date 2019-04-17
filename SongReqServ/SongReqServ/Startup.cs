using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SongReqServ.Services.SongReq;
using SongReqServ.Hubs;
using SongReqServ.Logger;
using Microsoft.AspNetCore.SignalR;
namespace SongReqServ
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddCors(opts =>
            {
                opts.AddPolicy("AllowAll", builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader()
                           .AllowCredentials();
                });
            });
            services.AddSignalR();
            services.AddSingleton<SongReqManager>();
        }      
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }           
            app.UseCors("AllowAll");
            app.UseHttpsRedirection();
            app.UseSignalR(options =>
            {
                options.MapHub<MainHub>("/hub");                
            });
            app.UseMvc();
            app.UseStaticFiles();
            loggerFactory.WSLogger(serviceProvider.GetService<IHubContext<MainHub>>());
        }
    }
}
