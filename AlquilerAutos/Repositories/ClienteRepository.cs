using AlquilerAutos.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace AlquilerAutos.Repositories
{
    public class ClienteRepository : BaseRepository
    {
        public ClienteRepository(IConfiguration configuration) : base(configuration) { }

        public List<ClienteViewModel> Listar(string texto)
        {
            var lista = new List<ClienteViewModel>();

            using var cn = GetConnection();
            using var cmd = new SqlCommand("usp_clientes_listar", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Texto", texto ?? "");

            cn.Open();
            using var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lista.Add(new ClienteViewModel
                {
                    IdCliente = Convert.ToInt32(dr["IdCliente"]),
                    Dni = dr["Dni"].ToString() ?? "",
                    Nombres = dr["Nombres"].ToString() ?? "",
                    Apellidos = dr["Apellidos"].ToString() ?? "",
                    Email = dr["Email"] == DBNull.Value ? null : dr["Email"].ToString(),
                    Telefono = dr["Telefono"] == DBNull.Value ? null : dr["Telefono"].ToString(),
                    LicenciaConducir = dr["LicenciaConducir"].ToString() ?? "",
                    Activo = Convert.ToBoolean(dr["Activo"])
                });
            }

            return lista;
        }

        public ClienteViewModel? Obtener(int id)
        {
            using var cn = GetConnection();
            using var cmd = new SqlCommand("usp_cliente_obtener", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IdCliente", id);

            cn.Open();
            using var dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                return new ClienteViewModel
                {
                    IdCliente = Convert.ToInt32(dr["IdCliente"]),
                    Dni = dr["Dni"].ToString() ?? "",
                    Nombres = dr["Nombres"].ToString() ?? "",
                    Apellidos = dr["Apellidos"].ToString() ?? "",
                    Email = dr["Email"] == DBNull.Value ? null : dr["Email"].ToString(),
                    Telefono = dr["Telefono"] == DBNull.Value ? null : dr["Telefono"].ToString(),
                    LicenciaConducir = dr["LicenciaConducir"].ToString() ?? "",
                    Activo = Convert.ToBoolean(dr["Activo"])
                };
            }

            return null;
        }

        public void Guardar(ClienteViewModel model)
        {
            using var cn = GetConnection();
            using var cmd = new SqlCommand("usp_cliente_guardar", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IdCliente", model.IdCliente);
            cmd.Parameters.AddWithValue("@Dni", model.Dni);
            cmd.Parameters.AddWithValue("@Nombres", model.Nombres);
            cmd.Parameters.AddWithValue("@Apellidos", model.Apellidos);
            cmd.Parameters.AddWithValue("@Email", (object?)model.Email ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Telefono", (object?)model.Telefono ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@LicenciaConducir", model.LicenciaConducir);

            cn.Open();
            cmd.ExecuteNonQuery();
        }

        public void Eliminar(int id)
        {
            using var cn = GetConnection();
            using var cmd = new SqlCommand("usp_cliente_eliminar", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IdCliente", id);

            cn.Open();
            cmd.ExecuteNonQuery();
        }

        public List<ComboViewModel> Combo()
        {
            var lista = new List<ComboViewModel>();

            using var cn = GetConnection();
            using var cmd = new SqlCommand("usp_clientes_combo", cn);
            cmd.CommandType = CommandType.StoredProcedure;

            cn.Open();
            using var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lista.Add(new ComboViewModel
                {
                    Id = Convert.ToInt32(dr["IdCliente"]),
                    Texto = dr["NombreCliente"].ToString() ?? ""
                });
            }

            return lista;
        }
    }
}