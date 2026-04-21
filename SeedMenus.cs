using System;
using System.IO;
using Microsoft.Data.Sqlite;

/// <summary>
/// Script temporal para sembrar los menus historicos del CSV en la base de datos.
/// Ejecutar UNA sola vez despues de que la app ya haya corrido (para que las tablas existan).
/// Borrar este archivo despues de ejecutarlo.
/// </summary>
class SeedMenus
{
    public static void Main()
    {
        // Ruta de la DB — ajustar si es diferente en tu maquina
        var dbPath = Path.Combine(
            AppContext.BaseDirectory, "Data", "nutricion.db");

        if (!File.Exists(dbPath))
        {
            Console.WriteLine($"ERROR: No se encontro la base de datos en: {dbPath}");
            Console.WriteLine("Asegurate de haber corrido 'dotnet run' al menos una vez primero.");
            return;
        }

        Console.WriteLine($"Conectando a: {dbPath}");
        var connStr = $"Data Source={dbPath}";

        // Datos del CSV — formato: UserName, Fecha, NombreAlimento, Cantidad, Cal, Prot, Carb, Grasas
        var rows = new (string u, string f, string n, double cant, double cal, double prot, double carb, double gras)[]
        {
            ("Randy","2025-03-09","Pechuga de pollo",100,165,31,0,3.6),
            ("Randy","2025-03-09","Uvas",100,69,0.7,18,0.2),
            ("Randy","2025-03-09","Granola",80,376.8,8.48,51.2,16),
            ("Randy","2025-03-09","Huevo entero",120,186,15.6,1.32,13.2),
            ("Randy","2025-03-08","Leche entera",80,48.8,2.56,3.84,2.64),
            ("Randy","2025-03-08","Naranja",200,94,1.8,24,0.2),
            ("Randy","2025-03-08","Espinaca",150,34.5,4.35,5.4,0.6),
            ("Randy","2025-03-08","Tomate",100,18,0.9,3.9,0.2),
            ("Randy","2025-03-08","Fresa",150,48,1.05,11.55,0.45),
            ("Randy","2025-03-07","Papaya",120,51.6,0.6,13.2,0.36),
            ("Randy","2025-03-07","Sandia",150,45,0.9,11.4,0.3),
            ("Randy","2025-03-07","Muslo de pollo",250,522.5,65,0,27.5),
            ("Randy","2025-03-07","Champiñon",100,22,3.1,3.3,0.3),
            ("Randy","2025-03-07","Aceite de oliva",100,884,0,0,100),
            ("Randy","2025-03-06","Zanahoria",120,49.2,1.08,12,0.24),
            ("Randy","2025-03-06","Granola",80,376.8,8.48,51.2,16),
            ("Randy","2025-03-06","Almendras",250,1447.5,52.5,55,125),
            ("Randy","2025-03-06","Pina",200,100,1,26,0.2),
            ("Randy","2025-03-05","Aguacate",80,128,1.6,7.2,12),
            ("Randy","2025-03-05","Pasta cocida",120,157.2,6,30,1.32),
            ("Randy","2025-03-05","Queso mozzarella",200,560,56,4.4,34),
            ("Randy","2025-03-05","Bistec de res",80,216.8,20.8,0,14.4),
            ("Randy","2025-03-05","Leche descremada",150,51,5.1,7.5,0.15),
            ("Randy","2025-03-04","Sardina en aceite",80,166.4,19.68,0,9.2),
            ("Randy","2025-03-04","Miel",150,456,0.45,123,0),
            ("Randy","2025-03-04","Fresa",200,64,1.4,15.4,0.6),
            ("Randy","2025-03-03","Uvas",120,82.8,0.84,21.6,0.24),
            ("Randy","2025-03-03","Queso cottage",100,98,11,3.4,4.3),
            ("Randy","2025-03-03","Pan blanco",100,265,9,49,3.2),
            ("Randy","2025-03-02","Maiz cocido",100,96,3.4,21,1.5),
            ("Randy","2025-03-02","Cebolla",200,80,2.2,18.6,0.2),
            ("Randy","2025-03-02","Champiñon",250,55,7.75,8.25,0.75),
            ("Randy","2025-03-02","Queso cheddar",100,402,25,1.3,33),
            ("Randy","2025-03-02","Uvas",80,55.2,0.56,14.4,0.16),
            ("Randy","2025-03-01","Arroz integral cocido",250,277.5,6.5,57.5,2.25),
            ("Randy","2025-03-01","Maiz cocido",150,144,5.1,31.5,2.25),
            ("Randy","2025-03-01","Queso mozzarella",80,224,22.4,1.76,13.6),
            ("Randy","2025-02-28","Melon",200,68,1.6,16.4,0.4),
            ("Randy","2025-02-28","Pasta cocida",80,104.8,4,20,0.88),
            ("Randy","2025-02-28","Camote cocido",150,135,3,31.05,0.15),
            ("Randy","2025-02-28","Carne molida magra",120,258,31.2,0,14.4),
            ("gustavo","2025-03-15","Brocoli",250,85,7,16.5,1),
            ("gustavo","2025-03-15","Leche entera",100,61,3.2,4.8,3.3),
            ("gustavo","2025-03-15","Maiz cocido",200,192,6.8,42,3),
            ("gustavo","2025-03-15","Camaron cocido",200,198,48,0,0.6),
            ("gustavo","2025-03-14","Cerdo lomo",120,290.4,32.4,0,16.8),
            ("gustavo","2025-03-14","Aguacate",250,400,5,22.5,37.5),
            ("gustavo","2025-03-14","Pan blanco",150,397.5,13.5,73.5,4.8),
            ("gustavo","2025-03-13","Carne molida magra",80,172,20.8,0,9.6),
            ("gustavo","2025-03-13","Granola",100,471,10.6,64,20),
            ("gustavo","2025-03-12","Naranja",150,70.5,1.35,18,0.15),
            ("gustavo","2025-03-12","Arroz blanco cocido",100,130,2.7,28.2,0.3),
            ("gustavo","2025-03-11","Champiñon",100,22,3.1,3.3,0.3),
            ("gustavo","2025-03-11","Mani tostado",150,880.5,37.5,31.5,75),
            ("gustavo","2025-03-10","Atun en agua",200,232,52,0,2),
            ("gustavo","2025-03-10","Bistec de res",150,406.5,39,0,27),
            ("gustavo","2025-03-09","Papa cocida",120,103.2,2.04,24,0.12),
            ("gustavo","2025-03-09","Arroz blanco cocido",120,156,3.24,33.84,0.36),
            ("gustavo","2025-03-08","Manzana",80,41.6,0.24,11.2,0.16),
            ("gustavo","2025-03-08","Frijoles negros cocidos",100,132,8.9,23.7,0.5),
            ("gustavo","2025-03-07","Espinaca",120,27.6,3.48,4.32,0.48),
            ("gustavo","2025-03-07","Bistec de res",80,216.8,20.8,0,14.4),
            ("gustavo","2025-03-06","Mango",250,150,2,37.5,1),
            ("gustavo","2025-03-05","Banano",200,178,2.2,46,0.6),
            ("gustavo","2025-03-04","Brocoli",200,68,5.6,13.2,0.8),
            ("gustavo","2025-03-03","Arroz blanco cocido",100,130,2.7,28.2,0.3),
            ("gustavo","2025-03-02","Pan blanco",200,530,18,98,6.4),
            ("gustavo","2025-03-01","Pan integral",80,197.6,10.4,32.8,2.72),
            ("Maria","2025-03-09","Queso mozzarella",80,224,22.4,1.76,13.6),
            ("Maria","2025-03-08","Huevo entero",150,232.5,19.5,1.65,16.5),
            ("Maria","2025-03-07","Yogur griego",100,97,9,3.6,5),
            ("Maria","2025-03-06","Granola",250,1177.5,26.5,160,50),
            ("Maria","2025-03-05","Almendras",200,1158,42,44,100),
            ("Maria","2025-03-04","Naranja",120,56.4,1.08,14.4,0.12),
            ("Maria","2025-03-03","Pechuga de pollo",80,132,24.8,0,2.88),
            ("Maria","2025-03-02","Pechuga de pollo",120,198,37.2,0,4.32),
            ("Maria","2025-03-01","Arroz blanco cocido",100,130,2.7,28.2,0.3),
            ("Maria","2025-02-28","Camaron cocido",250,247.5,60,0,0.75),
            ("Carlos","2025-03-09","Nuez",250,1635,37.5,35,162.5),
            ("Carlos","2025-03-08","Salmon",80,166.4,16,0,10.4),
            ("Carlos","2025-03-07","Bistec de res",120,325.2,31.2,0,21.6),
            ("Carlos","2025-03-06","Zanahoria",200,82,1.8,20,0.4),
            ("Carlos","2025-03-05","Avena en hojuelas",250,972.5,42.5,165,17.5),
            ("Carlos","2025-03-04","Yogur griego",200,194,18,7.2,10),
            ("Carlos","2025-03-03","Mani tostado",100,587,25,21,50),
            ("Carlos","2025-03-02","Manzana",250,130,0.75,35,0.5),
            ("Carlos","2025-03-01","Papa cocida",250,215,4.25,50,0.25),
            ("Joely","2025-03-10","Frijoles negros cocidos",80,105.6,7.12,18.96,0.4),
            ("Joely","2025-03-09","Banano",200,178,2.2,46,0.6),
            ("Joely","2025-03-08","Leche entera",150,91.5,4.8,7.2,4.95),
            ("Joely","2025-03-07","Granola",250,1177.5,26.5,160,50),
            ("Joely","2025-03-06","Huevo entero",100,155,13,1.1,11),
            ("Joely","2025-03-05","Mani tostado",120,704.4,30,25.2,60),
            ("Joely","2025-03-04","Tilapia",120,115.2,24.12,0,2.4),
            ("Joely","2025-03-03","Tilapia",150,144,30.15,0,3),
            ("Joely","2025-03-02","Lentejas cocidas",150,174,13.5,30,0.6),
            ("Joely","2025-03-01","Mani tostado",100,587,25,21,50),
            ("Kevin","2025-03-07","Melon",200,68,1.6,16.4,0.4),
            ("Kevin","2025-03-06","Frijoles negros cocidos",200,264,17.8,47.4,1),
            ("Kevin","2025-03-05","Carne molida magra",250,537.5,65,0,30),
            ("Kevin","2025-03-04","Quinoa cocida",150,180,6.6,31.95,2.85),
            ("Kevin","2025-03-03","Cerdo lomo",150,363,40.5,0,21),
            ("Kevin","2025-03-02","Yogur natural",120,70.8,4.2,4.32,3.96),
            ("Kevin","2025-03-01","Almendras",100,579,21,22,50),
            ("Alfonso","2026-04-06","Cerdo lomo",100,242,27,0,14),
            ("Alfonso","2026-04-06","Leche descremada",100,34,3.4,5,0.1),
        };

        using var conn = new SqliteConnection(connStr);
        conn.Open();

        int menusCreados = 0;
        int itemsInsertados = 0;

        // Agrupar por usuario + fecha
        var grupos = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<(string n, double cant, double cal, double prot, double carb, double gras)>>();

        foreach (var r in rows)
        {
            string key = $"{r.u}|{r.f}";
            if (!grupos.ContainsKey(key))
                grupos[key] = new();
            grupos[key].Add((r.n, r.cant, r.cal, r.prot, r.carb, r.gras));
        }

        foreach (var kv in grupos)
        {
            var parts = kv.Key.Split('|');
            string userName = parts[0];
            string fecha    = parts[1];

            // Verificar que el usuario existe
            var chk = conn.CreateCommand();
            chk.CommandText = "SELECT COUNT(*) FROM Usuarios WHERE UserName=@u;";
            chk.Parameters.AddWithValue("@u", userName);
            if ((long)chk.ExecuteScalar()! == 0) continue;

            // Crear el menu
            var ins = conn.CreateCommand();
            ins.CommandText = "INSERT INTO Menus(UserName,Fecha) VALUES(@u,@f); SELECT last_insert_rowid();";
            ins.Parameters.AddWithValue("@u", userName);
            ins.Parameters.AddWithValue("@f", fecha);
            int menuId = (int)(long)ins.ExecuteScalar()!;
            menusCreados++;

            // Insertar items
            foreach (var item in kv.Value)
            {
                var ic = conn.CreateCommand();
                ic.CommandText = "INSERT INTO ItemsMenu(MenuId,NombreAlimento,CantidadGramos,Calorias,Proteinas,Carbohidratos,Grasas) VALUES(@mid,@n,@cant,@cal,@prot,@carb,@gras);";
                ic.Parameters.AddWithValue("@mid",  menuId);
                ic.Parameters.AddWithValue("@n",    item.n);
                ic.Parameters.AddWithValue("@cant", item.cant);
                ic.Parameters.AddWithValue("@cal",  item.cal);
                ic.Parameters.AddWithValue("@prot", item.prot);
                ic.Parameters.AddWithValue("@carb", item.carb);
                ic.Parameters.AddWithValue("@gras", item.gras);
                ic.ExecuteNonQuery();
                itemsInsertados++;
            }
        }

        Console.WriteLine($"✅ Seed completado: {menusCreados} menus, {itemsInsertados} items insertados.");
        Console.WriteLine("Puedes borrar este archivo SeedMenus.cs ahora.");
    }
}