using System;
using System.IO;
using Microsoft.Data.Sqlite;

namespace NutricionApp.Data
{
    /// <summary>
    /// Contexto de base de datos SQLite.
    /// Iteracion 2: reemplaza los cuatro archivos CSV de la iteracion anterior.
    /// Patron: Singleton registrado en DI — una sola instancia compartida.
    /// </summary>
    public class DatabaseContext
    {
        private readonly string _connectionString;

        /// <summary>
        /// Constructor de produccion: usa un archivo .db en disco.
        /// </summary>
        public DatabaseContext()
        {
            var dbPath = Path.Combine(AppContext.BaseDirectory, "Data", "nutricion.db");
            Directory.CreateDirectory(Path.GetDirectoryName(dbPath)!);
            _connectionString = $"Data Source={dbPath}";
        }

        /// <summary>
        /// Constructor para testing: acepta una cadena de conexion personalizada.
        /// Permite usar SQLite en memoria para pruebas unitarias aisladas.
        /// </summary>
        public DatabaseContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        /// <summary>Abre una conexion SQLite. El llamador debe hacer Dispose.</summary>
        public SqliteConnection OpenConnection()
        {
            var conn = new SqliteConnection(_connectionString);
            conn.Open();
            return conn;
        }

        /// <summary>
        /// Crea las tablas y siembra los datos iniciales si la base de datos esta vacia.
        /// Se llama una sola vez al iniciar la aplicacion.
        /// </summary>
        public void Initialize()
        {
            using var conn = OpenConnection();
            CreateTables(conn);
            SeedData(conn);
        }

        private static void CreateTables(SqliteConnection conn)
        {
            var cmd = conn.CreateCommand();
            cmd.CommandText = @"
                CREATE TABLE IF NOT EXISTS Usuarios (
                    Id       INTEGER PRIMARY KEY AUTOINCREMENT,
                    UserName TEXT    NOT NULL UNIQUE,
                    Password TEXT    NOT NULL,
                    IsAdmin  INTEGER NOT NULL DEFAULT 0,
                    IsActive INTEGER NOT NULL DEFAULT 1
                );
                CREATE TABLE IF NOT EXISTS Perfiles (
                    Id        INTEGER PRIMARY KEY AUTOINCREMENT,
                    UserName  TEXT NOT NULL UNIQUE,
                    Edad      INTEGER NOT NULL,
                    PesoKg    REAL NOT NULL,
                    AlturaCm  REAL NOT NULL,
                    Objetivo  TEXT NOT NULL,
                    Actividad TEXT NOT NULL,
                    Dieta     TEXT NOT NULL
                );
                CREATE TABLE IF NOT EXISTS Alimentos (
                    Id            INTEGER PRIMARY KEY AUTOINCREMENT,
                    Nombre        TEXT NOT NULL UNIQUE,
                    Calorias      REAL NOT NULL,
                    Proteinas     REAL NOT NULL,
                    Carbohidratos REAL NOT NULL,
                    Grasas        REAL NOT NULL,
                    Porcion       REAL NOT NULL
                );
                CREATE TABLE IF NOT EXISTS Menus (
                    Id       INTEGER PRIMARY KEY AUTOINCREMENT,
                    UserName TEXT NOT NULL,
                    Fecha    TEXT NOT NULL
                );
                CREATE TABLE IF NOT EXISTS ItemsMenu (
                    Id             INTEGER PRIMARY KEY AUTOINCREMENT,
                    MenuId         INTEGER NOT NULL,
                    NombreAlimento TEXT NOT NULL,
                    CantidadGramos REAL NOT NULL,
                    Calorias       REAL NOT NULL,
                    Proteinas      REAL NOT NULL,
                    Carbohidratos  REAL NOT NULL,
                    Grasas         REAL NOT NULL,
                    FOREIGN KEY (MenuId) REFERENCES Menus(Id)
                );";
            cmd.ExecuteNonQuery();
        }

