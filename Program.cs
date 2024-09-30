using AwesomeLibrary.Services;
using FastEndpoints;

var bld = WebApplication.CreateBuilder();

bld.Services.AddScoped<IPersonRepository, PersonRepository>();

bld.Services.AddFastEndpoints();

var app = bld.Build();
app.UseFastEndpoints();
app.Run();