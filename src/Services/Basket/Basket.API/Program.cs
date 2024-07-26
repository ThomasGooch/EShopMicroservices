var builder = WebApplication.CreateBuilder(args);

// register services

var app = builder.Build();

// configure http pipeline

app.Run();
