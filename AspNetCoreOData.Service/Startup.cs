﻿using System;
using AspNetCoreOData.Service.Database;
using AspNetCoreOData.Service.Models;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OData.Edm;
using Serilog;

namespace AspNetCoreOData.Service
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
            services.AddDbContext<AdventureWorks2016Context>(options =>
              options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
              .AddIdentityServerAuthentication(options =>
              {
                  options.Authority = "https://localhost:44318";
                  options.ApiName = "AspNetCoreODataServiceApi";
                  options.ApiSecret = "AspNetCoreODataServiceApiSecret";
                  options.RequireHttpsMetadata = true;
              });

            services.AddAuthorization(options =>
                options.AddPolicy("ODataServiceApiPolicy", policy =>
                {
                    policy.RequireClaim("scope", "ScopeAspNetCoreODataServiceApi");
                })
            );

            services.AddOData();
            services.AddODataQueryFilter();

            services.AddControllers(options =>
            {
                options.EnableEndpointRouting = false;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseCors("AllowAllOrigins");

            app.UseSerilogRequestLogging();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapODataRoute("odata", "odata", GetEdmModel(app.ApplicationServices));
            });
        }

        private static IEdmModel GetEdmModel(IServiceProvider serviceProvider)
        {
            ODataModelBuilder builder = new ODataConventionModelBuilder(serviceProvider);

            builder.EntitySet<Address>("Address")
                .EntityType
                .Filter()
                .Count()
                .Expand()
                .OrderBy()
                .Page()
                .Select();

            builder.EntitySet<AddressType>("AddressType")
                .EntityType
                .Filter()
                .Count()
                .Expand()
                .OrderBy()
                .Page()
                .Select();

            builder.EntitySet<BusinessEntity>("BusinessEntity")
                .EntityType
                .Filter()
                .Count()
                .Expand()
                .OrderBy()
                .Page()
                .Select();
            builder.EntitySet<BusinessEntityAddress>("BusinessEntityAddress")
                .EntityType
                .Filter()
                .Count()
                .Expand()
                .OrderBy()
                .Page()
                .Select();

            builder.EntitySet<BusinessEntityContact>("BusinessEntityContact")
                .EntityType
                .Filter()
                .Count()
                .Expand()
                .OrderBy()
                .Page()
                .Select();

            builder.EntitySet<ContactType>("ContactType")
                .EntityType
                .Filter()
                .Count()
                .Expand()
                .OrderBy()
                .Page()
                .Select();

            builder.EntitySet<CountryRegion>("CountryRegion")
                .EntityType
                .Filter()
                .Count()
                .Expand()
                .OrderBy()
                .Page()
                .Select();

            builder.EntitySet<EmailAddress>("EmailAddress")
                .EntityType
                .Filter()
                .Count()
                .Expand()
                .OrderBy()
                .Page()
                .Select();

            builder.EntitySet<Password>("Password")
                .EntityType
                .Filter()
                .Count()
                .Expand()
                .OrderBy()
                .Page()
                .Select();

            builder.EntitySet<Person>("Person")
                .EntityType
                .Filter()
                .Count()
                .Expand()
                .OrderBy()
                .Page()
                .Select();
            builder.EntitySet<PersonPhone>("PersonPhone")
                .EntityType
                .Filter()
                .Count()
                .Expand()
                .OrderBy()
                .Page()
                .Select();

            builder.EntitySet<PhoneNumberType>("PhoneNumberType")
                .EntityType
                .Filter()
                .Count()
                .Expand()
                .OrderBy()
                .Page()
                .Select();

            builder.EntitySet<StateProvince>("StateProvince")
                .EntityType
                .Filter()
                .Count()
                .Expand()
                .OrderBy()
                .Page()
                .Select();

            builder.EntitySet<EntityWithEnum>("EntityWithEnum")
                .EntityType
                .Filter()
                .Count()
                .Expand()
                .OrderBy()
                .Page()
                .Select();

            EntitySetConfiguration<ContactType> contactType = builder.EntitySet<ContactType>("ContactType");
            var actionY = contactType.EntityType.Action("ChangePersonStatus");
            actionY.Parameter<string>("Level");
            actionY.Returns<bool>();

            var changePersonStatusAction = contactType.EntityType.Collection.Action("ChangePersonStatus");
            changePersonStatusAction.Parameter<string>("Level");
            changePersonStatusAction.Returns<bool>();

            EntitySetConfiguration<Person> persons = builder.EntitySet<Person>("Person");
            FunctionConfiguration myFirstFunction = persons.EntityType.Collection.Function("MyFirstFunction");
            myFirstFunction.ReturnsCollectionFromEntitySet<Person>("Person");

            EntitySetConfiguration<EntityWithEnum> entitesWithEnum = builder.EntitySet<EntityWithEnum>("EntityWithEnum");
            FunctionConfiguration functionEntitesWithEnum = entitesWithEnum.EntityType.Collection.Function("PersonSearchPerPhoneType");
            functionEntitesWithEnum.Parameter<PhoneNumberTypeEnum>("PhoneNumberTypeEnum");
            functionEntitesWithEnum.ReturnsCollectionFromEntitySet<EntityWithEnum>("EntityWithEnum");

            return builder.GetEdmModel();
        }
    }
}
