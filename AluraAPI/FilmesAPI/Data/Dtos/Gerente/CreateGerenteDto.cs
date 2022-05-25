using System.Collections.Generic;

namespace AluraAPI.Data.Dtos.Gerente
{
    public class CreateGerenteDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<Models.Cinema> Cinemas { get; set; }
    }
}