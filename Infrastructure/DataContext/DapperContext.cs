using Npgsql;

namespace Infrastructure.DataContext;

public class DapperContext
{
    private readonly string _connectionString=
        "Host=localhost;Port=5432;Database=HT26;User Id=postgres;Password=909662643;";

    public NpgsqlConnection Connection()
    {
        return new NpgsqlConnection(_connectionString);
    }
 
}