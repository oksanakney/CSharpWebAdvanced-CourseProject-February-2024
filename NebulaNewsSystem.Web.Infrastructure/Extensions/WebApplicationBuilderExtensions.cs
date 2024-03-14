using Microsoft.Extensions.DependencyInjection;
using NebulaNewsSystem.Services.Data;
using NebulaNewsSystem.Services.Data.Interfaces;
using System.Reflection;

namespace NebulaNewsSystem.Web.Infrastructure.Extensions
{
    public static class WebApplicationBuilderExtensions
    {
        /// <summary>
        /// This method registers all services with their interfaces and implementations of given assembly.
        /// The Assembly is taken from the type of random service implementation provided
        /// </summary>        
        /// <param name="serviceType">Type of Random Service Implementation.</param>
        /// <exception cref="InvalidOperationException"></exception>
        public static void AddApplicationServices(this IServiceCollection services, Type serviceType)
        {
            Assembly? servicEAssembly = Assembly.GetAssembly(serviceType);
            if (servicEAssembly == null)
            {
                throw new InvalidOperationException("Invalid service type provided!");
            }

            Type[] serviceTypes = servicEAssembly
                .GetTypes()
                .Where(t => t.Name.EndsWith("Service") && !t.IsInterface)
                .ToArray();

            foreach (Type implementationType in serviceTypes)
            {
                Type? interfaceType = implementationType
                    .GetInterface($"I{implementationType.Name}");

                if (interfaceType == null)
                {
                    throw new InvalidOperationException($"No interface is provided for the servise with name:{implementationType.Name}");
                }

                services.AddScoped(interfaceType, implementationType);
            }

            services.AddScoped<IArticleService, ArticleService>();
        }
    }
}
