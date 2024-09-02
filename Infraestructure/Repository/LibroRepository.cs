using Domain.Entity;
using Infraestructure.Data;
using Infraestructure.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public class LibroRepository : ILibroRepository
    {
        private readonly string conexionSQL;

        public LibroRepository(ConnectionService connectionService)
        {
            conexionSQL = connectionService.getConnection();
        }

        public async Task<List<Libro>> getLibros()
        {
            List<Libro> lista = new List<Libro>();
            using (var conexion = new SqlConnection(conexionSQL))
            {
                await conexion.OpenAsync();
                SqlCommand cmd = new SqlCommand("sp_listaLibro", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        lista.Add(new Libro
                        {
                            ID_Libro = Convert.ToInt32(reader["ID_Libro"]),
                            Titulo = reader["Titulo"].ToString(),
                            Autor = reader["Autor"].ToString(),
                            Genero = reader["Genero"].ToString(),
                            AnioPublicacion = Convert.ToInt32(reader["AnioPublicacion"])
                        });
                    }
                }
            }

            return lista;
        }

    }
}
