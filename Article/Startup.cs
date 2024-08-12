using Microsoft.EntityFrameworkCore;
using ArticleApp.Data;
using System.Reflection;
using Regnology.Data;

namespace ArticleApp
{
    public class Startup
    {
        private static readonly Assembly _currentAssembly = typeof(Startup).Assembly;
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(
                options => options.UseNpgsql(@"Server=localhost;Port=5432;Userid=postgres;Password=password;Database=Article"));
            services.AddAutoMapper(_currentAssembly);
            services.AddAuthentication();
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddTransient<IQueryService<Article>, ArticleQueryService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
