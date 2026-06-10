using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();


// Swagger
builder.Services.AddSwaggerGen();

//db
builder.Services.AddInfrastructureLayer(builder.Configuration);

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



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    
}

app.MapControllers();
app.Run();


