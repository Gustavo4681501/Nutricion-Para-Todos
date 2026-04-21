using System;
using Microsoft.Data.Sqlite;
using NutricionApp.Data;

namespace NutricionApp.Tests
{
    /// <summary>
    /// Fabrica de bases de datos SQLite en memoria para los tests.
    /// Cada test recibe una BD limpia e independiente.
    /// Patron: Factory — crea instancias de DatabaseContext configuradas para testing.
    /// </summary>
    public class TestDatabaseFactory : IDisposable
    {
        private readonly SqliteConnection _keepAliveConnection;
        private readonly string _connectionString;

        public TestDatabaseFactory()
        {
            // Nombre unico por instancia para aislar cada test
            string dbName = $"TestDb_{Guid.NewGuid():N}";
            _connectionString = $"Data Source={dbName};Mode=Memory;Cache=Shared";

            // Mantener una conexion abierta para que SQLite no elimine la BD en memoria
            _keepAliveConnection = new SqliteConnection(_connectionString);
            _keepAliveConnection.Open();
        }

        /// <summary>
        /// Crea un DatabaseContext configurado para usar la BD en memoria.
        /// </summary>
        public DatabaseContext CreateContext()
        {
            var ctx = new DatabaseContext(_connectionString);
            ctx.Initialize();
            return ctx;
        }

        public void Dispose()
        {
            _keepAliveConnection?.Close();
            _keepAliveConnection?.Dispose();
        }
    }
}
