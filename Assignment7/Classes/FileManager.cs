/// <summary>
/// Filename: FileManager.cs
/// Created on: 2024-05-05 00:00:00
/// Author: Samuel Jeffman
/// </summary>
/// 

namespace Assignment7.Classes
{
    public class FileManager
    {
        private File _file;

        public void SaveSightingsToJsonFile()
        {
            throw new System.NotImplementedException();
        }

        public void ReadSightingsFromJsonFile()
        {
            throw new System.NotImplementedException();
        }

        public void ReadAnimalsFromJsonFile()
        {
            throw new System.NotImplementedException();
        }

        public void SaveAnimalsToJsonFile()
        {
            throw new System.NotImplementedException();
        }

        public string CopyFile(string sourceFilePath, string destinationFolderPath)
        {
            string fileName = Path.GetFileName(sourceFilePath);
            string destinationFilePath = Path.Combine(destinationFolderPath, fileName);

            // Create the destination folder if it doesn't exist
            Directory.CreateDirectory(destinationFolderPath);

            System.IO.File.Copy(sourceFilePath, destinationFilePath, true);

            return destinationFilePath;
        }

        public void DeleteFile()
        {
            throw new System.NotImplementedException();
        }

        public void RenameFile(string filePath, string newFileName)
        {
            // Get the directory path of the file
            string directoryPath = Path.GetDirectoryName(filePath);

            // Create the new file path by combining the directory path and the new file name
            string newFilePath = Path.Combine(directoryPath, newFileName);

            // Rename the file
            System.IO.File.Move(filePath, newFilePath, true);
        }

    }
}