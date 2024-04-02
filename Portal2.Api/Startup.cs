using Portal2.CrossCutting.Configurations;

namespace Portal2.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddMvc();

            services.InjectDependencies(Configuration);

            services.AddSwaggerGen();
            services.AddSwaggerConfiguration();
            services.AddEndpointsApiExplorer();

            services.AddCors(options => options.AddPolicy("CorsPolicy",
            builder =>
            {
                builder.WithOrigins("http://localhost:4200/")
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .SetIsOriginAllowed((host) => true)
                        .AllowCredentials();
            }));

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseCors("CorsPolicy");
        }
    }
}
