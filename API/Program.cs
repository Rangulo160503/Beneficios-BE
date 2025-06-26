// Interfaces
using Abstracciones.Interfaces.DA;
using Abstracciones.Interfaces.Flujo;
using DA.Repositorios;
using Flujo;
// Modelos
using Abstracciones.Modelos;
// JWT
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// -----------------------------
// Configuración del token JWT
// -----------------------------
var tokenConfiguration = builder.Configuration
    .GetSection("Token")
    .Get<TokenConfiguracion>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = tokenConfiguration.Issuer,
            ValidAudience = tokenConfiguration.Audience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenConfiguration.key))
        };
    });

// -----------------------------
// Servicios base
// -----------------------------
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();

// -----------------------------
// Inyección de dependencias – Categorías y Servicios
// -----------------------------
builder.Services.AddScoped<IServicioFlujo, ServicioFlujo>();
builder.Services.AddScoped<IServicioDA, ServicioDA>();
builder.Services.AddScoped<IRepositorioDapper, RepositorioDapper>();

var app = builder.Build();

// -----------------------------
// Middleware
// -----------------------------
app.UseSwagger();       // <- Mostrar swagger SIEMPRE
app.UseSwaggerUI();     // <- Mostrar swagger SIEMPRE

// Elimina redirección si no usás HTTPS bien configurado
// app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();