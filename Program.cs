using AwesomeLibrary.Services;
using FastEndpoints;

var bld = WebApplication.CreateBuilder();

bld.Services.AddSingleton<IPersonRepository, PersonRepository>();

bld.Services.AddFastEndpoints();
bld.Services.AddMemoryCache();

var app = bld.Build();
app.UseFastEndpoints();
app.Run();