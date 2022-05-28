using AluraAPI.Models;

namespace AluraAPI.Data.Dtos.Sessao
{
    public class ReadSessaoDto
    {
        public int Id { get; set; }
        public Models.Cinema Cinema { get; set; }
        public Filme Filme { get; set; }
    }
}