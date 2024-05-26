using System.Collections.ObjectModel;
using System.Text.Json;

namespace Assignment7.Classes
{
    /// <summary>
    /// Represents a data store for saving and reading data to/from a JSON file.
    /// </summary>
    public class DataStore
    {
        //TODO: Add some form of version handler
        #region Public Methods

        /// <summary>
        /// Save the collection to a JSON file.
        /// </summary>
        /// <typeparam name="T">The type of objects in the collection.</typeparam>
        /// <param name="file">The file to save the data to.</param>
        /// <param name="collection">The collection of objects to save.</param>
        public void SaveToJsonFile<T>(File file, ObservableCollection<T> collection)
        {
            Directory.CreateDirectory(file.Path);
            string fullPath = Path.Combine(file.Path, file.Name);
            string json = JsonSerializer.Serialize(collection);
            System.IO.File.WriteAllText(fullPath, json);
        }

        /// <summary>
        /// Read data from a JSON file and populate the collection.
        /// </summary>
        /// <typeparam name="T">The type of objects in the collection.</typeparam>
        /// <param name="file">The file to read the data from.</param>
        /// <param name="collection">The collection to populate with the read data.</param>
        public void ReadFromJsonFile<T>(File file, ObservableCollection<T> collection)
        {
            string fullPath = Path.Combine(file.Path, file.Name);
            if (System.IO.File.Exists(fullPath))
            {
                string json = System.IO.File.ReadAllText(fullPath);

                if (json.Length <= 0)
                {
                    return;
                }

                var deserializedList = JsonSerializer.Deserialize<List<T>>(json);
                foreach (var obj in deserializedList)
                {
                    collection.Add(obj);
                }
            }
        }
        #endregion
    }
}
