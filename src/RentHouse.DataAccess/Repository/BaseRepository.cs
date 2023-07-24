using Dapper;
using Npgsql;
using RentHouse.DataAccess.Handlers;

namespace RentHouse.DataAccess.Repository;

public class BaseRepository
{
    protected readonly NpgsqlConnection _connection;
    public BaseRepository()
    {
        SqlMapper.AddTypeHandler(new DateOnlyTypeHandler());
        Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
        this._connection = new NpgsqlConnection("Host = localhost; Port = 5432; Database = RentHouse-db; User Id = postgres; password = abdurahim2005;");

    }
}
