using Microsoft.EntityFrameworkCore;
using Stiven_Santana_P2_P1.Components;
using Stiven_Santana_P2_P1.DAL;
using Stiven_Santana_P2_P1.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Obtenemos el ConStr para usarlo en el contexto
var ConStr = builder.Configuration.GetConnectionString("SqlConStr");

// Agregamos el contexto al builder con el ConStr
builder.Services.AddDbContextFactory<Contexto>(o => o.UseSqlServer(ConStr));

// Inyección del servicio (MOVIDO antes de builder.Build())
builder.Services.AddScoped<CiudadesService>();

var app = builder.Build(); 

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
