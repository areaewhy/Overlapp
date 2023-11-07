using Microsoft.Extensions.DependencyInjection;
using Overlapp.Shared.Model;

namespace Overlapp.Client
{
	public static class DependencyInjectionExtension
	{
		public static IServiceCollection AddOverlappServices(this IServiceCollection services)
		{
			services.AddScoped<IQueryService, QueryService>();
			services.AddScoped<ComparisonService>();
			services.AddScoped<ImageConfigurationService>();

			return services;
		}
	}
}
