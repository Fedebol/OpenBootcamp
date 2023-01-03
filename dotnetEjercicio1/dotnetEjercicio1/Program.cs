//1. Using to work whit EntityFramework

using Microsoft.EntityFrameworkCore;
using dotnetEjercicio1.DataAccess;
using dotnetEjercicio1.Service;
using dotnetEjercicio1;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);


// 2. Connection whit SQL Server Express

const string CONNECTIONNAME = "UniversityDB";
var connectionString = builder.Configuration.GetConnectionString(CONNECTIONNAME);

// 3. Add Context to Services of builder
builder.Services.AddDbContext<UniversityDBContext>(options => options.UseSqlServer(connectionString));

// 7. Add Service of JWT Autorization
builder.Services.AddJwTokenServices(builder.Configuration);

// Add services to the container.

builder.Services.AddControllers();

// 4. Add Custom Services (folder Services)

builder.Services.AddScoped<IStudentsService,StudentsService>();
// TODO: add the rest of services


// 8. Add Authorization
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("UserOnlyPolicy", policy => policy.RequireClaim("UserOnly", "User 1"));
});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// 9. config swagger to take care of autorization of JWT
builder.Services.AddSwaggerGen( options =>
    {
        options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {

        });


    }
);

// 5. CORS Configuration
builder.Services.AddCors(options =>
    {
        options.AddPolicy(name: "CorsPolicy", builder =>
        {
            builder.AllowAnyOrigin();
            builder.AllowAnyMethod();
            builder.AllowAnyHeader();
        });
    }
);

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

// 6. Tell app to use CORS
app.UseCors("CorsPolicy");

app.Run();
