using Domain.Entity;
using Infraestructure.Data;
using Infraestructure.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly string conexionSQL;

        public UsuarioRepository(ConnectionService connectionService)
        {
            conexionSQL = connectionService.getConnection();
        }
        public async Task<List<Usuario>> getUsuarios()
        {
            List<Usuario> lista = new List<Usuario>();
            using (var conexion = new SqlConnection(conexionSQL))
            {
                await conexion.OpenAsync();
                SqlCommand cmd = new SqlCommand("sp_listarUsuarios", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        lista.Add(new Usuario
                        {
                            ID_Usuario = Convert.ToInt32(reader["ID_Usuario"]),
                            Nombres = reader["Nombres"].ToString(),
                            Apellidos = reader["Apellidos"].ToString(),
                            NumDocumento = reader["NumDocumento"].ToString(),
                            Telefono = reader["Telefono"].ToString(),
                            Email = reader["Email"].ToString(),
                            Direccion = reader["Direccion"].ToString(),
                            Ubigeo = reader["Ubigeo"].ToString()
                        });
                    }
                }
            }

            return lista;
        }
    }
}
