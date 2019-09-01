```csharp
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
    .Enrich.FromLogContext()
    .Enrich.WithThreadId()
    .Enrich.WithThreadName()
    .Enrich.WithProcessId()
    .Enrich.WithActionName()
    .Enrich.WithProcessName()
    .WriteTo.File("logs/log.log",
        rollingInterval: RollingInterval.Day,
        outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] [{ThreadId}] [{SourceContext}][{ActionName}] {Message:lj}{NewLine}{Exception}")
    .CreateLogger();
```
