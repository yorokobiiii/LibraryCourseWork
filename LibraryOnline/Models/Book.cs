using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LibraryOnline.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Название обязательно")]
        [StringLength(200)]
        public string Title { get; set; } = "";

        [Required(ErrorMessage = "Автор обязателен")]
        [StringLength(100)]
        public string Author { get; set; } = "";

        [StringLength(50)]
        public string Genre { get; set; } = "";

        [Range(1000, 2025)]
        public int Year { get; set; }

        // Это поле не сохраняется в БД 
        [JsonIgnore]
        public string ShortInfo => $"{Title} - {Author} ({Year})";
    }
}