using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Interface
{
    public interface ISolicitudPrestamoRepository
    {
        Task<bool> InsertarSolicitudPrestamo(int idUsuario, List<int> IdsCopiaLibro);
        Task<List<SolicitudPrestamo>> getSolicitudPrestamo();
    }
}
