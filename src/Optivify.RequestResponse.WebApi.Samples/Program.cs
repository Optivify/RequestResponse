using Optivify.RequestResponse;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

// Add MediatR
services.AddMediatR(x => x.RegisterServicesFromAssembly(typeof(Program).Assembly));

// Add request dispatcher.
services.AddRequestDispatcher();

services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();


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
