using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Models
{
    public class Sessão
    {
        [Key]
        [Required]
        public int Id { get; set; }
    }
}
