using TMSS.Domain.Interfaces;
using TMSS.Infrastructure.Persistance.Repositories;
using TMSS.Services.Interfaces;
using TMSS.Services.Services;

var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddDbContext<TMSSDbContext>(options => options.UseSqlServer(builder.Configuration["ConnectionStrings:TMSS_Config_ConnectionString"]));


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IProcedureRepository, ProcedureRepository>();
builder.Services.AddScoped<IProcedureService, ProcedureService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
