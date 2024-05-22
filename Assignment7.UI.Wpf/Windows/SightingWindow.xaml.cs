using Assignment7.Classes;
using Assignment7.UI.Wpf.Classes;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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

            AnimalManager = animalManager;
            Sighting = sighting;

            EditSighting = editSighting;
            if (EditSighting)
                MapManager = new MapManager(Sighting.Location.WorldPosition);
            else
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

            InitDateObject();

            InitTextObject();

            if (EditSighting)
            {
                LoadSighting();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void LoadSighting()
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
            dateWhen.Value = ((DateTime)Sighting.When.DateTime);
            txtDescription.Text = Sighting.Description.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        private void InitTextObject()
        {
            txtCount.Minimum = 1;
            txtCount.Value = 1;
        }

        /// <summary>
        /// 
        /// </summary>
        private void InitDateObject()
        {
            dateWhen.Value = DateTime.Now;
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
            Sighting.When = new CustomDateTime((DateTime)dateWhen.Value);
            Sighting.Location = new Assignment7.Classes.Location(MapManager.Map.CurrentPosition);
            Sighting.Count = (int)txtCount.Value;
            Sighting.Description.Desc = txtDescription.Text;

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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var dummy = e.OriginalSource.GetType();
            if (e.ChangedButton == MouseButton.Left && e.OriginalSource.GetType() == typeof(Border))
            {
                DragMove();
            }
        }
        #endregion
    }
}
