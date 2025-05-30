using System;
using System.Collections.Generic;
using CafeteriaV2.Models.Entities;
using Microsoft.Data.Sqlite;

namespace CafeteriaV2.Data
{
    public static class UsuarioRepository
    {
        public static void AgregarUsuario(Usuario usuario)
        {
            using (var conn = new SqliteConnection(BaseDatos.ConnectionString))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = @"
                    INSERT INTO Usuarios (NombreUsuario, ContrasenaHash, Rol, Estado, FechaAlta)
                    VALUES (@nombre, @hash, @rol, @estado, @fecha);
                ";
                cmd.Parameters.AddWithValue("@nombre", usuario.NombreUsuario);
                cmd.Parameters.AddWithValue("@hash", usuario.ContrasenaHash);
                cmd.Parameters.AddWithValue("@rol", usuario.Rol);
                cmd.Parameters.AddWithValue("@estado", usuario.Estado);
                cmd.Parameters.AddWithValue("@fecha", usuario.FechaAlta.ToString("yyyy-MM-dd HH:mm:ss"));
                cmd.ExecuteNonQuery();
            }
        }

        public static Usuario ObtenerUsuarioPorNombre(string nombreUsuario)
        {
            using (var conn = new SqliteConnection(BaseDatos.ConnectionString))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = @"
                    SELECT * FROM Usuarios WHERE NombreUsuario = @nombre;
                ";
                cmd.Parameters.AddWithValue("@nombre", nombreUsuario);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Usuario
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            NombreUsuario = reader["NombreUsuario"].ToString(),
                            ContrasenaHash = reader["ContrasenaHash"].ToString(),
                            Rol = reader["Rol"].ToString(),
                            Estado = reader["Estado"].ToString(),
                            FechaAlta = DateTime.Parse(reader["FechaAlta"].ToString())
                        };
                    }
                }
            }
            return null;
        }

        public static List<Usuario> ObtenerTodos()
        {
            var usuarios = new List<Usuario>();

            using (var conn = new SqliteConnection(BaseDatos.ConnectionString))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM Usuarios;";

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        usuarios.Add(new Usuario
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            NombreUsuario = reader["NombreUsuario"].ToString(),
                            ContrasenaHash = reader["ContrasenaHash"].ToString(),
                            Rol = reader["Rol"].ToString(),
                            Estado = reader["Estado"].ToString(),
                            FechaAlta = DateTime.Parse(reader["FechaAlta"].ToString())
                        });
                    }
                }
            }

            return usuarios;
        }

        public static int CantidadUsuarios()
        {
            using (var conn = new SqliteConnection(BaseDatos.ConnectionString))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT COUNT(*) FROM Usuarios;";

                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public static int CantidadUsuariosAdmin()
        {
            using (var conn = new SqliteConnection(BaseDatos.ConnectionString))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT COUNT(*) FROM Usuarios WHERE Rol = 'Admin';";

                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

    }
}
