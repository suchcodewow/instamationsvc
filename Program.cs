using Microsoft.AspNetCore.HttpLogging;
// using Serilog;
// using Serilog.Events;
using Microsoft.Extensions.Logging.AzureAppServices;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.AddAzureWebAppDiagnostics();
builder.Services.Configure<AzureFileLoggerOptions>(options =>
{
    options.FileName = "azure-diagnostics-";
    options.FileSizeLimit = 50 * 1024;
    options.RetainedFileCountLimit = 5;
});


// builder.Host.UseSerilog();

// Add app services
builder.Services.AddCors();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// builder.Services.AddHttpLogging(logging =>
// {
//     // logging.LoggingFields = HttpLoggingFields.All
//     logging.RequestHeaders.Add("sec-ch-ua");
//     logging.RequestBodyLogLimit = 4096;
//     logging.ResponseBodyLogLimit = 4096;
// });

// Add Logging & Configuration
// string GetEnvironmentVariable(string name, string defaultValue)
//     => Environment.GetEnvironmentVariable(name) ?? defaultValue;
// Log.Logger = new LoggerConfiguration()
//     .MinimumLevel.Debug()
//     .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
//     .Enrich.FromLogContext()
//     .WriteTo.Console()
//     .WriteTo.File(
//        System.IO.Path.Combine(GetEnvironmentVariable("HOME", ""), "LogFiles", "Application", "diagnostics.txt"),
//        rollingInterval: RollingInterval.Day,
//        fileSizeLimitBytes: 10 * 1024 * 1024,
//        retainedFileCountLimit: 2,
//        rollOnFileSizeLimit: true,
//        shared: true,
//        flushToDiskInterval: TimeSpan.FromSeconds(1))
//     .CreateLogger();
// Log.Information("Starting");

// Add app options
var app = builder.Build();
// app.UseSerilogRequestLogging();
// Setup CORS
app.UseCors((builder =>
{
    builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
}));
// app.UseHttpLogging();
app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();
// app.Urls.Add("http://*:5130");
app.Run();