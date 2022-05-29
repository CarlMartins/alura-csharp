using System.ComponentModel.DataAnnotations;

namespace UsuariosAPI.Data.Requests
{
    public class AtivaContaRequest
    {
        [Required] public string CodigoAtivacao { get; set; }
        
        [Required] public int UsuarioId { get; set; }
    }
}