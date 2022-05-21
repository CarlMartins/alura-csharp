using System.ComponentModel.DataAnnotations;

namespace AluraAPI.Data.Dtos.Endereco
{
    public class UpdateEnderecoDto
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public string Logradouro { get; set; }

        public string Bairro { get; set; }

        public int Numero { get; set; }
    }
}