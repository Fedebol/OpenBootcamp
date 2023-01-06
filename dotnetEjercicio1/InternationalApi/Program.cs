var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//1. LOCALIZATION

builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 2. SUPPORTED CULTURES

var supportedCultures = new[] { "en-US", "es-ES", "fr-FR" }; // USA inglish, spain spanish, frence french
var localizationOption = new RequestLocalizationOptions()
    .SetDefaultCulture(supportedCultures[0]) //default
    .AddSupportedCultures(supportedCultures) //todas
    .AddSupportedUICultures(supportedCultures); // cultures po UI

// 3. ADD LOCALIZATION to app

app.UseRequestLocalization(localizationOption);

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
