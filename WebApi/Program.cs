using Application;
using Infrastructure;
using Presentation;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Scan(
    selector => selector
        .FromAssemblies(
            Infrastructure.AssemblyReference.Assembly)
        .AddClasses(false)
        .AsImplementedInterfaces()
        .WithScopedLifetime());

builder.Services.AddOpenApi();

builder.Services.AddMediatR(
    cfg => cfg
        .RegisterServicesFromAssembly(Application.AssemblyReference.Assembly));

builder.Services
    .AddApplication()
    .AddInfrastructure()
    .AddPresentation();

builder.Services
    .AddControllers()
    .AddApplicationPart(Presentation.AssemblyReference.Assembly);

builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.Run();