/// <summary>
/// Filename: FileManager.cs
/// Created on: 2024-05-05 00:00:00
/// Author: Samuel Jeffman
/// </summary>
/// 

namespace Assignment7.Classes
{
    /// <summary>
    /// Provides file management operations such as copying, deleting, renaming, and retrieving file information.
    /// </summary>
    public static class FileManager
    {
        #region Public Methods
        /// <summary>
        /// Copies a file from the source file path to the destination folder path.
        /// </summary>
        /// <param name="sourceFilePath">The path of the source file.</param>
        /// <param name="destinationFolderPath">The path of the destination folder.</param>
        /// <returns>The path of the copied file in the destination folder.</returns>
        public static string CopyFile(string sourceFilePath, string destinationFolderPath)
        {
            string fileName = Path.GetFileName(sourceFilePath);

            string destinationFilePath = Path.Combine(destinationFolderPath, fileName);

            var di = Directory.CreateDirectory(destinationFolderPath);

            System.IO.File.Copy(sourceFilePath, destinationFilePath, true);

            return destinationFilePath;
        }

        /// <summary>
        /// Deletes a file at the specified file path.
        /// </summary>
        /// <param name="filePath">The path of the file to delete.</param>
        public static void DeleteFile(string filePath)
        {
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }
        }

        /// <summary>
        /// Deletes multiple files with the specified file names in the specified directory.
        /// </summary>
        /// <param name="fileNames">The names of the files to delete.</param>
        /// <param name="directoryName">The name of the directory containing the files.</param>
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
                    // File does not exist, do nothing.
                }
            }
        }

        /// <summary>
        /// Renames a file at the specified file path with the new file name.
        /// </summary>
        /// <param name="filePath">The path of the file to rename.</param>
        /// <param name="newFileName">The new name for the file.</param>
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
        /// Gets the extension of a file at the specified file path.
        /// </summary>
        /// <param name="filePath">The path of the file.</param>
        /// <returns>The extension of the file, or an empty string if the file has no extension.</returns>
        public static string GetExtension(string filePath)
        {
            return System.IO.Path.GetExtension(filePath) ?? string.Empty;
        }

        /// <summary>
        /// Finds orphaned files in the specified search directory that do not have corresponding animal IDs.
        /// </summary>
        /// <param name="animalIds">The list of animal IDs.</param>
        /// <param name="searchDirectory">The directory to search for orphaned files.</param>
        /// <returns>The list of orphaned file names.</returns>
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
        /// Gets the names of all files in the specified directory.
        /// </summary>
        /// <param name="directoryPath">The path of the directory.</param>
        /// <returns>The list of file names in the directory.</returns>
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