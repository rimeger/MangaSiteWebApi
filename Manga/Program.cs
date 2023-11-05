using Manga;
using Manga.Data;
using Manga.Repositories;
using Manga.Repositories.IRepositories;
using Manga.Services;
using Manga.Services.IServices;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString"));
});
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

builder.Services.AddScoped<IMangaTitleRepository, MangaTitleRepository>();
builder.Services.AddScoped<IMangaChapterRepository, MangaChapterRepository>();
builder.Services.AddScoped<IMangaPageRepository, MangaPageRepository>();

builder.Services.AddScoped<IMangaTitleService, MangaTitleService>();
builder.Services.AddScoped<IMangaChapterService, MangaChapterService>();
builder.Services.AddScoped<IMangaPageService, MangaPageService>();

builder.Services.AddAutoMapper(typeof(MappingConfig));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
