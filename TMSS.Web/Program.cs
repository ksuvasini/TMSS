using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TMSS.DataAccess.DataContext;
using TMSS.Domain.Entities;
using TMSS.Domain.Interfaces;
using TMSS.Infrastructure.Persistance.Repositories;
using TMSS.Services.Interfaces;
using TMSS.Services.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//add DB context

builder.Services.AddDbContext<TMSSDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("TMSS_Global_ConnectionString"));

    if (Debugger.IsAttached)
        options.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()));

}, ServiceLifetime.Transient);

builder.Services.AddControllersWithViews();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IProcedureRepository, ProcedureRepository>();
builder.Services.AddScoped<IProcedureService, ProcedureService>();
builder.Services.AddScoped<ILoginRepository, LoginRepository>();
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<IManageUserRepository, ManageUserRepository>();
builder.Services.AddScoped<IManageUserService, ManageUserService>();
builder.Services.AddScoped<IClinicRepository, ClinicRepository>();
builder.Services.AddScoped<IClinicService, ClinicService>();
builder.Services.AddScoped<IComplicationRepository, ComplicationRepository>();
builder.Services.AddScoped<IComplicationService, ComplicationService>();
builder.Services.AddScoped<ISurgeonRepository, SurgeonRepository>();
builder.Services.AddScoped<ISurgeonService, SurgeonService>(); 


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Login/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

//app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();
