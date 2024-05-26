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
    /// <summary>
    /// Represents a manager for printing documents in the WPF application.
    /// </summary>
    public class PrintManager
    {
        #region Public Methods
        /// <summary>
        /// Prints the specified FlowDocument from the current sightings list.
        /// </summary>
        /// <param name="doc">The FlowDocument to be printed.</param>
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