using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SaneForce.Services.ProductAPI;
using SaneForce.Services.ProductAPI.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

IMapper mapper= MappingConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddCors(options => { options.AddPolicy("AllowAllOrigins", builder => { builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); }); });

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseCors("AllowAllOrigins");

app.UseHttpsRedirection();


app.UseAuthorization();

app.MapControllers();

ApplyMigration();

app.Run();

void ApplyMigration()
{
    using (var scope=app.Services.CreateScope())
    {
        var _db=scope.ServiceProvider.GetRequiredService<AppDbContext>();
        if(_db.Database.GetPendingMigrations().Count() > 0)
        {
            _db.Database.Migrate();
        }
    }
}
