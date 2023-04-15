using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Scrum_Twister.Core.Services.ReturnModelFillers.CommonRMFs;
using System.Reflection;

namespace Scrum_Twister.Core.ExtensionsMethods
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCoreInjections
            (this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddTransient<AvatarsListRMF>();

            return services;
        }
    }
}
