/// <summary>
/// Filename: PrintManager.cs
/// Created on: 2024-05-05 00:00:00
/// Author: Samuel Jeffman
/// </summary>
/// 

using Assignment7.Classes;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
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

        /// <summary>
        /// Creates a FlowDocument based on the provided filtered list.
        /// </summary>
        /// <param name="filteredList">The filtered list of sightings.</param>
        /// <returns>The created FlowDocument.</returns>
        public FlowDocument CreateDocument(CollectionView filteredList)
        {
            // Create a new FlowDocument
            FlowDocument doc = new FlowDocument();
            Table table = new Table();

            CreateColumns(table);

            TableRowGroup trg = CreateTableRowGroup(table);

            CreateHeaders(trg);

            // Add rows to the TableRowGroup
            foreach (Sighting sighting in filteredList)
            {
                TableRow row = new TableRow();
                trg.Rows.Add(row);

                row.Cells.Add(new TableCell(new Paragraph(new Run(sighting.When.ToString()))));
                row.Cells.Add(new TableCell(new Paragraph(new Run(sighting.Animal.Name.ToString()))));
                row.Cells.Add(new TableCell(new Paragraph(new Run(sighting.Count.ToString()))));
                row.Cells.Add(new TableCell(new Paragraph(new Run(sighting.Description.ToString()))));
            }

            // Add the table to the FlowDocument
            doc.Blocks.Add(table);

            SetPageProperties(doc);

            return doc;

            #region Local Methods
            static void CreateColumns(Table table)
            {
                //Create columns
                TableColumn column1 = new TableColumn();
                column1.Width = new GridLength(150);
                table.Columns.Add(column1);

                TableColumn column2 = new TableColumn();
                column2.Width = new GridLength(150);
                table.Columns.Add(column2);

                TableColumn column3 = new TableColumn();
                column3.Width = new GridLength(50);
                table.Columns.Add(column3);

                TableColumn column4 = new TableColumn();
                table.Columns.Add(column4);
            }

            static TableRowGroup CreateTableRowGroup(Table table)
            {
                // Create and add a TableRowGroup to hold the rows
                TableRowGroup trg = new TableRowGroup();
                table.RowGroups.Add(trg);
                return trg;
            }

            static void CreateHeaders(TableRowGroup trg)
            {
                //Headers
                TableRow header = new TableRow();
                trg.Rows.Add(header);

                header.Cells.Add(new TableCell(new Paragraph(new Run("Date"))));
                header.Cells.Add(new TableCell(new Paragraph(new Run("Name"))));
                header.Cells.Add(new TableCell(new Paragraph(new Run("Count"))));
                header.Cells.Add(new TableCell(new Paragraph(new Run("Description"))));
            }

            static void SetPageProperties(FlowDocument doc)
            {
                // Set the page size to A4
                doc.PageWidth = 793.92;
                doc.PageHeight = 1122.24;

                // Set the page margins
                doc.PagePadding = new Thickness(50);

                // Set the content size to match the page size
                doc.ColumnWidth = double.PositiveInfinity;
            }
            #endregion
        }
        #endregion
    }
}