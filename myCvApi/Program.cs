using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using myCvApi.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("LinguagemConnection");
builder.Services.AddDbContext<LinguagemContext>(opts => 
    opts.UseLazyLoadingProxies().UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// builder.Services.AddSwaggerGen(c =>
// {
//     c.SwaggerDoc("v1", new OpenApiInfo { Title = "myCvApi", Version = "v1" });
//     var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
//     var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
//     c.IncludeXmlComments(xmlPath);
// });
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
    });
}

app.UseCors(c => {
    c.AllowAnyHeader();
    c.AllowAnyMethod();
    c.AllowAnyOrigin();
}); 

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
