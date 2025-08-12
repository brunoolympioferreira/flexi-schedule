using FlexiSchedule.API.Filters;
using FlexiSchedule.Application;
using FlexiSchedule.Application.Validations.Professional;

namespace FlexiSchedule.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddValidatorsFromAssemblyContaining<ProfessionalInputModelValidator>();
            builder.Services.AddScoped<ValidationFilter>();

            builder.Services.AddControllers(options =>
            {
                options.Filters.AddService<ValidationFilter>();
            });

            var dbHost = Environment.GetEnvironmentVariable("DB_HOST")
             ?? builder.Configuration["DatabaseConfig:Host"];
            var dbPort = Environment.GetEnvironmentVariable("DB_PORT")
                         ?? builder.Configuration["DatabaseConfig:Port"];
            var dbName = Environment.GetEnvironmentVariable("DB_NAME")
                         ?? builder.Configuration["DatabaseConfig:Name"];
            var dbUser = Environment.GetEnvironmentVariable("DB_USER")
                         ?? builder.Configuration["DatabaseConfig:User"];
            var dbPass = Environment.GetEnvironmentVariable("DB_PASSWORD")
                         ?? builder.Configuration["DatabaseConfig:Password"];

            var connectionString = $"Server={dbHost},{dbPort};Database={dbName};User Id={dbUser};Password={dbPass};TrustServerCertificate=True;";

            builder.Services.AddInfrascructure(connectionString);
            builder.Services.AddApplication();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
