namespace YachtTea
{
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
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;
    using Microsoft.OpenApi.Models;
    using Paramore.Brighter.Extensions;
    using Paramore.Darker.AspNetCore;
    using YachtTea.Queries.Handlers;
    using YachtTea.Actions.Handlers;
    using Paramore.Brighter;
    using YachtTea.Actions;
    using YachtTea.Repositories;

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
            services.AddSingleton<IGameRepository, GameRepository>();

            services.AddDarker()
                .AddHandlersFromAssemblies(typeof(GameQueryHandler).Assembly);

            services.AddTransient<NewGameActionHandlerAsync>();

            services.AddTransient<IAmACommandProcessor>((provider) => {
                var registry = new SubscriberRegistry();
                registry.RegisterAsync<NewGameAction, NewGameActionHandlerAsync>();

                var commandProcessorBuilder = CommandProcessorBuilder.With()
                    .Handlers(new HandlerConfiguration(registry, new ActionHandlerFactoryAsync(provider)))
                    .DefaultPolicy()
                    .NoTaskQueues()
                    .RequestContextFactory(new InMemoryRequestContextFactory());
                
                return commandProcessorBuilder.Build();
            });

            services.AddControllers();

            services.AddCors();

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Yacht Tea API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Yacht Tea API V1");
            });

            app.UseCors(builder =>
                builder.WithOrigins("http://localhost:4200")
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials());

            // app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
