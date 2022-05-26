using System.Collections.Generic;

namespace AluraAPI.Data.Dtos.Gerente
{
    public class ReadGerenteDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public virtual object Cinemas { get; set; }
    }
}