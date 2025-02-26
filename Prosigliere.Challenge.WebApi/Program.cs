using Microsoft.EntityFrameworkCore;
using Prosigliere.Challenge.Domain.Posts.CreatePost;
using Prosigliere.Challenge.IoC;
using Prosigliere.Challenge.ORM;
using Prosigliere.Challenge.WebApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssemblies(typeof(CreatePostHandler).Assembly);
});

builder.Services.AddAutoMapper(typeof(Program).Assembly, typeof(CreatePostHandler).Assembly);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("Database"),
        b => b.MigrationsAssembly("Prosigliere.Challenge.ORM")
    )
);

Initializer.Initialize(builder);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
