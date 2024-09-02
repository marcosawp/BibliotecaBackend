using AppService.Interface;
using AutoMapper;
using Domain.Entity;
using DTO.CopiaLibro;
using DTO.Libro;
using DTO.SolicitudPrestamo;
using Infraestructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppService.Service
{
    public class SolicitudPrestamoService : ISolicitudPrestamoService
    {
        private readonly ISolicitudPrestamoRepository _repository;
        private readonly IMapper _mapper;

        public SolicitudPrestamoService(ISolicitudPrestamoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> InsertarSolicitudPrestamo(int idUsuario,List<int> IdsCopiaLibro)
        {
            var result = await _repository.InsertarSolicitudPrestamo(idUsuario, IdsCopiaLibro);
            return result;
        }

        public async Task<List<SolicitudPrestamoListDTO>> getSolicitudPrestamo()
        {
            var result = await _repository.getSolicitudPrestamo();
            return _mapper.Map<List<SolicitudPrestamoListDTO>>(result);
        }
    }
}
