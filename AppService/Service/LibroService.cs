using AppService.Interface;
using AutoMapper;
using Domain.Entity;
using DTO.Libro;
using Infraestructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppService.Service
{
    public class LibroService : ILibroService
    {
        private readonly ILibroRepository _repository;
        private readonly IMapper _mapper;

        public LibroService(ILibroRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<LibroDTO>> getLibros()
        {
            var result = await _repository.getLibros();
            return _mapper.Map<List<LibroDTO>>(result);
        }
    }
}
