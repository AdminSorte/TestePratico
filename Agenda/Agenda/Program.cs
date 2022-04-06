using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Agenda.Areas.Identity.Data;
using Agenda.Infrastructure.Context;
using Agenda.Infrastructure.Interfaces;
using Agenda.Infrastructure.Repository;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("ApplicationDbContextConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDbContext<AgendaDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddTransient<IAgendaRepository, AgendaRepository>();

builder.Services.AddDefaultIdentity<AgendaUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Agenda}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
