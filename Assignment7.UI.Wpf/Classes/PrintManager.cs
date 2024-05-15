/// <summary>
/// Filename: PrintManager.cs
/// Created on: 2024-05-05 00:00:00
/// Author: Samuel Jeffman
/// </summary>
/// 

using System.Windows.Controls;
using System.Windows.Documents;


namespace Assignment7.UI.Wpf.Classes
{
    public class PrintManager
    {
        #region Public Methods

        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="System.NotImplementedException"></exception>
        public void PrintFromJsonFile()
        {
            throw new System.NotImplementedException(); //TODO: Implement this
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="doc"></param>
        public void PrintFromCurrentSightingsList(FlowDocument doc)
        {
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                printDialog.PrintDocument(((IDocumentPaginatorSource)doc).DocumentPaginator, "Filtered Collection");
            }
        }
        #endregion
    }
}