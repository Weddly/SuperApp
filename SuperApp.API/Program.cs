using Microsoft.EntityFrameworkCore;
using SuperApp.Application.Applications;
using SuperApp.Application.Interfaces;
using SuperApp.Infra.Data.Context;
using SuperApp.Infra.Data.Interfaces;
using SuperApp.Infra.Data.Repository;
using SuperApp.Infra.Data.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddCors(options =>
{
    options.AddPolicy("VueAppPolicy", policyBuilder =>
    {
        policyBuilder.WithOrigins("http://localhost:8080") // Vue dev server default
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});



var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<SuperAppContext>(options => { options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)); });

builder.Services.AddScoped<IDeckApplication, DeckApplication>();
builder.Services.AddScoped<IDeckRepository, DeckRepository>();
builder.Services.AddScoped<ICardApplication, CardApplication>();
builder.Services.AddScoped<ICardRepository, CardRepository>();
builder.Services.AddScoped<IPrizeApplication, PrizeApplication>();
builder.Services.AddScoped<IPrizeRepository, PrizeRepository>();
builder.Services.AddScoped<ISuperHeroApplication, SuperHeroApplication>();
builder.Services.AddHttpClient<ISuperHeroService, SuperHeroService>();

var app = builder.Build();

app.UseCors("VueAppPolicy");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