        private static void SeedData(SqliteConnection conn)
        {
            var check = conn.CreateCommand();
            check.CommandText = "SELECT COUNT(*) FROM Usuarios;";
            if ((long)check.ExecuteScalar()! > 0) return;

            // Admin
            Run(conn, "INSERT INTO Usuarios(UserName,Password,IsAdmin,IsActive) VALUES('admin','admin123',1,1);");

            // Usuarios originales del CSV
            var users = new (string u, string p)[]
            {
                ("Randy","123"),("Joely","123"),("Kevin","123"),("gustavo","123"),
                ("Maria","123"),("Carlos","123"),("Luis","123"),("Ana","123"),
                ("Jose","123"),("Fernanda","123"),("Diego","123"),("Sofia","123"),
                ("Jorge","123"),("Valeria","123"),("Andres","123"),("Camila","123"),
                ("Daniel","123"),("Paula","123"),("Miguel","123"),("Elena","123"),
                ("Ricardo","123"),("Lucia","123"),("Pablo","123"),("Andrea","123"),
                ("Fernando","123"),("test","123"),("Alfonso","456")
            };
            foreach (var (u, p) in users)
            {
                var c = conn.CreateCommand();
                c.CommandText = "INSERT INTO Usuarios(UserName,Password,IsAdmin,IsActive) VALUES(@u,@p,0,1);";
                c.Parameters.AddWithValue("@u", u);
                c.Parameters.AddWithValue("@p", p);
                c.ExecuteNonQuery();
            }

            // Perfiles originales del CSV
            var perfiles = new (string u, int e, double pk, double ac, string obj, string act, string d)[]
            {
                ("Randy",38,55,181,"Mantener","Sedentario","Estandar"),
                ("Joely",25,60,180.8,"PerderPeso","Ligero","Keto"),
                ("Kevin",39,83.3,174.1,"GanarMasa","Moderado","Vegetariano"),
                ("gustavo",36,69,156,"Mantener","Activo","Estandar"),
                ("Maria",24,60.5,176.1,"PerderPeso","MuyActivo","Keto"),
                ("Carlos",35,58.9,177.7,"GanarMasa","Sedentario","Vegetariano"),
                ("Luis",35,68.9,170.7,"Mantener","Ligero","Estandar"),
                ("Ana",26,86.4,155.2,"PerderPeso","Moderado","Keto"),
                ("Jose",43,57.2,169.8,"GanarMasa","Activo","Vegetariano"),
                ("Fernanda",26,57,188.5,"Mantener","MuyActivo","Estandar"),
                ("Diego",28,54.6,168.3,"PerderPeso","Sedentario","Keto"),
                ("Sofia",29,88.1,176.1,"GanarMasa","Ligero","Vegetariano"),
                ("Jorge",43,52,171.1,"Mantener","Moderado","Estandar"),
                ("Valeria",21,93.8,168.2,"PerderPeso","Activo","Keto"),
                ("Andres",35,63.2,177,"GanarMasa","MuyActivo","Vegetariano"),
                ("Camila",45,66.3,161.7,"Mantener","Sedentario","Estandar"),
                ("Daniel",20,52.1,163,"PerderPeso","Ligero","Keto"),
                ("Paula",27,94.3,184.9,"GanarMasa","Moderado","Vegetariano"),
                ("Miguel",45,54.5,164.7,"Mantener","Activo","Estandar"),
                ("Elena",38,87.5,160.7,"PerderPeso","MuyActivo","Keto"),
                ("Ricardo",29,59.4,164.3,"GanarMasa","Sedentario","Vegetariano"),
                ("Lucia",39,79.2,176.3,"Mantener","Ligero","Estandar"),
                ("Pablo",23,74,163.6,"PerderPeso","Moderado","Keto"),
                ("Andrea",32,67.1,189.6,"GanarMasa","Activo","Vegetariano"),
                ("Fernando",38,81,162.7,"Mantener","MuyActivo","Estandar"),
                ("test",36,70,170,"Mantener","Moderado","Estandar"),
                ("Alfonso",25,70,170,"Mantener","Moderado","Vegetariano")
            };
            foreach (var p in perfiles)
            {
                var c = conn.CreateCommand();
                c.CommandText = "INSERT OR IGNORE INTO Perfiles(UserName,Edad,PesoKg,AlturaCm,Objetivo,Actividad,Dieta) VALUES(@u,@e,@pk,@ac,@obj,@act,@d);";
                c.Parameters.AddWithValue("@u", p.u);   c.Parameters.AddWithValue("@e", p.e);
                c.Parameters.AddWithValue("@pk", p.pk); c.Parameters.AddWithValue("@ac", p.ac);
                c.Parameters.AddWithValue("@obj", p.obj); c.Parameters.AddWithValue("@act", p.act);
                c.Parameters.AddWithValue("@d", p.d);
                c.ExecuteNonQuery();
            }

            // Alimentos originales del CSV
            var alimentos = new (string n, double cal, double prot, double carb, double gras, double porc)[]
            {
                ("Arroz blanco cocido",130,2.7,28.2,0.3,100),
                ("Arroz integral cocido",111,2.6,23.0,0.9,100),
                ("Pan integral",247,13.0,41.0,3.4,100),
                ("Pan blanco",265,9.0,49.0,3.2,100),
                ("Pechuga de pollo",165,31.0,0,3.6,100),
                ("Carne molida (res)",215,26.1,0,11.8,100),
                ("Huevo entero",155,13.0,1.1,11.0,100),
                ("Leche entera",61,3.2,4.8,3.3,100),
                ("Yogurt natural",59,3.5,4.7,3.3,100),
                ("Queso fresco",98,11.1,0.5,5.5,100),
                ("Frijoles negros cocidos",132,8.9,23.7,0.5,100),
                ("Lenteja cocida",116,9.0,20.1,0.4,100),
                ("Atun en agua",116,25.5,0,0.8,100),
                ("Salmon",208,20.0,0,13.4,100),
                ("Zanahoria",41,0.9,9.6,0.2,100),
                ("Espinaca",23,2.9,3.6,0.4,100),
                ("Tomate",18,0.9,3.9,0.2,100),
                ("Lechuga",15,1.4,2.9,0.2,100),
                ("Brocoli",34,2.8,6.6,0.4,100),
                ("Manzana",52,0.3,13.8,0.2,100),
                ("Banana",89,1.1,22.8,0.3,100),
                ("Naranja",47,0.9,11.8,0.1,100),
                ("Aguacate",160,2.0,8.5,14.7,100),
                ("Aceite de oliva",884,0,0,100,100),
                ("Mantequilla",717,0.9,0.1,81.1,100),
                ("Avena",389,16.9,66.3,6.9,100),
                ("Pasta cocida",158,5.8,30.9,0.9,100),
                ("Papa cocida",77,2.0,17.0,0.1,100),
                ("Camote cocido",86,1.6,20.1,0.1,100),
                ("Pina",50,0.5,13.1,0.1,100)
            };
            foreach (var a in alimentos)
            {
                var c = conn.CreateCommand();
                c.CommandText = "INSERT OR IGNORE INTO Alimentos(Nombre,Calorias,Proteinas,Carbohidratos,Grasas,Porcion) VALUES(@n,@cal,@prot,@carb,@gras,@porc);";
                c.Parameters.AddWithValue("@n", a.n);     c.Parameters.AddWithValue("@cal", a.cal);
                c.Parameters.AddWithValue("@prot", a.prot); c.Parameters.AddWithValue("@carb", a.carb);
                c.Parameters.AddWithValue("@gras", a.gras); c.Parameters.AddWithValue("@porc", a.porc);
                c.ExecuteNonQuery();
            }
        }

        private static void Run(SqliteConnection conn, string sql)
        {
            var c = conn.CreateCommand();
            c.CommandText = sql;
            c.ExecuteNonQuery();
        }
    }
}
