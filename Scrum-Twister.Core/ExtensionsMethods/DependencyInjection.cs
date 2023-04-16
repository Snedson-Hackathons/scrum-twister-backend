using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Scrum_Twister.Core.Services;
using Scrum_Twister.Core.Services.ReturnModelFillers.CommonRMFs;
using Scrum_Twister.Core.Services.ReturnModelFillers.ScrumMasterRMFs;
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
            services.AddTransient<StartNewSessionRMF>();
            services.AddTransient<GetNextActivityRMF>();

            services.AddTransient<HeximalNumbersGeneratorService>();

            return services;
        }
    }
}
