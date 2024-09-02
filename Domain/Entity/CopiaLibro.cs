using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class CopiaLibro
    {
        public int ID_Copia { get; set; }
        public int ID_Libro { get; set; }
        public Libro Libro { get; set; }
        public string CodigoBarras { get; set; }
        public string Estado { get; set; }
    }
}
