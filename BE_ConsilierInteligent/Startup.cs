using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using BE_ConsilierInteligent.DataAccess.Persistence;
using AutoMapper;


namespace BE_ConsilierInteligent
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            /*services.AddDbContext<ConsilierContext>(
                   options =>
                   options.UseSqlServer("Server=DESKTOP-L0JCS3H\\SQLEXPRESS; Database=ConsilierDB; Trusted_Connection= True; MultipleActiveResultSets=True; TrustServerCertificate=True; User ID=CommanderAPI; Password=Destinul04;", x => x.MigrationsAssembly("BE_ConsilierInteligent.API")));
            */
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BE_ConsilierInteligent", Version = "v1" });
            });
            services.AddCors();

            services.AddAutoMapper(config =>
            {
                config.CreateMap<Models.Utilizator, BE_ConsilierInteligent.DataAccess.Entities.Utilizator>();
                config.CreateMap<Models.Consilier, BE_ConsilierInteligent.DataAccess.Entities.Consilier>()
                    .ForMember(dest => dest.Utilizator, opt => opt.MapFrom(src => src.Utilizator));
            });


        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(builder =>
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader());
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    string swaggerJsonBasePath = string.IsNullOrWhiteSpace(c.RoutePrefix) ? "." : "..";
                    c.SwaggerEndpoint($"{swaggerJsonBasePath}/swagger/v1/swagger.json", "BE_ConsilierInteligent v1");
                });

                app.UseHttpsRedirection();

                app.UseRouting();

                app.UseAuthorization();

                app.UseHttpsRedirection();

                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });
            }
        }
    }
}