using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NutricionApp.Controllers;
using NutricionApp.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// Base de datos SQLite — reemplaza los CSV de la iteracion 1
builder.Services.AddSingleton<DatabaseContext>();

// Estado de sesion por circuito Blazor
builder.Services.AddScoped<NutricionApp.AppState>();

// Controladores del proyecto 1 — mismas interfaces, ahora con SQLite
builder.Services.AddScoped<LoginController>();
builder.Services.AddScoped<AlimentoController>();
builder.Services.AddScoped<MenuController>();
builder.Services.AddScoped<PerfilController>();

var app = builder.Build();

// Inicializar BD al arrancar (crea tablas y siembra datos si esta vacia)
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
