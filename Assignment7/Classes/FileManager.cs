/// <summary>
/// Filename: FileManager.cs
/// Created on: 2024-05-05 00:00:00
/// Author: Samuel Jeffman
/// </summary>
/// 

namespace Assignment7.Classes
{
    /// <summary>
    /// 
    /// </summary>
    public class FileManager
    {
        #region Public Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sourceFilePath"></param>
        /// <param name="destinationFolderPath"></param>
        /// <returns></returns>
        public string CopyFile(string sourceFilePath, string destinationFolderPath)
        {
            string fileName = Path.GetFileName(sourceFilePath);

            string destinationFilePath = Path.Combine(destinationFolderPath, fileName);

            // Create the destination folder if it doesn't exist
            var di = Directory.CreateDirectory(destinationFolderPath);

            System.IO.File.Copy(sourceFilePath, destinationFilePath, true);

            return destinationFilePath;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        public void DeleteFile(string filePath)
        {
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileNames"></param>
        public void DeleteFiles(List<string> fileNames, string directoryName)
        {
            string directoryPath = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, directoryName); // Provide the directory path where the files are located

            foreach (string fileName in fileNames)
            {
                string filePath = Path.Combine(directoryPath, fileName);

                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
                else
                {
                    //Nothing.
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="newFileName"></param>
        public void RenameFile(string filePath, string newFileName)
        {
            try
            {
                // Get the directory path of the file
                string directoryPath = Path.GetDirectoryName(filePath);

                // Create the new file path by combining the directory path and the new file name
                string newFilePath = Path.Combine(directoryPath, newFileName);

                // Rename the file
                System.IO.File.Move(filePath, newFilePath, true); //FIXED: Handle exception if file is open by another process
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public string GetExtension(string filePath)
        {
            return System.IO.Path.GetExtension(filePath) ?? string.Empty;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="animalIds"></param>
        /// <returns></returns>
        public List<string> FindOrphanedFiles(List<AnimalId> animalIds, string searchDirectory)
        {
            string[] images = GetFilesInDirectory(System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, searchDirectory));

            List<string> orphanedImages = new List<string>();

            foreach (var item in images)
            {
                string name = item.Split('.')[0];
                foreach (var item1 in animalIds)
                {
                    string id = item1.Id.ToString();
                    if (name == id)
                    {
                        break;
                    }
                    else
                    {
                        if (!orphanedImages.Any(a => a == item))
                            orphanedImages.Add(item);
                    }
                }
            }

            return orphanedImages;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="directoryPath"></param>
        /// <returns></returns>
        public string[] GetFilesInDirectory(string directoryPath)
        {
            string[] filePaths = Directory.GetFiles(directoryPath);
            string[] fileNames = new string[filePaths.Length];

            for (int i = 0; i < filePaths.Length; i++)
            {
                fileNames[i] = Path.GetFileName(filePaths[i]);
            }

            return fileNames;
        }
        #endregion
    }
}