using BackendServices.Features.Account;
using BackendServices.Features.User;

var builder = WebApplication.CreateBuilder(args);

#region Connection with blazorApp
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
    policy => {
        policy.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});
#endregion

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"));
},ServiceLifetime.Transient, ServiceLifetime.Transient);

#region Add Services
builder.Services.AddScoped<AccountService>();
builder.Services.AddScoped<UserService>();
#endregion
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("AllowAll");
app.MapControllers();

app.Run();
