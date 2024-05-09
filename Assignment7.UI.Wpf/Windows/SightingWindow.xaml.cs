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
using System.Xml.Linq;
using Assignment7;
using Assignment7.Classes;
using Assignment7.Enums;
using Assignment7.Structs;
using Xceed.Wpf.Toolkit;

namespace Assignment7.UI.Wpf.Windows
{
    /// <summary>
    /// Interaction logic for SightingWindow.xaml
    /// </summary>
    public partial class SightingWindow : Window
    {
        #region Fields

        /// <summary>
        /// 
        /// </summary>
        private MapManager _mapManager;

        /// <summary>
        /// 
        /// </summary>
        private AnimalManager _animalManager;

        private Sighting _sighting;
        #endregion
        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public MapManager MapManager
        {
            get => _mapManager;
            private protected set => _mapManager = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public AnimalManager AnimalManager
        {
            get => _animalManager;
            private protected set => _animalManager = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public Sighting Sighting
        {
            get => _sighting;
            set => _sighting = value;
        }
        #endregion
        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        public SightingWindow() : this(new Sighting())
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sighting"></param>
        public SightingWindow(Sighting sighting) : this(sighting, new AnimalManager())
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public SightingWindow(Sighting sighting, AnimalManager animalManager)
        {
            InitializeComponent();

            AnimalManager = animalManager;
            Sighting = sighting;
            MapManager = new MapManager();

            InitGUI();
        }
        #endregion
        #region Private Methods

        /// <summary>
        /// 
        /// </summary>
        private void InitGUI()
        {
            InitMap();

            InitComboBox();

            dateWhen.Value = DateTime.Now;

            txtCount.Minimum = 1;
            txtCount.Value = 1;
        }

        /// <summary>
        /// 
        /// </summary>
        private void InitComboBox()
        {
            cmbAnimal.Items.Clear();

            cmbAnimal.DisplayMemberPath = "Name";
            cmbAnimal.ItemsSource = AnimalManager.ListOfAnimals;
            cmbAnimal.SelectedIndex = 0;
        }

        /// <summary>
        /// 
        /// </summary>
        private void InitMap()
        {
            MapManager.Map.CreateMapAsync();
            MapManager.MapControl.MapControlObj.Map = MapManager.Map.MapObj;
            contentMap.Content = MapManager.MapControl.MapControlObj;
        }
        #endregion

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Sighting.Animal = (Animal)cmbAnimal.SelectedItem;
            Sighting.Date = new Date((DateTime)dateWhen.Value);
            DateTime now = DateTime.Now;
            TimeSpan ts = (DateTime)dateWhen.Value - now;
            Sighting.Time = new Time(ts); //TODO: This is not a correct implementation.
            Sighting.Location = new Classes.Location(MapManager.Map.CurrentPosition);
            Sighting.Count = (int)txtCount.Value;

            DialogResult = true;
            this.Close();

        }
    }
}
