using _1_Wed_API.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;


namespace _1_Wed_API.Data
{
    public class UsuarioData
    {

        // METODO OBTENER TODOS: llama al Procedimiento de Almacenado Obtener Todos:
        public static List<Usuario> Listar()
        {
            // Atributos:
            List<Usuario> Lista_Usuarios = new List<Usuario>();

            using (SqlConnection DBConexion = new SqlConnection(Conexion.Cadena_Conexion))
            {
                SqlCommand Consulta_SQL = new SqlCommand("usp_listar", DBConexion);
                Consulta_SQL.CommandType = CommandType.StoredProcedure;

                // Ejecutamos La Consulta
                try
                {
                    DBConexion.Open();
                    Consulta_SQL.ExecuteNonQuery();

                    using (SqlDataReader Objetos_Obtenidos = Consulta_SQL.ExecuteReader())
                    {

                        while (Objetos_Obtenidos.Read())
                        {
                            Lista_Usuarios.Add(new Usuario()
                            {
                                IdUsuario = Convert.ToInt32(Objetos_Obtenidos["IdUsuario"]),
                                DocumentoIdentidad = Objetos_Obtenidos["DocumentoIdentidad"].ToString(),
                                Nombres = Objetos_Obtenidos["Nombres"].ToString(),
                                Telefono = Objetos_Obtenidos["Telefono"].ToString(),
                                Correo = Objetos_Obtenidos["Correo"].ToString(),
                                Ciudad = Objetos_Obtenidos["Ciudad"].ToString(),
                                FechaRegistro = Convert.ToDateTime(Objetos_Obtenidos["FechaRegistro"].ToString())
                            });
                        }

                    }

                    return Lista_Usuarios;
                }
                catch (Exception ex)
                {
                    return Lista_Usuarios;
                }
            }
        }

        // METODO CREAR: llama al Procedimiento de Almacenado CREAR:
        public static bool Registrar(Usuario oUsuario)
        {

            using (SqlConnection DBConexion = new SqlConnection(Conexion.Cadena_Conexion))
            {
                SqlCommand Consulta_SQL = new SqlCommand("usp_registrar", DBConexion);
                Consulta_SQL.CommandType = CommandType.StoredProcedure;
                Consulta_SQL.Parameters.AddWithValue("@documentoidentidad", oUsuario.DocumentoIdentidad);
                Consulta_SQL.Parameters.AddWithValue("@nombres", oUsuario.Nombres);
                Consulta_SQL.Parameters.AddWithValue("@telefono", oUsuario.Telefono);
                Consulta_SQL.Parameters.AddWithValue("@correo", oUsuario.Correo);
                Consulta_SQL.Parameters.AddWithValue("@ciudad", oUsuario.Ciudad);

                // Ejecutamos La Consulta
                try
                {
                    DBConexion.Open();
                    Consulta_SQL.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }

        }


        // METODO EDITAR: llama al Procedimiento de Almacenado Editar:
        public static bool Modificar(Usuario oUsuario)
        {
            using (SqlConnection DBConexion = new SqlConnection(Conexion.Cadena_Conexion))
            {
                SqlCommand Consulta_SQL = new SqlCommand("usp_modificar", DBConexion);
                Consulta_SQL.CommandType = CommandType.StoredProcedure;
                Consulta_SQL.Parameters.AddWithValue("@idusuario", oUsuario.IdUsuario);
                Consulta_SQL.Parameters.AddWithValue("@documentoidentidad", oUsuario.DocumentoIdentidad);
                Consulta_SQL.Parameters.AddWithValue("@nombres", oUsuario.Nombres);
                Consulta_SQL.Parameters.AddWithValue("@telefono", oUsuario.Telefono);
                Consulta_SQL.Parameters.AddWithValue("@correo", oUsuario.Correo);
                Consulta_SQL.Parameters.AddWithValue("@ciudad", oUsuario.Ciudad);

                // Ejecutamos La Consulta
                try
                {
                    DBConexion.Open();
                    Consulta_SQL.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }


        // METODO OBTENER POR ID: llama al Procedimiento de Almacenado Obtener Por Id:
        public static Usuario Obtener(int idusuario)
        {
            // Atributos:
            Usuario oUsuario = new Usuario();

            using (SqlConnection DBConexion = new SqlConnection(Conexion.Cadena_Conexion))
            {
                SqlCommand Consulta_SQL = new SqlCommand("usp_obtener", DBConexion);
                Consulta_SQL.CommandType = CommandType.StoredProcedure;
                Consulta_SQL.Parameters.AddWithValue("@idusuario", idusuario);

                // Ejecutamos La Consulta
                try
                {
                    DBConexion.Open();
                    Consulta_SQL.ExecuteNonQuery();

                    using (SqlDataReader Objeto_Obtenido = Consulta_SQL.ExecuteReader())
                    {

                        while (Objeto_Obtenido.Read())
                        {
                            oUsuario = new Usuario()
                            {
                                IdUsuario = Convert.ToInt32(Objeto_Obtenido["IdUsuario"]),
                                DocumentoIdentidad = Objeto_Obtenido["DocumentoIdentidad"].ToString(),
                                Nombres = Objeto_Obtenido["Nombres"].ToString(),
                                Telefono = Objeto_Obtenido["Telefono"].ToString(),
                                Correo = Objeto_Obtenido["Correo"].ToString(),
                                Ciudad = Objeto_Obtenido["Ciudad"].ToString(),
                                FechaRegistro = Convert.ToDateTime(Objeto_Obtenido["FechaRegistro"].ToString())
                            };
                        }

                    }



                    return oUsuario;
                }
                catch (Exception ex)
                {
                    return oUsuario;
                }
            }
        }


        // METODO ELIMINAR: llama al Procedimiento de Almacenado Eliminar:
        public static bool Eliminar(int id)
        {
            using (SqlConnection DBConexion = new SqlConnection(Conexion.Cadena_Conexion))
            {
                SqlCommand Consulta_SQL = new SqlCommand("usp_eliminar", DBConexion);
                Consulta_SQL.CommandType = CommandType.StoredProcedure;
                Consulta_SQL.Parameters.AddWithValue("@idusuario", id);

                // Ejecutamos La Consulta
                try
                {
                    DBConexion.Open();
                    Consulta_SQL.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

    }
}