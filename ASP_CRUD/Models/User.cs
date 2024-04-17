using System.ComponentModel.DataAnnotations;

namespace ASP_CRUD.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        
        [Required]
        [MinLength(10)]

        public string? Phone { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
