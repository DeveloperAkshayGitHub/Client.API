using Client.API.Filters;
using Client.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<IClientService, ClientService>();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

var app = builder.Build();

// Configure the HTTP request pipeline.

//app.UseMiddleware<GlobalExceptionMiddleware>(new GlobalExceptionMiddleware());
app.UseExceptionHandler();
app.UseAuthorization();
app.UseSwagger();
app.UseSwaggerUI(c => {
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Client API");
});

app.MapControllers();

app.Run();
