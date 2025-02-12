using Silas.Models.Companies;
using Silas.Models.Offers;
using Silas.Models.Usuarios;
using Silas.Models.Companies;
using Silas.Models.Offers;
using Silas.Models.Student;
using Silas.Models.Admin;
using Silas.Models.Courses;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.AddConsole(); // Agrega el log de consola

// Add services to the container.
builder.Services.AddHttpClient<CourseService>();
builder.Services.AddHttpClient<UserService>();
builder.Services.AddHttpClient<CompanyService>();
builder.Services.AddHttpClient<OfferService>();
builder.Services.AddHttpClient<AdminService>();
builder.Services.AddHttpClient<StudentService>();// Registro de OfferService

builder.Services.AddControllersWithViews();

// Configurar la sesi�n
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
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

app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();
