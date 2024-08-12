using Microsoft.EntityFrameworkCore;
using ArticleApp.Data;
using System.Reflection;
using Regnology.Data;
using Serilog;
using MediatR;
using ArticleApp.Data.User.Repository;
using Microsoft.AspNetCore.Authentication;

namespace ArticleApp
{
    public class Program
    {
        private static readonly Assembly _currentAssembly = typeof(Program).Assembly;

        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                 .Enrich.FromLogContext()    
                 .WriteTo.Console()          
                 .CreateLogger();

            try
            {
                Log.Information("Application starting");
                var builder = WebApplication.CreateBuilder(args);

                ConfigureServices(builder.Services, builder.Configuration);

                var app = builder.Build();

                Configure(app, app.Environment);

                app.Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "The application did not start");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        private static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            services.AddAutoMapper(_currentAssembly);
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddTransient<IQueryService<Article>, ArticleQueryService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddAuthentication("BasicAuthentication").
            AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>
            ("BasicAuthentication", null); ;


        }

        private static void Configure(WebApplication app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();

            app.MapControllers();
        }
    }
}