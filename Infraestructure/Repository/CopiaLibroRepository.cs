using Domain.Entity;
using Infraestructure.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infraestructure.Interface;

namespace Infraestructure.Repository
{
    public class CopiaLibroRepository : ICopiaLibroRepository
    {
        private readonly string conexionSQL;

        public CopiaLibroRepository(ConnectionService connectionService)
        {
            conexionSQL = connectionService.getConnection();
        }

        public async Task<List<CopiaLibro>> getCopiaLibro()
        {
            List<CopiaLibro> lista = new List<CopiaLibro>();
            using (var conexion = new SqlConnection(conexionSQL))
            {
                await conexion.OpenAsync();
                SqlCommand cmd = new SqlCommand("sp_listaCopiaLibro", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        lista.Add(new CopiaLibro
                        {
                            ID_Copia = Convert.ToInt32(reader["ID_Copia"]),
                            CodigoBarras = (reader["CodigoBarras"]).ToString(),
                            ID_Libro = Convert.ToInt32(reader["ID_Libro"]),
                            Estado = (reader["Estado"]).ToString(),
                            Libro = new Libro
                            {
                                ID_Libro = Convert.ToInt32(reader["ID_Libro"]),
                                Titulo = reader["Titulo"].ToString(),
                                Autor = reader["Autor"].ToString(),
                                Genero = reader["Genero"].ToString(),
                                AnioPublicacion = Convert.ToInt32(reader["AnioPublicacion"])
                            }
                           
                        });
                    }
                }
            }

            return lista;
        }

    }
}

