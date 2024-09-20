var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapPrinterEndpoints();
app.MapTonnerEndpoints();

app.Run();
