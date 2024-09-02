using Domain.Entity;
using DTO.Libro;
using DTO.Usuario;
using Infraestructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppService.Interface
{
    public interface IUsuarioService
    {
        Task<List<UsuarioDTO>> getUsuarios();
    }
}
