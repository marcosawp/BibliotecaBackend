using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.SolicitudPrestamo
{
    public class SolicitudPrestamoListDTO
    {
        public int ID_SolicitudPrestamo { get; set; }
        public int ID_Usuario { get; set; }
        public string Estado { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
    }
}
