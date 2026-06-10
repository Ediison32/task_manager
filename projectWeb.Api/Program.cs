using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();


// Swagger
builder.Services.AddSwaggerGen();

//db
builder.Services.AddInfrastructureLayer(builder.Configuration);

//egistramos MediatR
builder.Services.AddMediatR(cfg => 
    cfg.RegisterServicesFromAssembly(typeof(projectWeb.Application.DTOs.TaskDto).Assembly));



// cors para 
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularFrontend", policy =>
    {
        //policy.WithOrigins("http://localhost:4200") // puesto especifico 
        policy.AllowAnyHeader()  
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});


builder.Services.AddOpenApi();


var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    
}
// activacion de cors 
app.UseCors("AllowAngularFrontend");
app.MapControllers();
app.Run();


