using System.ComponentModel.DataAnnotations;

namespace LibraryOnline.Models
{
    public class Reader
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; } = "";

        [Required]
        [StringLength(50)]
        public string LastName { get; set; } = "";

        [EmailAddress]
        public string Email { get; set; } = "";

        [Phone]
        public string Phone { get; set; } = "";

        public DateTime RegistrationDate { get; set; } = DateTime.Now;

        public bool IsPremium { get; set; } = false;

        public string FullName => $"{LastName} {FirstName}";
    }
}