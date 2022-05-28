using System;
using AluraAPI.Models;

namespace AluraAPI.Data.Dtos.Sessao
{
    public class ReadSessaoDto
    {
        public int Id { get; set; }
        public Models.Cinema Cinema { get; set; }
        public Filme Filme { get; set; }
        public DateTime HorarioDeEncerramento { get; set; }
        public DateTime HorarioDeInicio { get; set; }
    }
}