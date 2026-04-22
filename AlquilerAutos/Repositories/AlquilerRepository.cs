using AlquilerAutos.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace AlquilerAutos.Repositories
{
    public class AlquilerRepository : BaseRepository
    {
        public AlquilerRepository(IConfiguration configuration) : base(configuration) { }

        public void Registrar(AlquilerViewModel model, int idUsuario)
        {
            using var cn = GetConnection();
            using var cmd = new SqlCommand("usp_alquiler_registrar", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IdCliente", model.IdCliente);
            cmd.Parameters.AddWithValue("@IdAuto", model.IdAuto);
            cmd.Parameters.AddWithValue("@FechaInicio", model.FechaInicio);
            cmd.Parameters.AddWithValue("@FechaFin", model.FechaFin);
            cmd.Parameters.AddWithValue("@Garantia", model.Garantia);
            cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);

            cn.Open();
            cmd.ExecuteNonQuery();
        }

        public List<AlquilerViewModel> Reporte(DateTime? fechaInicio, DateTime? fechaFin, string texto)
        {
            var lista = new List<AlquilerViewModel>();

            using var cn = GetConnection();
            using var cmd = new SqlCommand("usp_reporte_alquileres", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FechaInicio", (object?)fechaInicio ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@FechaFin", (object?)fechaFin ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Texto", texto ?? "");

            cn.Open();
            using var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lista.Add(new AlquilerViewModel
                {
                    IdAlquiler = Convert.ToInt32(dr["IdAlquiler"]),
                    Cliente = dr["Cliente"].ToString() ?? "",
                    Auto = dr["Auto"].ToString() ?? "",
                    FechaInicio = Convert.ToDateTime(dr["FechaInicio"]),
                    FechaFin = Convert.ToDateTime(dr["FechaFin"]),
                    Dias = Convert.ToInt32(dr["Dias"]),
                    PrecioDia = Convert.ToDecimal(dr["PrecioDia"]),
                    Garantia = Convert.ToDecimal(dr["Garantia"]),
                    Total = Convert.ToDecimal(dr["Total"]),
                    Estado = dr["Estado"].ToString() ?? "",
                    FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"]),
                    UsuarioRegistro = dr["UsuarioRegistro"].ToString() ?? ""
                });
            }

            return lista;
        }
    }
}