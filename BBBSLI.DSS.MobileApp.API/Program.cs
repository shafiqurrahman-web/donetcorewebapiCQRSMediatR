using BBBSLI.DSS.MobileApp.API.Controllers;
using BBBSLI.DSS.MobileApp.API.Extensions;
using BBBSLI.DSS.MobileApp.Infrastructure.AppDbContext;
using Carter;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<AppDbContextMobile>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("AppConnectionString")));

builder.Services.AddDbContext<ApplicationReadOnlyDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("AppReadonlyConnectionString"));
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});

builder.Services.DependancyResolver();
builder.Services.RegisterMediatR();

builder.Services.AddHttpContextAccessor();

builder.Services.AddCarter();

builder.Services.AddMiniProfiler(options =>
{
    options.RouteBasePath = "/profiler";
}).AddEntityFramework();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CORSPolicy", builder => builder
        .AllowAnyMethod()
        .AllowAnyHeader()
        // .AllowCredentials()
        .WithExposedHeaders("X-MiniProfiler-Ids"));
});



var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}
app.UseSwagger();
app.UseSwaggerUI();


//app.MapPost("/getDonorData", async (Donors donor) =>
//{
//    if (donor is null)
//        return Results.NotFound("Object is empty");
//    else
//    {
//        //await db data
//        return Results.Ok(donor);
//    }
//});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
//mapping iendpointbuilder
//app.MapCarter();

app.Run();
