using cairo_library.data;
using cairo_library.Iinterface;
using cairo_library.Iinterfaces;
using cairo_library.services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionstring = builder.Configuration.GetConnectionString("defaultconnection");
builder.Services.AddDbContext<myappdpcontext>(options=>options.UseSqlServer(connectionstring));

builder.Services.AddScoped<Icheckout, checkout>();
builder.Services.AddScoped<Imember, memberservices>();
builder.Services.AddScoped <Ilibrarian,librarianservices>();
builder.Services.AddScoped <Ipenality, penalityservices>();
builder.Services.AddScoped<Ibook,bookservices>();

// Add services to the container.
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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
