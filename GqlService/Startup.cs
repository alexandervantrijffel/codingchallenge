using HotChocolate;
using HotChocolate.AspNetCore;
using HotChocolate.AspNetCore.Voyager;
using HotChocolate.Subscriptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace GqlService
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IDataRefValueReader, DummyDataRefProvider>();
            
            services.AddSingleton<Query>();
            services.AddSingleton<DataReferencesQuery>();

            services.AddSingleton<Subscription>();
            services.AddSingleton<Mutation>();
            services.AddSingleton<Mutation.DataReferenceMutation>();

            services.AddInMemorySubscriptionProvider();
            services.AddInMemorySubscriptions();

            // Add GraphQL Services
            services.AddGraphQL(Schema.Create());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app
                .UseRouting()
                .UseWebSockets()
                .UseGraphQL()
                .UsePlayground()
                .UseVoyager();
        }
    }
}