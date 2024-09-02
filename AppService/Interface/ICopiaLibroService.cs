using Domain.Entity;
using DTO.CopiaLibro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppService.Interface
{
    public interface ICopiaLibroService 
    {
        Task<List<CopiaLibroListDTO>> getCopiaLibros();
    }
}
