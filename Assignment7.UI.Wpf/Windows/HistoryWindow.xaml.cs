using Assignment7.Classes;
using Assignment7.Enums;
using Assignment7.UI.Wpf.Classes;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using static Assignment7.Helpers.EnumHelper;

namespace Assignment7.UI.Wpf.Windows
{
    /// <summary>
    /// Interaction logic for HistoryWindow.xaml
    /// </summary>
    public partial class HistoryWindow : Window
    {
        #region Fields

        /// <summary>
        /// The print manager for printing functionality.
        /// </summary>
        private PrintManager _printManager;

        /// <summary>
        /// The sighting manager for managing sightings.
        /// </summary>
        private SightingManager _sightingManager;

        /// <summary>
        /// The animal manager for managing animals.
        /// </summary>
        private AnimalManager _animalManager;

        /// <summary>
        /// The currently selected sighting.
        /// </summary>
        private Sighting _selectedSighting;

        /// <summary>
        /// Indicates whether a change has been detected.
        /// </summary>
        private bool _changeDetected = false;
        #endregion
        #region Properties

        /// <summary>
        /// Gets the animal manager.
        /// </summary>
        public AnimalManager AnimalManager
        {
            get => _animalManager;
        }

        /// <summary>
        /// Gets the sighting manager.
        /// </summary>
        public SightingManager SightingManager
        {
            get => _sightingManager;
        }

        /// <summary>
        /// Gets or sets the selected sighting.
        /// </summary>
        public Sighting SelectedSighting
        {
            get => _selectedSighting;
            set => _selectedSighting = value;
        }

        /// <summary>
        /// Gets the print manager.
        /// </summary>
        public PrintManager PrintManager
        {
            get => _printManager;
        }

        /// <summary>
        /// Gets or sets a value indicating whether a change has been detected.
        /// </summary>
        public bool ChangeDetected
        {
            get => _changeDetected;
            set => _changeDetected = value;
        }
        #endregion
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="HistoryWindow"/> class.
        /// </summary>
        /// <param name="sightingManager">The sighting manager.</param>
        /// <param name="animalManager">The animal manager.</param>
        public HistoryWindow(SightingManager sightingManager, AnimalManager animalManager)
        {
            InitializeComponent();

            _sightingManager = sightingManager;
            _animalManager = animalManager;
            _printManager = new PrintManager();

            InitGUI();
        }
        #endregion
        #region Private Methods

        /// <summary>
        /// Initializes the GUI.
        /// </summary>
        private void InitGUI()
        {
            InitComboBox();

            InitListView();
        }

        /// <summary>
        /// Initializes the animal type combo box.
        /// </summary>
        private void InitComboBox()
        {
            cmbAnimalType.Items.Clear();
            string[] descriptions = GetDescriptions<AnimalType>();
            cmbAnimalType.ItemsSource = descriptions;
            cmbAnimalType.SelectedIndex = (int)AnimalType.All;
        }

        /// <summary>
        /// Initializes the list view.
        /// </summary>
        private void InitListView()
        {
            GridViewControl.Columns.Clear();

            // Sort the ListOfSightings based on date and time
            var sortedSightings = SightingManager.ListOfSightings.OrderByDescending(s => s.When.DateTime.Date).ThenByDescending(s => s.When.DateTime.TimeOfDay).ThenBy(s => s.Animal.Name).ThenBy(s => s.Count);

            lstSightings.ItemsSource = sortedSightings;

            GridViewColumn column0 = new GridViewColumn();
            column0.Header = "Date";
            column0.DisplayMemberBinding = new Binding("When.DateTime") { StringFormat = "yyyy-MM-dd" };
            column0.Width = 150;
            GridViewControl.Columns.Add(column0);

            GridViewColumn column00 = new GridViewColumn();
            column00.Header = "Time";
            column00.DisplayMemberBinding = new Binding("When.DateTime") { StringFormat = "HH\\:mm" };
            column00.Width = 150;
            GridViewControl.Columns.Add(column00);

            GridViewColumn column = new GridViewColumn();
            column.Header = "Name";
            column.DisplayMemberBinding = new Binding("Animal.Name");
            column.Width = 150;
            GridViewControl.Columns.Add(column);

            GridViewColumn column11 = new GridViewColumn();
            column11.Header = "Count";
            column11.DisplayMemberBinding = new Binding("Count");
            column11.Width = 150;
            GridViewControl.Columns.Add(column11);

            GridViewColumn column2 = new GridViewColumn();
            column2.Header = "Type";
            column2.DisplayMemberBinding = new Binding("Animal.AnimalType");
            column2.Width = 150;
            GridViewControl.Columns.Add(column2);
        }

