using AlquilerAutos.Models;
using Microsoft.Data.SqlClient;

namespace AlquilerAutos.Repositories
{
    public class DashboardRepository : BaseRepository
    {
        public DashboardRepository(IConfiguration configuration) : base(configuration) { }

        public DashboardViewModel Obtener()
        {
            var model = new DashboardViewModel();

            using var cn = GetConnection();
            cn.Open();

            using (var cmd = new SqlCommand("SELECT COUNT(*) FROM Autos WHERE Activo = 1", cn))
                model.TotalAutos = Convert.ToInt32(cmd.ExecuteScalar());

            using (var cmd = new SqlCommand("SELECT COUNT(*) FROM Autos WHERE Activo = 1 AND Estado = 'DISPONIBLE'", cn))
                model.AutosDisponibles = Convert.ToInt32(cmd.ExecuteScalar());

            using (var cmd = new SqlCommand("SELECT COUNT(*) FROM Clientes WHERE Activo = 1", cn))
                model.TotalClientes = Convert.ToInt32(cmd.ExecuteScalar());

            using (var cmd = new SqlCommand("SELECT COUNT(*) FROM Alquileres", cn))
                model.TotalAlquileres = Convert.ToInt32(cmd.ExecuteScalar());

            using (var cmd = new SqlCommand("SELECT ISNULL(SUM(Total),0) FROM Alquileres", cn))
                model.IngresosTotales = Convert.ToDecimal(cmd.ExecuteScalar());

            return model;
        }
    }
}