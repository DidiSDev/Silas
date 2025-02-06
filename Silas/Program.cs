using Silas.Models.Usuarios;
using Silas.Models.Companies;
using Silas.Models.Offers;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.AddConsole(); // Agrega el log de consola

// Add services to the container.
builder.Services.AddHttpClient<UserService>();
builder.Services.AddHttpClient<CompanyService>();
builder.Services.AddHttpClient<OfferService>(); // Registro de OfferService

builder.Services.AddControllersWithViews();

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
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();
