using System.Collections.Generic;
using CQRS.Meetup.Infra;
using CQRS.Meetup.Infra.Repositories.Products;
using CQRS.Meetup.Read;
using CQRS.Meetup.Read.Queries.Products;
using CQRS.Meetup.Read.QueriesHandler;
using CQRS.Meetup.Read.QueriesHandler.Products;
using CQRS.Meetup.Read.ReadModel.Products;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CQRS.Meetup.Write.Commands.Products;
using CQRS.Meetup.Write.CommandsHandler;
using CQRS.Meetup.Write.CommandsHandler.Products;
using CQRS.Meetup.Write.Repositories;

namespace CQRS.Meetup.Web
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            //todo gub : better place to initialize it ? 
            //var bus = new CommandBus();

            //var createProductCommand = new CreateProductCommandHandler(new ProductRepository());
            //bus.RegisterHandler<CreateProductCommand>(createProductCommand.Handle);

            //services.AddSingleton<ICommandSender>(bus);


            services.AddTransient<ICommandHandler<CreateProductCommand>, CreateProductCommandHandler>();
            services.AddTransient<IQueryHandler<GetProductsQuery, List<ProductDto>>, GetListQueryHandler>();
            services.AddSingleton<CommandProcessor>();
            services.AddSingleton<QueryProcessor>();
            services.AddScoped<CQRSContext>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddSingleton<IProvideProduct, ProductProvider>();
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
    }
}
