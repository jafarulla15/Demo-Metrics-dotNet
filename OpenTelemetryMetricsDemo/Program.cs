
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetryMetricsDemo.Custom_Elements;

var builder = WebApplication.CreateBuilder(args);

// --------------------------------------------------
// OpenTelemetry
// --------------------------------------------------

builder.Services
    .AddOpenTelemetry()
    .ConfigureResource(resource =>
    {
        resource.AddService(
            serviceName: "OpenTelemetryMetricsDemo",
            serviceVersion: "1.0.0");
    })
    .WithMetrics(metrics =>
    {
        // ASP.NET Core metrics
        metrics.AddAspNetCoreInstrumentation();

        // HttpClient metrics
        metrics.AddHttpClientInstrumentation();

        // .NET Runtime metrics
        metrics.AddRuntimeInstrumentation();

        // Process metrics
        metrics.AddProcessInstrumentation();

        // SQL Client metrics
        metrics.AddSqlClientInstrumentation();

        // Custom application metrics
        metrics.AddMeter("OpenTelemetryMetricsDemo");

        // Prometheus exporter
        metrics.AddPrometheusExporter();
    });

// --------------------------------------------------
// Services
// --------------------------------------------------

builder.Services.AddHttpClient();

builder.Services.AddControllers();

var app = builder.Build();


// --------------------------------------------------
// Prometheus metrics endpoint
// --------------------------------------------------

app.MapPrometheusScrapingEndpoint();


// --------------------------------------------------
// API endpoints
// --------------------------------------------------

app.MapGet("/", () =>
{
    return Results.Ok(new
    {
        message = "OpenTelemetry Metrics Demo",
        time = DateTime.UtcNow
    });
});


// --------------------------------------------------
// Custom application metric
// --------------------------------------------------

app.MapGet("/orders", () =>
{
    Metrics.OrdersCreated.Add(1);

    return Results.Ok(new
    {
        orderId = Random.Shared.Next(1000, 9999),
        status = "Created"
    });
});


// --------------------------------------------------
// Error endpoint
// --------------------------------------------------

app.MapGet("/error", () =>
{
    Metrics.OrdersFailed.Add(1);

    throw new Exception("Demo exception");
});


// --------------------------------------------------
// Slow endpoint
// --------------------------------------------------

app.MapGet("/slow", async () =>
{
    await Task.Delay(2000);

    return Results.Ok(new
    {
        message = "Slow response"
    });
});


// --------------------------------------------------
// External HTTP call
// --------------------------------------------------

app.MapGet("/external-call", async (IHttpClientFactory factory) =>
{
    var client = factory.CreateClient();

    var response = await client.GetAsync(
        "https://jsonplaceholder.typicode.com/todos/1");

    return Results.Ok(new
    {
        statusCode = response.StatusCode
    });
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.Run();


