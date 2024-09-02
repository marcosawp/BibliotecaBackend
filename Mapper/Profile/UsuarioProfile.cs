using Domain.Entity;
using DTO.Libro;
using DTO.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapper.Profile
{
    public class UsuarioProfile : AutoMapper.Profile
    {


        public UsuarioProfile() {

            all();
        
        }

        void all()
        {
            CreateMap<Usuario, UsuarioDTO>();
        }
    }
}
