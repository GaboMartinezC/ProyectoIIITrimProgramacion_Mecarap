using ProyectoIIITrimProgramacion_Mecarap.Datos;
using ProyectoIIITrimProgramacion_Mecarap.Datos.Repositorio;
using ProyectoIIITrimProgramacion_Mecarap.Datos.Repositorio.IRepositorio;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IClienteRepositorio, ClienteRepositorio>();
builder.Services.AddScoped<IEstadoRepositorio, EstadoRepositorio>();
builder.Services.AddScoped<IHojaIngresoRepositorio, HojaIngresoRepositorio>();
builder.Services.AddScoped<IInformeFinalRepositorio, InformeFinalRepositorio>();
builder.Services.AddScoped<IMecanicoRepositorio, MecanicoRepositorio>();
builder.Services.AddScoped<IObservacionRepositorio, ObservacionRepositorio>();
builder.Services.AddScoped<IProgresoRepositorio, ProgresoRepositorio>();
builder.Services.AddScoped<IReparacionRepositorio, ReparacionRepositorio>();
builder.Services.AddScoped<ITipoAutoRepositorio, TipoAutoRepositorio>();
builder.Services.AddScoped<ITipoUsuarioRepositorio, TipoUsuarioRepositorio>();
builder.Services.AddScoped<IVehiculoRepositorio, VehiculoRepositorio>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
