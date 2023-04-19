using Microsoft.EntityFrameworkCore;
using oneparalyzer.LeasingSystem.Auth.Api.Data;
using oneparalyzer.LeasingSystem.Auth.Api.Services.Implementations;
using oneparalyzer.LeasingSystem.Auth.Api.Services.Interfaces;
using oneparalyzer.LeasingSystem.Auth.Api.Settings;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddDbContext<AuthDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
    builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection(JwtSettings.SectionName));
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddScoped<IJwtTokenService, JwtTokenService>();
    builder.Services.AddCors();
}

var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseCors(builder =>
    {
        builder.AllowAnyOrigin();
        builder.AllowAnyHeader();
    });
    app.UseHttpsRedirection();
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();
    app.Run();
}


