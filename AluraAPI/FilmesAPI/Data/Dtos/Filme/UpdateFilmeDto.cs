using System.ComponentModel.DataAnnotations;

namespace AluraAPI.Data.Dtos
{
    public class UpdateFilmeDto
    {
        [Required(ErrorMessage = "Título é obrigatório!")]
        public string Titulo { get; set; }
        
        [Required(ErrorMessage = "Diretor é obrigatório!")]
        public string Diretor { get; set; }
        public string Genero { get; set; }
        
        [Range(1, 600, ErrorMessage = "A duração deve ter no mínimo 1 e no máximo 600")]
        public int Duracao { get; set; }
    }
}