using Microsoft.EntityFrameworkCore;

using TodoApi.Data;
using TodoApi.Extensions;
using TodoApi.Repositories;
using TodoApi.Services;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
// 
builder.Services.AddControllers();


// JWT
builder.Services.AddJwtAuthentication(builder.Configuration);

// Authorization
builder.Services.AddAuthorization();




// Repos
builder.Services.AddScoped<ITodoRepository, TodoRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IPermisoRepository, PermisoRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();

// Permitir OpenAPI/Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Services
builder.Services.AddScoped<ITodoService, TodoService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IPermisoService, PermisoService>();
builder.Services.AddScoped<IRoleService, RoleService>();


var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();
app.MapControllers();  

app.Run();
