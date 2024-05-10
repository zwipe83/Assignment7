using Assignment7.Classes;
using Assignment7.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
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
        private SightingManager _sightingManager;

        /// <summary>
        /// 
        /// </summary>
        private AnimalManager _animalManager;
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
            cmbAnimalType.SelectedIndex = (int)AnimalType.Mammal;
        }

        /// <summary>
        /// Init listview
        /// </summary>
        private void InitListView()
        {
            //TODO: Make this more pretty
            lstSightings.ItemsSource = SightingManager.ListOfSightings;

            GridViewColumn column0 = new GridViewColumn();
            column0.Header = "Date";
            column0.DisplayMemberBinding = new Binding("Date.D") { StringFormat = "yyyy-MM-dd" };
            column0.Width = 150;
            GridViewControl.Columns.Add(column0);

            GridViewColumn column00 = new GridViewColumn();
            column00.Header = "Time";
            column00.DisplayMemberBinding = new Binding("Time.T") { StringFormat = "hh\\:mm" };
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

            GridViewColumn column3 = new GridViewColumn();
            column3.Header = "Description";
            column3.DisplayMemberBinding = new Binding("Animal.Description");
            column3.Width = 150;
            GridViewControl.Columns.Add(column3);

        }

        #endregion
        private void FilterListOnAnimalType()
        {
            // Filter the ListView based on animal type
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lstSightings.ItemsSource);

            if (view == null)
                return;

            view.Filter = item =>
                {
                    Sighting sighting = item as Sighting;
                    return sighting.Animal.AnimalType == (AnimalType)cmbAnimalType.SelectedIndex;
                };
        }

        private void FilterListOnDateRange()
        {
            // Get the selected "From" and "To" dates
            DateTime fromDate = dateFrom.SelectedDate ?? DateTime.MinValue;
            DateTime toDate = dateTo.SelectedDate ?? DateTime.MaxValue;

            // Filter the ListView based on the date range
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lstSightings.ItemsSource);

            if (view == null)
                return;

            view.Filter = item =>
            {
                Sighting sighting = item as Sighting;
                DateTime sightingDate = sighting.Date.D;

                return sightingDate >= fromDate && sightingDate <= toDate;
            };
        }

        private void dateFrom_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            FilterListOnDateRange();
        }

        private void dateTo_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            FilterListOnDateRange();
        }

        private void cmbAnimalType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FilterListOnAnimalType();
        }

        private void lstSightings_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Sighting sightingCopy = new Sighting((Sighting)lstSightings.SelectedItem);

            AnimalManager animalManagerCopy = AnimalManager.DeepCopy();

            SightingWindow window = new SightingWindow(sightingCopy, animalManagerCopy, true);
            window.ShowDialog();
        }
    }
}
