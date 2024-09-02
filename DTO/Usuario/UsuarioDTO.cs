using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Usuario
{
    public class UsuarioDTO
    {
        public int ID_Usuario { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string NumDocumento { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
        public string Ubigeo { get; set; }
    }
}
