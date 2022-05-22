using System.ComponentModel.DataAnnotations;
using AluraAPI.Models;

namespace AluraAPI.Data.Dtos.Cinema
{
    public class ReadCinemaDto
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo de nome é obrigatório")]
        public string Nome { get; set; }
        public Models.Endereco Endereco { get; set; }
    }
}