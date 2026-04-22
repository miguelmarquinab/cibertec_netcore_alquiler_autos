using Microsoft.Data.SqlClient;

namespace AlquilerAutos.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly IConfiguration _configuration;

        protected BaseRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected SqlConnection GetConnection()
        {
            return new SqlConnection(_configuration.GetConnectionString("cn1"));
        }
    }
}