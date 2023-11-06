using Microsoft.Extensions.DependencyInjection;
using Overlapp.Client.Service;

namespace Overlapp.Client
{
	public static class ServiceExtension
	{
		public static IServiceCollection AddOverlappServices(this IServiceCollection services)
		{
			services.AddScoped<IQueryService, QueryService>();
			services.AddScoped<ComparisonService>();

			return services;
		}
	}
}
