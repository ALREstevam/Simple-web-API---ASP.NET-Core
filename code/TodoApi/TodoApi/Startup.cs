using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TodoApi.Models;

/*
# Register the database context
In this step, the database context is registered with the dependency injection container. 
Services (such as the DB context) that are registered with the dependency injection (DI) container are available to the controllers.
*/

namespace TodoApi
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<TodoContext>(opt => opt.UseInMemoryDatabase("TodoList"));
            services.AddMvc();

        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseMvc();
        }
    }
}