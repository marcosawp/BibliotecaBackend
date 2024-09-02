using DTO.SolicitudPrestamo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppService.Interface
{
    public interface ISolicitudPrestamoService
    {
        Task<bool> InsertarSolicitudPrestamo(int idUsuario, List<int> IdsCopiaLibro);
        Task<List<SolicitudPrestamoListDTO>> getSolicitudPrestamo();
    }
}
