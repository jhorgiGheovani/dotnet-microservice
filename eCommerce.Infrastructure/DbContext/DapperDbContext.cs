using AutoMapper;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace eCommerce.Infrastructure.DbContext;

public class DapperDbContext
{
    private readonly IConfiguration _configuration;
    private readonly IDbConnection _connection;
    public DapperDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
        string connectionString = _configuration.GetConnectionString("PostgresConnection");


        //Create a new NpgsqlConnection with the retrieved connection string
        _connection =  new Npgsql.NpgsqlConnection(connectionString);
    }


    public IDbConnection GetConnection() => _connection;
}
