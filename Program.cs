using MiniCommerce.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Logging
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

// Services
builder.Services.AddSingleton<IProductService, InMemoryProductService>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHealthChecks();

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        });
});

var app = builder.Build();

// Middleware
app.UseExceptionHandler("/error");
app.Map("/error", () => Results.Problem("Unexpected error occurred"));

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseAuthorization();

app.MapControllers();
app.MapHealthChecks("/health");

app.MapGet("/", () => Results.Ok(new { status = "ok", message = "MiniCommerce API Running 🚀" }));

app.Run();
