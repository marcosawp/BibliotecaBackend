using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class SolicitudPrestamo
    {
        public int ID_SolicitudPrestamo;
        public Usuario Usuario { get; set; }

        public int ID_Usuario;
        public String Estado { get; set; }
    }
}
