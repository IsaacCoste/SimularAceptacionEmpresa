using SimularAceptacionEmpresa.Components;
using SimularAceptacionEmpresa.DAL;
using Microsoft.EntityFrameworkCore;
using SimularAceptacionEmpresa.Service;
using SimularAceptacionEmpresa.Models;
using SimularAceptacionEmpresa.Services;

var builder = WebApplication.CreateBuilder(args);


var ConStr = builder.Configuration.GetConnectionString("ConStr");
builder.Services.AddDbContext<Contexto>(options => options.UseSqlite(ConStr));
builder.Services.AddScoped<RecursoService>();
builder.Services.AddScoped<ActividadService>();
builder.Services.AddScoped<IngresoService>();
builder.Services.AddScoped<PreguntaService>();
builder.Services.AddScoped<EmpresaService>();
//builder.Services.AddScoped<>();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
