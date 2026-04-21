using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NutricionApp.Controllers;
using NutricionApp.Data;
using NutricionApp.Data.Repositories;
using NutricionApp.Data.Repositories.Abstractions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// Base de datos SQLite
builder.Services.AddSingleton<DatabaseContext>();

// Repositorios — acceso a datos (Patron Repository)
builder.Services.AddScoped<IUsuarioRepository,  UsuarioRepository>();
builder.Services.AddScoped<IAlimentoRepository, AlimentoRepository>();
builder.Services.AddScoped<IMenuRepository,     MenuRepository>();
builder.Services.AddScoped<IPerfilRepository,   PerfilRepository>();

// Estado de sesion por circuito Blazor
builder.Services.AddScoped<NutricionApp.AppState>();

// Controladores — logica de negocio (dependen de repositorios, no de DB directamente)
builder.Services.AddScoped<LoginController>();
builder.Services.AddScoped<AlimentoController>();
builder.Services.AddScoped<MenuController>();
builder.Services.AddScoped<PerfilController>();
builder.Services.AddScoped<UserManagementController>();

var app = builder.Build();

// Inicializar BD al arrancar
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
    db.Initialize();
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
app.Run();
