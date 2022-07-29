using Api.Poc.EntityFrameworkCoreMySql.Middleware;

namespace Api.Poc.EntityFrameworkCoreMySql.Configuracao
{
    public static class ConfiguracaoApi
    {
        public static IServiceCollection AdicionarConfiguracaoApi(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddHttpContextAccessor();

            return services;
        }

        public static IApplicationBuilder UsarConfiguracaoApi(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseCors(options =>
                    options
                    .AllowAnyHeader()
                    .AllowAnyOrigin()
                    .AllowAnyMethod());
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseMiddleware(typeof(ErrorHandlerMiddleware));

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Welcome to running ASP.NET Core on AWS Lambda");
                });
            });

            return app;
        }
    }
}