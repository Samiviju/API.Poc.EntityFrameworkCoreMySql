using Microsoft.OpenApi.Models;

namespace Api.Poc.EntityFrameworkCoreMySql.Configuracao
{
    public static class ConfiguracaoSwagger
    {
        public static IApplicationBuilder UsarConfiguracoesSwagger(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment() || env.IsEnvironment("Local"))
            {
                app.UseSwagger(c =>
                {
                    c.RouteTemplate = "/api-docs/{documentName}/swagger.json";
                });

                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("v1/swagger.json", "API.Poc.EntityFrameworkCore");
                    c.RoutePrefix = "api-docs";
                });
            }

            return app;
        }

        public static IServiceCollection AdicionarConfiguracoesSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(swagger =>
            {
                swagger.SwaggerDoc("v1", new OpenApiInfo { Title = "API.Poc.EntityFrameworkCore" });
                var documentacaoWebAPI = Path.Combine(AppContext.BaseDirectory, "API.Poc.EntityFrameworkCore.xml");
                swagger.IncludeXmlComments(documentacaoWebAPI);

                swagger.AddSecurityDefinition("Autorização", new OpenApiSecurityScheme
                {
                    Description = "Insira a api key da aplicação",
                    Name = "x-api-key",
                    Scheme = "basic",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });

                swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Autorização"
                            }
                        },
                        new string[] {}
                    }
                });
            });

            return services;
        }
    }
}