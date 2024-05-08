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
        /// <param name="taskList"></param>
        public void SaveToJsonFile(File file, ObservableCollection<Animal> animalList)
        {
            string fullPath = Path.Combine(file.Path, file.Name);
            string json = JsonSerializer.Serialize(animalList);
            System.IO.File.WriteAllText(fullPath, json);
        }

        /// <summary>
        /// Read from datastore
        /// </summary>
        /// <param name="file"></param>
        /// <param name="taskList"></param>
        public void ReadFromJsonFile(File file, ObservableCollection<Animal> animalList)
        {
            string fullPath = Path.Combine(file.Path, file.Name);
            if (System.IO.File.Exists(fullPath))
            {
                string json = System.IO.File.ReadAllText(fullPath);
                var deserializedList = JsonSerializer.Deserialize<List<Animal>>(json);
                foreach (var animal in deserializedList)
                {
                    animalList.Add(animal);
                }
            }
        }
    }
}
