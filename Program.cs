using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using UltraSoundWeb.Repositories.Context;
using UltraSoundWeb.Repositories.Doctor;
using UltraSoundWeb.Repositories.Patient;
using UltraSoundWeb.Repositories.UltraSoundResult;
using UltraSoundWeb.Repositories.UltraSoundSample;
using UltraSoundWeb.Repositories.User;
using UltraSoundWeb.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("AppDbContext")));

builder.Services.AddControllersWithViews();
builder.Services
    .AddAuthentication("UserAuth")
    .AddCookie("UserAuth", options =>
    {
        options.LoginPath = "/member-login";
        options.ExpireTimeSpan = TimeSpan.FromDays(1);
        options.AccessDeniedPath = "/home";
        options.LogoutPath = "/logout";
        options.Cookie.Name = "User";
    });
builder.Services.AddAuthorization();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services
    .AddScoped<IUploadService, UploadService>()
    .AddScoped<IUserRepository, UserRepository>()
    .AddScoped<IDoctorRepository, DoctorRepository>()
    .AddScoped<IPatientRepository, PatientRepository>()
    .AddScoped<IUltraSoundResultRepository, UltraSoundResultRepository>()
    .AddScoped<IUltraSoundSampleRepository, UltraSoundSampleRepository>();

builder.Services.AddSingleton(provider => new MapperConfiguration(cfg =>
{
    cfg.AddMaps(Assembly.GetEntryAssembly());
}).CreateMapper());
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
app.UseAuthentication();
app.UseRouting();

app.UseAuthorization();
app.UseCookiePolicy();
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
using (var scope = app.Services.CreateScope())
{
    using (var appContext = scope.ServiceProvider.GetRequiredService<AppDbContext>())
    {
        try
        {
            appContext.Database.Migrate();
        }
        catch
        {
            throw;
        }
    }
}
app.Run();
