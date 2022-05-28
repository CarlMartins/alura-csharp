using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AluraAPI.Models
{
    public class Filme
    {
        [Key]
        [Required]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Título é obrigatório!")]
        public string Titulo { get; set; }
        
        [Required(ErrorMessage = "Diretor é obrigatório!")]
        public string Diretor { get; set; }
        public string Genero { get; set; }
        
        [Range(1, 600, ErrorMessage = "A duração deve ter no mínimo 1 e no máximo 600")]
        public int Duracao { get; set; }

        public int ClassificacaoEtaria { get; set; }

        [JsonIgnore]
        public virtual List<Sessao> Sessoes { get; set; }
    }
}