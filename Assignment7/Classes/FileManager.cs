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
    public static class FileManager
    {
        #region Public Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sourceFilePath"></param>
        /// <param name="destinationFolderPath"></param>
        /// <returns></returns>
        public static string CopyFile(string sourceFilePath, string destinationFolderPath)
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
        public static void DeleteFile(string filePath)
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
        public static void DeleteFiles(List<string> fileNames, string directoryName)
        {
            string directoryPath = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, directoryName); 

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
        public static void RenameFile(string filePath, string newFileName)
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
        public static string GetExtension(string filePath)
        {
            return System.IO.Path.GetExtension(filePath) ?? string.Empty;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="animalIds"></param>
        /// <returns></returns>
        public static List<string> FindOrphanedFiles(List<AnimalId> animalIds, string searchDirectory)
        {
            List<string> images = GetFilesInDirectory(System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, searchDirectory));

            List<string> ids = [.. animalIds.Select(id => id.ToString())];

            // Strip extensions from list1
            List<string> imagesWithoutExtensions = images.Select(Path.GetFileNameWithoutExtension).ToList();

            var uniqueInList1 = images.Where(file => !ids.Contains(Path.GetFileNameWithoutExtension(file))).ToList();

            var uniqueInList2 = ids.Where(file => !imagesWithoutExtensions.Contains(file)).ToList();

            // Combine both results
            var orphanedFiles = uniqueInList1.Concat(uniqueInList2).ToList();

            return orphanedFiles;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="directoryPath"></param>
        /// <returns></returns>
        public static List<string> GetFilesInDirectory(string directoryPath)
        {
            string[] filePaths = Directory.GetFiles(directoryPath);
            List<string> fileNames = new List<string>(filePaths.Length);

            for (int i = 0; i < filePaths.Length; i++)
            {
                fileNames.Add(Path.GetFileName(filePaths[i]));
            }

            return fileNames;
        }
        #endregion
    }
}