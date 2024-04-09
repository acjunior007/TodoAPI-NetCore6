using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;
using TodoListAPI.Application.Services;
using TodoListAPI.Config;
using TodoListAPI.Domain.Interface;
using TodoListAPI.Infra.Context;
using TodoListAPI.Infra.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// JSON Serializer
builder.Services.AddControllers().AddNewtonsoftJson(options =>
	options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
).AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());

builder.Services.AddDbContext<DBTodoAPPContext>(options =>
	options.UseSqlServer(
		builder.Configuration.GetConnectionString("conn")
		));

builder.Services.AddTransient<INoteRepository, NoteRepository>();
builder.Services.AddTransient<INoteService, NoteService>();

IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);

var app = builder.Build();

// Enable CORS
app.UseCors(c => c.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
