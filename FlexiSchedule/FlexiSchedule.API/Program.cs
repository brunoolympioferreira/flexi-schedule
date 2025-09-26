namespace FlexiSchedule.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddValidatorsFromAssemblyContaining<ProfessionalCreateInputModelValidator>();
            builder.Services.AddScoped<ValidationFilter>();

            builder.Services.AddControllers(options =>
            {
                options.Filters.AddService<ValidationFilter>();
            });

            // Database configuration
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

            // JWT Configuration
            var isDocker = !string.IsNullOrEmpty(Environment.GetEnvironmentVariable("DB_HOST"));

            var jwtKey = Environment.GetEnvironmentVariable("JWT_KEY")
                ?? builder.Configuration["Jwt:Key"]
                ?? throw new InvalidOperationException("JWT Key não configurada");

            var jwtIssuer = Environment.GetEnvironmentVariable("JWT_ISSUER")
                ?? builder.Configuration["Jwt:Issuer"]
                ?? "FlexiScheduleSystem";

            var jwtAudience = Environment.GetEnvironmentVariable("JWT_AUDIENCE")
                ?? builder.Configuration["Jwt:Audience"]
                ?? "FlexiScheduleSystem";

            // JWT Authentication
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey)),
                        ValidateIssuer = true,
                        ValidIssuer = jwtIssuer,
                        ValidateAudience = true,
                        ValidAudience = jwtAudience,
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero
                    };

                });

            //Redis Configuration
            builder.Services.AddStackExchangeRedisCache(options =>
            {
                var redisHost = Environment.GetEnvironmentVariable("REDIS_HOST")
                    ?? builder.Configuration.GetConnectionString("Redis")
                    ?? "localhost:6379";

                options.Configuration = redisHost;
                options.InstanceName = "FlexiSchedule_";
            });

            builder.Services.AddExceptionHandler<CustomExceptionHandler>();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = Microsoft.OpenApi.Models.ParameterLocation.Header,
                    Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
                {
                    {
                        new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                        {
                            Reference = new Microsoft.OpenApi.Models.OpenApiReference
                            {
                                Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });

            var app = builder.Build();

            // Apply Migrations if is Docker
            if (isDocker)
            {
                using var scope = app.Services.CreateScope();
                var context = scope.ServiceProvider.GetRequiredService<FlexiScheduleSQLServerDbContext>();
                try
                {
                    context.Database.Migrate();
                    app.Logger.LogInformation("Database migration completed successfully (Docker environment)");
                }
                catch (Exception ex)
                {
                    app.Logger.LogError(ex, "An error occurred while migrating the database");
                    throw;
                }
            }

            app.UseExceptionHandler(options => { });

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();

            // Health check endpoint
            app.MapGet("/health", () => Results.Ok(new
            {
                Status = "Healthy",
                Timestamp = DateTime.UtcNow,
                Environment = app.Environment.EnvironmentName,
                Database = isDocker ? "Docker" : "Local"
            }));

            app.Run();
        }
    }
}
