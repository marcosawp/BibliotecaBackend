using Infraestructure.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infraestructure.Interface;
using Domain.Entity;

namespace Infraestructure.Repository
{
    public class SolicitudPrestamoRepository : ISolicitudPrestamoRepository
    {
        private readonly string conexionSQL;

        public SolicitudPrestamoRepository(ConnectionService connectionService)
        {
            conexionSQL = connectionService.getConnection();
        }

        public async Task<bool> InsertarSolicitudPrestamo(int idUsuario, List<int> IdsCopiaLibro)
        {
            int idSolicitudPrestamo = 0;
            using (var conexion = new SqlConnection(conexionSQL))
            {
                await conexion.OpenAsync();

                
                SqlTransaction transaction = conexion.BeginTransaction();

                try
                {
 
                    SqlCommand cmdInsertarSolicitud = new SqlCommand("sp_InsertarSolicitudPrestamo", conexion, transaction);
                    cmdInsertarSolicitud.CommandType = CommandType.StoredProcedure;
                    cmdInsertarSolicitud.Parameters.AddWithValue("@ID_Usuario", idUsuario);
                    var outputParameter = new SqlParameter("@ID_SolicitudPrestamo", SqlDbType.Int);
                    outputParameter.Direction = ParameterDirection.Output;
                    cmdInsertarSolicitud.Parameters.Add(outputParameter);
                    await cmdInsertarSolicitud.ExecuteNonQueryAsync();
                    idSolicitudPrestamo = Convert.ToInt32(outputParameter.Value);

   
                    foreach (int idCopiaLibro in IdsCopiaLibro)
                    {
                        SqlCommand cmdInsertarCopia = new SqlCommand("sp_InsertarSolicitudLibros", conexion, transaction);
                        cmdInsertarCopia.CommandType = CommandType.StoredProcedure;
                        cmdInsertarCopia.Parameters.AddWithValue("@ID_SolicitudPrestamo", idSolicitudPrestamo);
                        cmdInsertarCopia.Parameters.AddWithValue("@ID_Copia", idCopiaLibro);
                        await cmdInsertarCopia.ExecuteNonQueryAsync();
                    }

                    transaction.Commit();
                }
                catch (Exception ex)
                {
   
                    transaction.Rollback();
            
                    throw ex;
                }
            }

            return true;
        }


        public async Task<List<SolicitudPrestamo>> getSolicitudPrestamo()
        {
            List<SolicitudPrestamo> lista = new List<SolicitudPrestamo>();
            using (var conexion = new SqlConnection(conexionSQL))
            {
                await conexion.OpenAsync();
                SqlCommand cmd = new SqlCommand("sp_listarSolicitudPrestamo", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        lista.Add(new SolicitudPrestamo
                        {
                            ID_SolicitudPrestamo = Convert.ToInt32(reader["ID_SolicitudPrestamo"]),
                            ID_Usuario = Convert.ToInt32(reader["ID_Usuario"]),
                            Estado = (reader["Estado"]).ToString(),
                            Usuario = new Usuario
                            {
                                ID_Usuario = Convert.ToInt32(reader["ID_Usuario"]),
                                Nombres = reader["Nombres"].ToString(),
                                Apellidos = reader["Apellidos"].ToString()
                            }

                        });
                    }
                }
            }

            return lista;
        }
    }
}
