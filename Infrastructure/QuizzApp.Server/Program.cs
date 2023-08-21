using FluentValidation;
using QuizzApp.Domain.Models.DTOs;
using QuizzApp.Server;
using QuizzApp.Services.Validations;


string _devCORS = "allowAll";
string _prodCORS = "ReadOnlyProduction";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IValidator<CategoryDTO>, CategoryValidator>();
builder.Services.AddScoped<IValidator<UserToUpsertDTO>, UserValidator>();
builder.Services.AddHealthChecks();
builder.Services.AddCors(options =>
{
    options.AddPolicy(
                    name: _devCORS,
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                                .AllowAnyMethod()
                                .AllowAnyHeader();
                    });
    options.AddPolicy(
                    name: _prodCORS,
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                                .WithMethods("GET")
                                .AllowAnyHeader();
                    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
    app.UseCors(_devCORS);
}
else
{
    app.UseExceptionHandler(appBuilder =>
    {
        appBuilder.Run(async context =>
        {
            context.Response.StatusCode = 500;
            await context.Response.WriteAsync("Something went wrong.");
        });
    });
    app.UseCors(_prodCORS);
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapHealthChecks("/health");
});
app.MapControllers();

app.Run();
