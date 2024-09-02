using Domain.Entity;
using DTO.Libro;
using Infraestructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppService.Interface
{
    public interface ILibroService
    {
        Task<List<LibroDTO>> getLibros();
    }
}
