using BTL_ConGa.Areas.Admin.Repository;
using BTL_ConGa.Models;
using BTL_ConGa.Repository;
using BTL_ConGa.Service;
using BTL_ConGa.Service.GioHang;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("BtlWebContext");
builder.Services.AddDbContext<BtlWebContext>(x => x.UseSqlServer(connectionString));
builder.Services.AddScoped<IDanhMucSPRepository, DanhMucSPRepository>();
builder.Services.AddScoped<IUserInforService, UserInforService>();
builder.Services.AddScoped<IMonAnService, MonAnService>();
builder.Services.AddScoped<IDanhMucMonAnRepository, DanhMucMonAnRepository>();
builder.Services.AddScoped<IGioHangService, GioHangService>();
builder.Services.AddSession();

builder.Services.AddHttpContextAccessor();

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

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=TrangChu}/{action=TrangChu}/{id?}");
app.UseStatusCodePagesWithRedirects("/NotFound/{0}");
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "notfound",
        pattern: "/NotFound/{statusCode}",
        defaults: new { controller = "TrangChu", action = "Error404" });

    // C�c routing kh�c
    // ...
});
app.Run();


