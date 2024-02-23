using App.Api.Configurations;

namespace App.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.ConfigureDatabase(builder.Configuration);
            builder.Services.AddAutoMapper(typeof(Program));
            builder.Services.ResolveDependencies();

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            else
            {
                app.UseHttpsRedirection();
            }


            app.UseAuthorization();

            app.MapControllers();

            app.CreateDatabase();
            app.PopulateDatabase();

            app.Run();

        }
    }
}
