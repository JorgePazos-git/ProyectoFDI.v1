using ProyectoFDI.Models;
using System.Data.SqlClient;
using System.Data;

namespace ProyectoFDI.Logica
{
    public class LO_Usuario
    {
        public Usuarios EncontrarUsuario(string nombre, string contraseña)
        {
            Usuarios objeto = new Usuarios();

            using (SqlConnection conn = new SqlConnection("Data Source=(localdb)\\Servidor;Initial Catalog=ProyectoFDI;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                string query = "select nombre_usu, contraseña_usu, IdRol from Usuarios where nombre_usu = @pnombre and contraseña_usu= @pcontraseña";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@pnombre", nombre);
                cmd.Parameters.AddWithValue("@pcontraseña", contraseña);
                cmd.CommandType = CommandType.Text;

                conn.Open();


                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            objeto = new Usuarios()
                            {
                                nombre_usu = dr["nombre_usu"].ToString(),
                                contraseña_usu = dr["contraseña_usu"].ToString(),
                                IdRol = (Rol)dr["IdRol"]
                            };
                        }
                    }
            }

            return objeto;
        }
    }
}
