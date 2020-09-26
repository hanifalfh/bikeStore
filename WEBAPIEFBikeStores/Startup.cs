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
using NJsonSchema.Generation;
using NSwag;
using NSwag.Generation.Processors.Security;

namespace WEBAPIEFBikeStores
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddOpenApiDocument((configure, serviceProvider) =>
            {
                configure.Title = "Tahu Pi API";
                configure.Description = "COD di Akhirat cuy klo gapercaya";
                configure.AllowNullableBodyParameters = false;
                configure.AllowReferencesWithProperties = true;
                configure.IgnoreObsoleteProperties = true;
                configure.DefaultReferenceTypeNullHandling = ReferenceTypeNullHandling.NotNull;
                //configure.AddSecurity("JWT", Enumerable.Empty<string>(), new OpenApiSecurityScheme
                //{
                //    Type = OpenApiSecuritySchemeType.ApiKey,
                //    Name = "Authorization",
                //    In = OpenApiSecurityApiKeyLocation.Header,
                //    Description = "Type into the textbox: Bearer {your JWT token}."
                //});

                configure.OperationProcessors.Add(new AspNetCoreOperationSecurityScopeProcessor("JWT"));
                configure.PostProcess = document =>
                {
                    document.Info.Contact = new NSwag.OpenApiContact
                    {
                        Name = "BikeStore",
                        Email = "zaday@tahu.com",
                        Url = "https://www.zadaytahupii.com"
                    };
                };

            });
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
                app.UseHsts();
            }
            app.UseOpenApi();
            app.UseSwaggerUi3(settings =>
            {
                settings.Path = "/swagger";
                settings.EnableTryItOut = true;

            });
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
