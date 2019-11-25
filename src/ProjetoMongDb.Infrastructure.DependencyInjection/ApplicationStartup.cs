using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjetoMongDb.Infrastructure.Bootstrap.Extensions.ApplicationBuilder;
using ProjetoMongDb.Infrastructure.Bootstrap.Extensions.ServiceCollection;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Super.Swagger.ApplicationBuilder;
using Super.Swagger.ServiceCollection;
using Swashbuckle.AspNetCore.Swagger;

namespace ProjetoMongDb.Infrastructure.Bootstrap
{
	public class ApplicationStartup
	{
		public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
		{
			services.AddMvc().AddJsonOptions(options =>
			{
				options.SerializerSettings.Converters.Add(new StringEnumConverter());
				options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
			});

			services.AddApiVersion();
			services.AddCustomHealthChecks();
			services.AddSuperSwagger(new Info()
			{
				Title = "Serviço",
				Description = "Descrição do serviço",
			});

			services.AddCustomResponseCompression();
			services.AddMetrics();
            services.AddMongo();
        }

		public void Configure(IApplicationBuilder app, IHostingEnvironment env, IApiVersionDescriptionProvider provider)
		{
			app.UseSuperSwagger(provider);
			app.UseCustomHealthChecks();
			app.UseResponseCompression();
			app.UseMvc();
		}
	}
}
