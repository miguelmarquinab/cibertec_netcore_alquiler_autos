using AlquilerAutos.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace AlquilerAutos.Repositories
{
    public class AutoRepository : BaseRepository
    {
        public AutoRepository(IConfiguration configuration) : base(configuration) { }

        public PaginacionViewModel<AutoViewModel> Listar(string texto, string estado, int pagina, int tamPagina)
        {
            var lista = new List<AutoViewModel>();
            int total = 0;

            using var cn = GetConnection();
            using var cmd = new SqlCommand("usp_autos_listar", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Texto", texto ?? "");
            cmd.Parameters.AddWithValue("@Estado", estado ?? "");
            cmd.Parameters.AddWithValue("@Pagina", pagina);
            cmd.Parameters.AddWithValue("@TamPagina", tamPagina);

            cn.Open();
            using var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                total = Convert.ToInt32(dr["TotalRegistros"]);
                lista.Add(new AutoViewModel
                {
                    IdAuto = Convert.ToInt32(dr["IdAuto"]),
                    Placa = dr["Placa"].ToString() ?? "",
                    Modelo = dr["Modelo"].ToString() ?? "",
                    Anio = Convert.ToInt32(dr["Anio"]),
                    Color = dr["Color"].ToString() ?? "",
                    PrecioPorDia = Convert.ToDecimal(dr["PrecioPorDia"]),
                    Estado = dr["Estado"].ToString() ?? "",
                    IdMarca = Convert.ToInt32(dr["IdMarca"]),
                    NombreMarca = dr["NombreMarca"].ToString() ?? "",
                    ImagenUrl = dr["ImagenUrl"] == DBNull.Value ? null : dr["ImagenUrl"].ToString(),
                    Activo = Convert.ToBoolean(dr["Activo"])
                });
            }

            return new PaginacionViewModel<AutoViewModel>
            {
                Items = lista,
                PaginaActual = pagina,
                TamPagina = tamPagina,
                TotalRegistros = total,
                Texto = texto ?? "",
                Estado = estado ?? ""
            };
        }

        public AutoViewModel? Obtener(int id)
        {
            using var cn = GetConnection();
            using var cmd = new SqlCommand("usp_auto_obtener", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IdAuto", id);

            cn.Open();
            using var dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                return new AutoViewModel
                {
                    IdAuto = Convert.ToInt32(dr["IdAuto"]),
                    Placa = dr["Placa"].ToString() ?? "",
                    Modelo = dr["Modelo"].ToString() ?? "",
                    Anio = Convert.ToInt32(dr["Anio"]),
                    Color = dr["Color"].ToString() ?? "",
                    PrecioPorDia = Convert.ToDecimal(dr["PrecioPorDia"]),
                    Estado = dr["Estado"].ToString() ?? "",
                    IdMarca = Convert.ToInt32(dr["IdMarca"]),
                    ImagenUrl = dr["ImagenUrl"] == DBNull.Value ? null : dr["ImagenUrl"].ToString(),
                    Activo = Convert.ToBoolean(dr["Activo"])
                };
            }

            return null;
        }

        public void Guardar(AutoViewModel model)
        {
            using var cn = GetConnection();
            using var cmd = new SqlCommand("usp_auto_guardar", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IdAuto", model.IdAuto);
            cmd.Parameters.AddWithValue("@Placa", model.Placa);
            cmd.Parameters.AddWithValue("@Modelo", model.Modelo);
            cmd.Parameters.AddWithValue("@Anio", model.Anio);
            cmd.Parameters.AddWithValue("@Color", model.Color);
            cmd.Parameters.AddWithValue("@PrecioPorDia", model.PrecioPorDia);
            cmd.Parameters.AddWithValue("@Estado", model.Estado);
            cmd.Parameters.AddWithValue("@IdMarca", model.IdMarca);
            cmd.Parameters.AddWithValue("@ImagenUrl", (object?)model.ImagenUrl ?? DBNull.Value);

            cn.Open();
            cmd.ExecuteNonQuery();
        }

        public void Eliminar(int id)
        {
            using var cn = GetConnection();
            using var cmd = new SqlCommand("usp_auto_eliminar", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IdAuto", id);

            cn.Open();
            cmd.ExecuteNonQuery();
        }

        public List<MarcaViewModel> Marcas()
        {
            var lista = new List<MarcaViewModel>();

            using var cn = GetConnection();
            using var cmd = new SqlCommand("usp_marcas_listar", cn);
            cmd.CommandType = CommandType.StoredProcedure;

            cn.Open();
            using var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lista.Add(new MarcaViewModel
                {
                    IdMarca = Convert.ToInt32(dr["IdMarca"]),
                    NombreMarca = dr["NombreMarca"].ToString() ?? ""
                });
            }

            return lista;
        }

        public List<ComboViewModel> AutosDisponibles()
        {
            var lista = new List<ComboViewModel>();

            using var cn = GetConnection();
            using var cmd = new SqlCommand("usp_autos_disponibles", cn);
            cmd.CommandType = CommandType.StoredProcedure;

            cn.Open();
            using var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lista.Add(new ComboViewModel
                {
                    Id = Convert.ToInt32(dr["IdAuto"]),
                    Texto = dr["NombreAuto"].ToString() ?? "",
                    Precio = Convert.ToDecimal(dr["PrecioPorDia"])
                });
            }

            return lista;
        }
    }
}