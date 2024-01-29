using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ProjektniZadatakTiac.AutoMapper;
using ProjektniZadatakTiac.DataAcess;
using ProjektniZadatakTiac.DataAcess.Tasks;
using ProjektniZadatakTiac.DataAcess.Tasks.Interfaces;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(setup =>
{
    setup.ReturnHttpNotAcceptable = true;//kada neko vratine odgovarajuc format vraca status 406
}).AddXmlDataContractSerializerFormatters();

//builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DatabaseContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
    .LogTo(Console.WriteLine, LogLevel.Information);
});

builder.Services.AddAutoMapper(typeof(MappingProfiles));
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IPostRepository, PostRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
