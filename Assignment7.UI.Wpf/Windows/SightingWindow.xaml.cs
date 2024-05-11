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

        /// <summary>
        /// 
        /// </summary>
        private Sighting _sighting;


        /// <summary>
        /// 
        /// </summary>
        private bool _editSighting = false;
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

        /// <summary>
        /// 
        /// </summary>
        public bool EditSighting
        {
            get => _editSighting;
            set => _editSighting = value;
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
        public SightingWindow(Sighting sighting) : this(sighting, new AnimalManager(), false)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public SightingWindow(Sighting sighting, AnimalManager animalManager, bool editSighting)
        {
            InitializeComponent();

            EditSighting = editSighting;
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

            if(EditSighting)
            {
                //FIXED: Get Animal name and map it to the combobox

                int animalIndex = AnimalManager.ListOfAnimals.Select((animal, index) => new { Animal = animal, Index = index })
                                              .FirstOrDefault(item => item.Animal.Name == Sighting.Animal.Name)?.Index ?? -1;

                if (animalIndex != -1)
                {
                    cmbAnimal.SelectedIndex = animalIndex;
                }
                else
                {
                    cmbAnimal.SelectedIndex = 0; //TODO: Maybe exception?
                }

                txtCount.Value = Sighting.Count;
                dateWhen.Value = ((DateTime)Sighting.Date.D).Date.Add((Sighting.Time.T));
            }
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Sighting.Animal = (Animal)cmbAnimal.SelectedItem;
            Sighting.Date = new Date(((DateTime)dateWhen.Value).Date);
            Sighting.Time = new Time(((DateTime)dateWhen.Value).TimeOfDay); //FIXED: This is not a correct implementation.
            Sighting.Location = new Classes.Location(MapManager.Map.CurrentPosition);
            Sighting.Count = (int)txtCount.Value;

            DialogResult = true;
            this.Close();

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
