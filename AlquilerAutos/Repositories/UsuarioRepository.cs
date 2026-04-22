using AlquilerAutos.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace AlquilerAutos.Repositories
{
    public class UsuarioRepository : BaseRepository
    {
        public UsuarioRepository(IConfiguration configuration) : base(configuration) { }

        public UsuarioSesionViewModel? Login(string usuario, string clave)
        {
            using var cn = GetConnection();
            using var cmd = new SqlCommand("usp_usuario_login", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Usuario", usuario);
            cmd.Parameters.AddWithValue("@Clave", clave);

            cn.Open();
            using var dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                return new UsuarioSesionViewModel
                {
                    IdUsuario = Convert.ToInt32(dr["IdUsuario"]),
                    Usuario = dr["Usuario"].ToString() ?? "",
                    NombreCompleto = dr["NombreCompleto"].ToString() ?? "",
                    NombreRol = dr["NombreRol"].ToString() ?? ""
                };
            }

            return null;
        }
    }
}