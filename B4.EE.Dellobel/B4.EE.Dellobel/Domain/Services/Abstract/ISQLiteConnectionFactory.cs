using SQLite.Net;

namespace B4.EE.DellobelI.Domain.Services.Abstract
{
    public interface ISQLiteConnectionFactory
    {
        SQLiteConnection CreateConnection(string databaseFileName);
    }
}
