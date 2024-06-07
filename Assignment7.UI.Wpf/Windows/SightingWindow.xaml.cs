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
        /// The map manager for handling map-related operations.
        /// </summary>
        private MapManager _mapManager;

        /// <summary>
        /// The animal manager for handling animal-related operations.
        /// </summary>
        private AnimalManager _animalManager;

        /// <summary>
        /// The sighting object.
        /// </summary>
        private Sighting _sighting;


        /// <summary>
        /// Indicates whether the sighting is being edited.
        /// </summary>
        private bool _editSighting = false;
        #endregion
        #region Properties

        /// <summary>
        /// Gets the map manager.
        /// </summary>
        public MapManager MapManager
        {
            get => _mapManager;
            private protected set => _mapManager = value;
        }

        /// <summary>
        /// Gets the animal manager.
        /// </summary>
        public AnimalManager AnimalManager
        {
            get => _animalManager;
            private protected set => _animalManager = value;
        }

        /// <summary>
        /// Gets or sets the sighting object.
        /// </summary>
        public Sighting Sighting
        {
            get => _sighting;
            set => _sighting = value;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the sighting is being edited.
        /// </summary>
        public bool EditSighting
        {
            get => _editSighting;
            set => _editSighting = value;
        }
        #endregion
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SightingWindow"/> class.
        /// </summary>
        public SightingWindow() : this(new Sighting())
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SightingWindow"/> class.
        /// </summary>
        /// <param name="sighting">The sighting object.</param>
        public SightingWindow(Sighting sighting) : this(sighting, new AnimalManager(), false)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SightingWindow"/> class.
        /// </summary>
        /// <param name="sighting">The sighting object.</param>
        /// <param name="animalManager">The animal manager.</param>
        /// <param name="editSighting">Indicates whether the sighting is being edited.</param>
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
        /// Initializes the GUI elements.
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
        /// Loads the sighting data into the GUI elements.
        /// </summary>
        private void LoadSighting()
        {
            // Get the index of the animal in the list of animals and map it to the combobox
            try
            {
                int animalIndex = AnimalManager.ListOfAnimals.Select((animal, index) => new { Animal = animal, Index = index })
                                              .FirstOrDefault(item => item.Animal.Name == Sighting.Animal.Name)?.Index ?? -1;

                if (animalIndex != -1)
                {
                    cmbAnimal.SelectedIndex = animalIndex;
                }
                else
                {
                    throw new InvalidOperationException("Animal name in the sighting does not exist in the list of animals. Maybe the animal name was changed after sighting was added? You can update the sighting and save a new animal name.");
                }

                txtCount.Value = Sighting.Count;
                dateWhen.Value = ((DateTime)Sighting.When.DateTime);
                txtDescription.Text = Sighting.Description.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Initializes the text object.
        /// </summary>
        private void InitTextObject()
        {
            txtCount.Minimum = 1;
            txtCount.Value = 1;
        }

        /// <summary>
        /// Initializes the date object.
        /// </summary>
        private void InitDateObject()
        {
            dateWhen.Value = DateTime.Now;
        }

        /// <summary>
        /// Initializes the combobox.
        /// </summary>
        private void InitComboBox()
        {
            cmbAnimal.Items.Clear();

            cmbAnimal.DisplayMemberPath = "Name";
            cmbAnimal.ItemsSource = AnimalManager.ListOfAnimals; //.OrderBy(animal => animal.Name); //Causes problems when setting index
            cmbAnimal.SelectedIndex = 0;
        }

        /// <summary>
        /// Initializes the map.
        /// </summary>
        private void InitMap()
        {
            MapManager.Map.CreateMapAsync();
            MapManager.MapControl.MapControlObj.Map = MapManager.Map.MapObj;
            contentMap.Content = MapManager.MapControl.MapControlObj;
        }

        /// <summary>
        /// Handles the click event of the save button.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="e">The event arguments.</param>
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Sighting.Animal = (Animal)cmbAnimal.SelectedItem;
            Sighting.When = new CustomDateTime((DateTime)dateWhen.Value);
            Sighting.Location = new Assignment7.Classes.Location(MapManager.Map.CurrentPosition);
            Sighting.Count = (int)txtCount.Value;
            Sighting.Description = new Description(txtDescription.Text);

            DialogResult = true;
            this.Close();
        }

        /// <summary>
        /// Handles the click event of the cancel button.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="e">The event arguments.</param>
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Handles the mouse down event of the window.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="e">The event arguments.</param>
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