        /// <summary>
        /// Filters the list view based on the selected animal type.
        /// </summary>
        private void FilterListOnAnimalType()
        {
            // Filter the ListView based on animal type
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lstSightings.ItemsSource);

            if (view == null)
                return;

            view.Filter = item =>
                {
                    if ((AnimalType)cmbAnimalType.SelectedIndex == AnimalType.All)
                        return true;
                    Sighting sighting = item as Sighting;
                    return sighting.Animal.AnimalType == (AnimalType)cmbAnimalType.SelectedIndex;
                };
        }

        /// <summary>
        /// Filters the list view based on the selected date range.
        /// </summary>
        /// <returns>The filtered collection view.</returns>
        private CollectionView FilterListOnDateRange()
        {
            // Get the selected "From" and "To" dates
            DateTime fromDate = dateFrom.SelectedDate ?? DateTime.MinValue;
            DateTime toDate = dateTo.SelectedDate ?? DateTime.MaxValue;

            // Filter the ListView based on the date range
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lstSightings.ItemsSource);

            if (view == null)
                return null;

            view.Filter = item =>
            {
                Sighting sighting = item as Sighting;
                DateTime sightingDate = sighting.When.DateTime.Date;

                return sightingDate >= fromDate && sightingDate <= toDate;
            };

            return view;
        }

        /// <summary>
        /// Handles the SelectedDateChanged event of the dateFrom control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void dateFrom_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            FilterListOnDateRange();
        }

        /// <summary>
        /// Handles the SelectedDateChanged event of the dateTo control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void dateTo_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            FilterListOnDateRange();
        }

        /// <summary>
        /// Handles the SelectionChanged event of the cmbAnimalType control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void cmbAnimalType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FilterListOnAnimalType();
        }

        /// <summary>
        /// Handles the MouseDoubleClick event of the lstSightings control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void lstSightings_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (lstSightings.SelectedItem != null)
            {
                Sighting selectedSighting = (Sighting)lstSightings.SelectedItem;

                SelectedSighting = selectedSighting;
            }

            Sighting sightingCopy = new Sighting((Sighting)lstSightings.SelectedItem);

            AnimalManager animalManagerCopy = AnimalManager.DeepCopy();

            SightingWindow window = new SightingWindow(sightingCopy, animalManagerCopy, true);
            window.ShowDialog();

            if (window.DialogResult.HasValue && window.DialogResult.Value)
            {
                ChangeDetected = true;
                SelectedSighting.When.DateTime = window.Sighting.When.DateTime;
                SelectedSighting.Count = window.Sighting.Count;
                SelectedSighting.Description = window.Sighting.Description;
                SelectedSighting.Location = window.Sighting.Location;
                SelectedSighting.Animal = window.Sighting.Animal;

                SightingManager.EditSighting(window.Sighting);
                lstSightings.Items.Refresh();
            }
            else
            {
                //Do nothing...
            }
        }

        /// <summary>
        /// Handles the Click event of the btnClose control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            if (ChangeDetected)
            {
                // Show a confirmation dialog box
                MessageBoxResult result = MessageBox.Show("Do you want to save changes?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);

                // Check the user's response
                if (result == MessageBoxResult.Yes)
                {
                    DialogResult = true;
                    this.Close();
                }
                else
                {
                    this.Close();
                }
            }
            else
            {
                this.Close();
            }
        }

        /// <summary>
        /// Handles the MouseDown event of the Window control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                DragMove();
        }

        /// <summary>
        /// Handles the Click event of the btnPrint control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void btnPrint_Click(object sender, RoutedEventArgs e)
        {
            var filteredList = FilterListOnDateRange();

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

            // Print
            PrintManager.PrintFromCurrentSightingsList(doc);

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

        /// <summary>
        /// Handles the Click event of the btnDeleteSighting control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void btnDeleteSighting_Click(object sender, RoutedEventArgs e)
        {
            SightingManager.DeleteSighting(SelectedSighting);
            InitListView();
            ChangeDetected = true;
        }

        /// <summary>
        /// Handles the MouseUp event of the lstSightings control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void lstSightings_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (lstSightings.SelectedItem != null)
            {
                Sighting selectedSighting = (Sighting)lstSightings.SelectedItem;

                SelectedSighting = selectedSighting;
            }
        }
        #endregion
    }
}
