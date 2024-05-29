using DatosBD.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Configurar el contexto de la base de datos
var connectionString = "Server=G„MEZ\\CESARSERVER;Database=Proyecto1BD;TrustServerCertificate=True;Trusted_Connection=True;"; // Ejemplo: "Server=myServerAddress;Database=myDataBase;User Id=myUsername;Password=myPassword;"
builder.Services.AddDbContext<Proyecto1BdContext>(options =>
    options.UseSqlServer(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Redirigir a la p·gina de inicio de sesiÛn
app.Use(async (context, next) =>
{
    if (!context.Request.Path.HasValue || context.Request.Path == "/")
    {
        context.Response.Redirect("/InicioDeSesion/Login");
        return;
    }

    await next();
});

app.MapRazorPages();

app.Run();
