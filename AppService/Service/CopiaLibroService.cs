using AppService.Interface;
using AutoMapper;
using DTO.CopiaLibro;
using Infraestructure.Interface;
using Infraestructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppService.Service
{
    public class CopiaLibroService : ICopiaLibroService
    {
        private readonly ICopiaLibroRepository _repository;
        private readonly IMapper _mapper;

        public CopiaLibroService(ICopiaLibroRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<CopiaLibroListDTO>> getCopiaLibros()
        {
            var result = await _repository.getCopiaLibro();
            return _mapper.Map<List<CopiaLibroListDTO>>(result);
        }
    }
}
