using cs_MVC_sprint.Models;
using cs_MVC_sprint.Services;

namespace cs_MVC_sprint
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            var app = builder.Build();

            builder.Services.AddScoped<AuthorService>();
            builder.Services.AddScoped<Author>();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                _ = endpoints.MapControllers();
            });

            app.Run();
        }
    }
}
