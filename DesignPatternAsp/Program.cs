using DesignPatternAsp;
using Microsoft.EntityFrameworkCore;
using PatronesDise�o.Models.Data;
using PatronesDise�o.Repository;
using Tools.BuilderGenerator;
using Tools.Earn;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.Configure<MyOptions>(builder.Configuration.GetSection("MyOptions"));
//a�ado el contexto de mi bd
builder.Services.AddDbContext<DiagnosticoContext>(
    options => {
        options.UseSqlServer(builder.Configuration.GetConnectionString("Connection"));
    });
//a�ado unitofwork
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

//add buildergenerator
builder.Services.AddScoped<GeneratorConcreteBuilder>();

//PARA QUE RECIBA LAS INTERFACES Y SU IMPLEMENTACION X INYECCION Y NO SE ENCARGUE DE CREARLA ELLA.
builder.Services.AddScoped(typeof(IPatronesDise�oRepository<>), typeof(PatronesDise�oRepository<>)); 
//inyecto la fabrica

builder.Services.AddTransient((factory) =>
{
    return new EarnLocalFactory(builder.Configuration.GetSection("MyOptions").GetValue<decimal>("PercentageLocal")); // se lo inyecto desde el json
 });
builder.Services.AddTransient((factory) =>
{
    return new EarnForeignFactory(builder.Configuration.GetSection("MyOptions").GetValue<decimal>("PercentageForeign"), builder.Configuration.GetSection("MyOptions").GetValue<decimal>("Extra"));

});

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
