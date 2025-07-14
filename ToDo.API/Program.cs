using ToDo.API;

var builder = WebApplication.CreateBuilder(args);

var startUp = new StartUp(builder.Configuration, builder.Environment);

startUp.ConfigureServices(builder.Services);

var app = builder.Build();

startUp.Configure(app, builder.Environment);