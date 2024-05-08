using DesignPatternAsp;
using Tools.Earn;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.Configure<MyOptions>(builder.Configuration.GetSection("MyOptions"));

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
