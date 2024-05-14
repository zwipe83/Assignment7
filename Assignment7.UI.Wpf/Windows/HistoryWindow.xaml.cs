﻿using Assignment7.Classes;
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
    /// Interaction logic for SightingsWindow.xaml
    /// </summary>
    public partial class HistoryWindow : Window
    {
        #region Fields

        /// <summary>
        /// 
        /// </summary>
        private PrintManager _printManager;

        /// <summary>
        /// 
        /// </summary>
        private SightingManager _sightingManager;

        /// <summary>
        /// 
        /// </summary>
        private AnimalManager _animalManager;

        /// <summary>
        /// 
        /// </summary>
        private Sighting _selectedSighting;
        #endregion
        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public AnimalManager AnimalManager
        {
            get => _animalManager;
        }

        /// <summary>
        /// 
        /// </summary>
        public SightingManager SightingManager
        {
            get => _sightingManager;
        }

        /// <summary>
        /// 
        /// </summary>
        public Sighting SelectedSighting
        {
            get => _selectedSighting;
            set => _selectedSighting = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public PrintManager PrintManager
        {
            get => _printManager;
        }
        #endregion
        #region Constructors

        /// <summary>
        /// 
        /// </summary>
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
        /// 
        /// </summary>
        private void InitGUI()
        {
            InitComboBox();

            InitListView();
        }

        /// <summary>
        /// 
        /// </summary>
        private void InitComboBox()
        {
            cmbAnimalType.Items.Clear();
            string[] descriptions = GetDescriptions<AnimalType>();
            cmbAnimalType.ItemsSource = descriptions;
            cmbAnimalType.SelectedIndex = (int)AnimalType.All;
        }

        /// <summary>
        /// Init listview
        /// </summary>
        private void InitListView()
        {
            //TODO: Make this more pretty
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
        /// 
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
        /// 
        /// </summary>
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
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dateFrom_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            FilterListOnDateRange();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dateTo_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            FilterListOnDateRange();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbAnimalType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FilterListOnAnimalType();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                SelectedSighting.When.DateTime = window.Sighting.When.DateTime;
                SelectedSighting.Count = window.Sighting.Count;
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
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, RoutedEventArgs e)
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                DragMove();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrint_Click(object sender, RoutedEventArgs e)
        {
            var filteredView = FilterListOnDateRange();

            FlowDocument doc = new FlowDocument();
            foreach (var item in filteredView)
            {
                // Add your items to the document
                doc.Blocks.Add(new Paragraph(new Run(item.ToString())));
            }
            PrintManager.PrintFromCurrentSightingsList(doc);
        }
        #endregion

    }
}
