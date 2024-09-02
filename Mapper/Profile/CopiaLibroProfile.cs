using Domain.Entity;
using DTO.CopiaLibro;
using DTO.Libro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapper.Profile
{
    public class CopiaLibroProfile : AutoMapper.Profile
    {


        public CopiaLibroProfile()
        {

            all();

        }

        void all()
        {
            CreateMap<CopiaLibro, CopiaLibroListDTO>()
                .ForMember(dest => dest.Titulo, opt => opt.MapFrom(src => src.Libro.Titulo))
                .ForMember(dest => dest.Autor, opt => opt.MapFrom(src => src.Libro.Autor))
                .ForMember(dest => dest.Genero, opt => opt.MapFrom(src => src.Libro.Genero))
                .ForMember(dest => dest.AnioPublicacion, opt => opt.MapFrom(src => src.Libro.AnioPublicacion));
        }
    }
}
