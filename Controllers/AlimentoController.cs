using System.Collections.Generic;
using System.IO;
using NutricionApp.Controllers.Abstractions;
using NutricionApp.Models;

namespace NutricionApp.Controllers
{
    /// <summary>
    /// Provides operations to manage a catalog of food items, including loading from and persisting to a CSV file.
    /// </summary>
    /// <remarks>The controller is initialized with the path to a CSV file containing food data. All
    /// modifications to the catalog, such as adding or removing items, are immediately saved to the specified file.
    /// This class is not thread-safe; concurrent access should be managed externally if used in multi-threaded
    /// scenarios.</remarks>
    public class AlimentoController : IAlimentoController
    {
        private readonly List<Alimento> _alimentos;
        private readonly string _filePath;

        /// <summary>
        /// Initializes a new instance of the AlimentoController class using the specified file path to load alimento
        /// data.
        /// </summary>
        /// <remarks>The constructor loads alimento data from the specified file path when the controller
        /// is created. Ensure that the file exists and is accessible to avoid initialization errors.</remarks>
        /// <param name="filePath">The path to the file containing the alimento data. This parameter cannot be null or empty.</param>
        public AlimentoController(string filePath)
        {
            _filePath  = filePath;
            _alimentos = LoadAlimentos();
        }

        /// <summary>
        /// Retrieves a list of all available food items.
        /// </summary>
        /// <returns>A list of <see cref="Alimento"/> objects representing all food items. The list will be empty if no food
        /// items are available.</returns>
        public List<Alimento> ObtenerTodos()
        {
            return _alimentos;
        }

        /// <summary>
        /// Adds a food item to the collection and saves the updated list to persistent storage.
        /// </summary>
        /// <remarks>This method updates the internal list of food items and immediately persists the
        /// changes. If the same food item is added multiple times, it will appear multiple times in the
        /// collection.</remarks>
        /// <param name="alimento">The food item to add to the collection. Cannot be null.</param>
        public void Agregar(Alimento alimento)
        {
            _alimentos.Add(alimento);
            SaveAlimentos();
        }

        /// <summary>
        /// Removes the item at the specified index from the collection of alimentos.
        /// </summary>
        /// <remarks>This method updates the underlying collection and persists the changes. If the index
        /// is out of range, the method does nothing.</remarks>
        /// <param name="indice">The zero-based index of the item to remove. Must be within the range of the collection; otherwise, no action
        /// is taken.</param>
        public void Eliminar(int indice)
        {
            if (indice >= 0 && indice < _alimentos.Count)
            {
                _alimentos.RemoveAt(indice);
                SaveAlimentos();
            }
        }

 
        private List<Alimento> LoadAlimentos()
        {
            var lista = new List<Alimento>();

            if (!File.Exists(_filePath))
                return lista;

            var lines = File.ReadAllLines(_filePath);

            for (int i = 1; i < lines.Length; i++)
            {
                var parts = lines[i].Split(',');
                if (parts.Length >= 6)
                    lista.Add(new Alimento(parts));
            }

            return lista;
        }

     
        private void SaveAlimentos()
        {
            var lines = File.Exists(_filePath)
                ? File.ReadAllLines(_filePath)
                : new string[0];

            string header = lines.Length > 0 ? lines[0] : "Nombre,Calorias,Proteinas,Carbohidratos,Grasas,Porcion";

            var rows = new List<string> { header };

            foreach (var a in _alimentos)
                rows.Add(a.ToCsv());

            File.WriteAllLines(_filePath, rows);
        }
    }
}
