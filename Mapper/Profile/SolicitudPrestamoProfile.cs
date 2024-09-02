using Domain.Entity;
using DTO.CopiaLibro;
using DTO.Libro;
using DTO.SolicitudPrestamo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapper.Profile
{
    public class SolicitudPrestamoProfile : AutoMapper.Profile
    {


        public SolicitudPrestamoProfile()
        {

            all();

        }

        void all()
        {
            CreateMap<SolicitudPrestamo, SolicitudPrestamoListDTO>()
                .ForMember(dest => dest.Nombres, opt => opt.MapFrom(src => src.Usuario.Nombres))
                .ForMember(dest => dest.Apellidos, opt => opt.MapFrom(src => src.Usuario.Apellidos));
        }
    }
}
