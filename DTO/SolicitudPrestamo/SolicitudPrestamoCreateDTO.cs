using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.SolicitudPrestamo
{
    public class SolicitudPrestamoCreateDTO
    {
        public int IdUsuario { get; set; }
        public List<int> IdCopiaLibro { get; set; }
    }
}
