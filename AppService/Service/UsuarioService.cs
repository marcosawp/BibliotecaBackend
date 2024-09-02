using AppService.Interface;
using AutoMapper;
using Domain.Entity;
using DTO.Libro;
using DTO.Usuario;
using Infraestructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppService.Service
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _repository;
        private readonly IMapper _mapper;

        public UsuarioService(IUsuarioRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<UsuarioDTO>> getUsuarios()
        {
            var result = await _repository.getUsuarios();
            return _mapper.Map<List<UsuarioDTO>>(result);
        }
    }
}
