using LibraryOnline.Data;
using LibraryOnline.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Добавляем сервисы Razor Pages и Blazor
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// === ПОДКЛЮЧЕНИЕ БАЗЫ ДАННЫХ (как в ПР №2 и №3) ===
builder.Services.AddDbContext<LibraryContext>(options =>
    options.UseSqlite("Data Source=library.db"));

// === РЕГИСТРАЦИЯ НАШЕГО СЕРВИСА (как в ПР №3) ===
builder.Services.AddScoped<IBookService, BookService>();

var app = builder.Build();

// Настройка конвейера обработки запросов
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

// === API ЭНДПОИНТЫ (как в ПР №3) ===
app.MapGet("/api/books", async (LibraryContext db) =>
{
    return await db.Books.ToListAsync();
});

app.MapGet("/api/readers", async (LibraryContext db) =>
{
    return await db.Readers.ToListAsync();
});

app.MapGet("/api/config", (IConfiguration config) =>
{
    return new
    {
        AppName = config["AppName"] ?? "LibraryOnline",
        Version = config["Version"] ?? "1.0.0",
        Environment = app.Environment.EnvironmentName
    };
});

app.Run();