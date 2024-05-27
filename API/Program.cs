using CalculoCDB.Application.Interfaces;
using CalculoCDB.Application.Servicos;
using CalculoCDB.Domain.Interfaces;
using CalculoCDB.Domain.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICalculoCdbAppService, CalculoCdbAppService>();
builder.Services.AddScoped<ICalculoCdbService, CalculoCdbService>();

builder.Services.AddCors(options => {
    options.AddPolicy("Development",
        builder => builder
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials()
        .SetIsOriginAllowed(hostName => true));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseCors("Development");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
