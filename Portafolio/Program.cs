using Portafolio.Servicios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IRepositorioProyectos, RepositorioProyectos>();

builder.Services.AddTransient<ServicioTransitorio>();
builder.Services.AddScoped<ServicioDelimitado>();
builder.Services.AddSingleton<ServicioUnico>();

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


/*
Aqui se encuentra la configuracion del Ruteo

Es el Ruteo convencional, no por atributo
Tenemos una ruta por partes:
    1º - Controlador
    2º - Acion
    3º - Id. Opcional por el ?

Aqui esta la ruta por defecto ("default"), que ejecuta la accion Index del Controlador Home
En esa vista (y en todas) se carga el Layout con el navbar que permite seguir navegando entre vistas
Por eso aqui solo esta definida esta que es la de por defecto
*/
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
