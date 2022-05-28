using System.Collections.Generic;
using System.Linq;
using AluraAPI.Data;
using AluraAPI.Data.Dtos.Cinema;
using AluraAPI.Models;
using AutoMapper;

namespace AluraAPI.Services
{
    public class CinemaService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public CinemaService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadCinemaDto AdicionaCinema(CreateCinemaDto cinemaDto)
        {
            Cinema cinema = _mapper.Map<Cinema>(cinemaDto);
            _context.Cinemas.Add(cinema);
            _context.SaveChanges();

            return _mapper.Map<ReadCinemaDto>(cinema);
        }

        public List<ReadCinemaDto> RecuperaCinemas(string nomeDoFilme)
        {
            List<Cinema> cinemas = _context.Cinemas.ToList();

            if (cinemas.Count == 0) return null;

            if (!string.IsNullOrEmpty(nomeDoFilme))
            {
                IEnumerable<Cinema> query = from cinema in cinemas
                    where cinema.Sessoes
                        .Any(sessao => sessao.Filme.Titulo == nomeDoFilme)
                    select cinema;

                cinemas = query.ToList();
            }

            return _mapper.Map<List<ReadCinemaDto>>(cinemas);
        }

        public ReadCinemaDto RecuperaCinemasPorId(int id)
        {
            Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
            if (cinema != null) return _mapper.Map<ReadCinemaDto>(cinema);

            return null;
        }

        public UpdateCinemaDto AtualizaCinema(int id, UpdateCinemaDto cinemaDto)
        {
            Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
            if(cinema != null)
            {
                _mapper.Map(cinemaDto, cinema);
                _context.SaveChanges();

                return cinemaDto;
            }

            return null;
        }

        public Cinema DeletaCinema(int id)
        {
            Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
            if (cinema != null)
            {
                _context.Remove(cinema);
                _context.SaveChanges();
                return cinema;
            }

            return null;
        }
    }
}