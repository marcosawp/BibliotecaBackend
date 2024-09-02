using Domain.Entity;
using DTO.Libro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapper.Profile
{
    public class LibroProfile : AutoMapper.Profile
    {


        public LibroProfile() {

            all();
        
        }

        void all()
        {
            CreateMap<Libro, LibroDTO>();
        }
    }
}
