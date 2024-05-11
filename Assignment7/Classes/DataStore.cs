using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Collections.ObjectModel;

namespace Assignment7.Classes
{
    public class DataStore
    {
        //TODO: Add some form of version handler

        /// <summary>
        /// Save to datastore
        /// </summary>
        /// <param name="file"></param>
        /// <param name="collection"></param>
        public void SaveToJsonFile<T>(File file, ObservableCollection<T> collection)
        {
            Directory.CreateDirectory(file.Path);
            string fullPath = Path.Combine(file.Path, file.Name);
            string json = JsonSerializer.Serialize(collection);
            System.IO.File.WriteAllText(fullPath, json);
        }

        /// <summary>
        /// Read from datastore
        /// </summary>
        /// <param name="file"></param>
        /// <param name="collection"></param>
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
    }
}
