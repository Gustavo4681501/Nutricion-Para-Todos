using System;
using Microsoft.Data.Sqlite;
using NutricionApp.Data;
using NutricionApp.Data.Repositories;

namespace NutricionApp.Tests
{
    /// <summary>
    /// Fabrica de bases de datos SQLite en memoria para los tests.
    /// Actualizado para el patron Repository: expone repositorios listos para usar.
    /// Cada test recibe una BD limpia e independiente.
    /// Patron: Factory — crea instancias configuradas para testing.
    /// </summary>
    public class TestDatabaseFactory : IDisposable
    {
        private readonly SqliteConnection _keepAliveConnection;
        private readonly string           _connectionString;
        private readonly DatabaseContext  _context;

        public TestDatabaseFactory()
        {
            string dbName      = $"TestDb_{Guid.NewGuid():N}";
            _connectionString  = $"Data Source={dbName};Mode=Memory;Cache=Shared";
            _keepAliveConnection = new SqliteConnection(_connectionString);
            _keepAliveConnection.Open();

            _context = new DatabaseContext(_connectionString);
            _context.Initialize();
        }

        /// <summary>Retorna el contexto de BD compartido para esta instancia de test.</summary>
        public DatabaseContext CreateContext() => _context;

        /// <summary>Crea un UsuarioRepository listo para testing.</summary>
        public UsuarioRepository CreateUsuarioRepository() => new UsuarioRepository(_context);

        /// <summary>Crea un AlimentoRepository listo para testing.</summary>
        public AlimentoRepository CreateAlimentoRepository() => new AlimentoRepository(_context);

        /// <summary>Crea un MenuRepository listo para testing.</summary>
        public MenuRepository CreateMenuRepository() => new MenuRepository(_context);

        /// <summary>Crea un PerfilRepository listo para testing.</summary>
        public PerfilRepository CreatePerfilRepository() => new PerfilRepository(_context);

        public void Dispose()
        {
            _keepAliveConnection?.Close();
            _keepAliveConnection?.Dispose();
        }
    }
}
