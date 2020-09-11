using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace GandaSpents.Middlewares
{
	public class FeatureSwitchingMiddleware
	{
		private readonly IConfiguration _config;
		private readonly RequestDelegate _next;

		public FeatureSwitchingMiddleware(IConfiguration config, RequestDelegate next)
		{
			_config = config;
			_next = next;
		}

		public async Task Invoke(HttpContext httpContext)
		{


			//checkar se o url tem features
			if (httpContext.Request.Path.Value.Contains("/features"))
			{

				//Obter a secção do appsettings.json file
				var switches = _config.GetSection("Features");

				// Loop pelos filhos da secção e geramos uma lista com os valores
				var report = switches.GetChildren().Select(x => $"{x.Key} : {x.Value}");

				//Gerar a resposta
				await httpContext.Response.WriteAsync(string.Join("\n", report));


			}
			else
			{
				// Senão tiver features no link , passar para o proximo middleware
				await _next(httpContext);
			}
		}
	}
}
