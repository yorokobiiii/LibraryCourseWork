using Microsoft.EntityFrameworkCore;
using LibraryOnline.Models;

namespace LibraryOnline.Data
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) 
            : base(options)
        {
            // Создаём БД, если её нет
            Database.EnsureCreated();
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Reader> Readers { get; set; }

        // Заполняем тестовыми данными (как в твоей ПР №3)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Добавляем тестовые книги
            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, Title = "Война и мир", Author = "Лев Толстой", Genre = "Роман", Year = 1869 },
                new Book { Id = 2, Title = "Преступление и наказание", Author = "Фёдор Достоевский", Genre = "Роман", Year = 1866 },
                new Book { Id = 3, Title = "Мастер и Маргарита", Author = "Михаил Булгаков", Genre = "Роман", Year = 1967 },
                new Book { Id = 4, Title = "Евгений Онегин", Author = "Александр Пушкин", Genre = "Поэма", Year = 1833 }
            );

            // Добавляем тестовых читателей
            modelBuilder.Entity<Reader>().HasData(
                new Reader { Id = 1, FirstName = "Иван", LastName = "Петров", Email = "ivan@mail.ru", Phone = "+79991234567", RegistrationDate = DateTime.Now.AddDays(-30), IsPremium = true },
                new Reader { Id = 2, FirstName = "Мария", LastName = "Сидорова", Email = "maria@mail.ru", Phone = "+79997654321", RegistrationDate = DateTime.Now.AddDays(-15), IsPremium = false },
                new Reader { Id = 3, FirstName = "Алексей", LastName = "Иванов", Email = "alex@mail.ru", Phone = "+79998887777", RegistrationDate = DateTime.Now.AddDays(-5), IsPremium = true }
            );
        }
    }
}