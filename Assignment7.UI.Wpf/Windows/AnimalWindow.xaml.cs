using Assignment7.Classes;
using Assignment7.Enums;
using Assignment7.UI.Wpf.ViewModels;
using Microsoft.Win32;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using static Assignment7.Helpers.EnumHelper;
using static Assignment7.UI.Wpf.MainWindow;

namespace Assignment7.UI.Wpf.Windows
{
    /// <summary>
    /// Interaction logic for AnimalWindow.xaml
    /// </summary>
    public partial class AnimalWindow : Window
    {
        #region Fields

        /// <summary>
        /// The animal object associated with the window.
        /// </summary>
        private Animal _animal;

        /// <summary>
        /// Indicates whether the animal is being edited.
        /// </summary>
        private bool _editAnimal;
        #endregion
        #region Properties

        /// <summary>
        /// Gets or sets the animal object associated with the window.
        /// </summary>
        public Animal Animal
        {
            get => _animal;
            protected set => _animal = value;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the animal is being edited.
        /// </summary>
        public bool EditAnimal
        {
            get => _editAnimal;
            set => _editAnimal = value;
        }
        #endregion
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AnimalWindow"/> class.
        /// </summary>
        public AnimalWindow() : this(new Animal(), false)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AnimalWindow"/> class.
        /// </summary>
        /// <param name="animal">The animal object to be displayed in the window.</param>
        /// <param name="editAnimal">Indicates whether the animal is being edited.</param>
        public AnimalWindow(Animal animal, bool editAnimal)
        {
            InitializeComponent();

            DataContext = new AnimalWindowViewModel();

            Animal = animal;
            EditAnimal = editAnimal;

            InitGUI();
        }
        #endregion
        #region Private Methods

        /// <summary>
        /// Initializes the GUI elements of the window.
        /// </summary>
        private void InitGUI()
        {
            InitComboBox();

            if (EditAnimal)
            {
                LoadAnimal();
            }

            InitAnimalId();

            txtName.Focus();
            txtName.Select(0, txtName.Text.Length);
        }

        /// <summary>
        /// Initializes the animal ID text box.
        /// </summary>
        private void InitAnimalId()
        {
            txtAnimalId.Text = Animal.AnimalId.ToString();
        }

        /// <summary>
        /// Loads the animal data into the window controls.
        /// </summary>
        private void LoadAnimal()
        {
            cmbAnimalType.SelectedIndex = (int)Animal.AnimalType;
            txtName.Text = Animal.Name;
            txtDescription.Text = Animal.Description;

            var viewModel = (AnimalWindowViewModel)DataContext;
            viewModel.ImagePath = @$"{System.IO.Path.Combine(System.IO.Path.Combine(AppDirectory, Animal.Image.Path), $"{Animal.Image.Name}")}";
        }

        /// <summary>
        /// Initializes the animal type combo box.
        /// </summary>
        private void InitComboBox()
        {
            cmbAnimalType.Items.Clear();
            string[] descriptions = GetDescriptions<AnimalType>();
            cmbAnimalType.ItemsSource = descriptions;
            cmbAnimalType.SelectedIndex = (int)AnimalType.Mammal;
        }

        /// <summary>
        /// Handles the click event of the cancel button.
        /// </summary>
        /// <param name="sender">The cancel button.</param>
        /// <param name="e">The event arguments.</param>
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
        }

        /// <summary>
        /// Handles the click event of the save button.
        /// </summary>
        /// <param name="sender">The save button.</param>
        /// <param name="e">The event arguments.</param>
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Animal.AnimalType = (AnimalType)cmbAnimalType.SelectedIndex;
            Animal.Name = txtName.Text;
            Animal.Description = txtDescription.Text;

            DialogResult = true;
            this.Close();
        }

        /// <summary>
        /// Handles the click event of the select image button.
        /// </summary>
        /// <param name="sender">The select image button.</param>
        /// <param name="e">The event arguments.</param>
        private void btnSelectImage_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Jpeg files (*.jpg)|*.jpg|Png files (*.png)|*.png|Bmp files (*.bmp)|*.bmp|All files (*.*)|*.*";
                if (openFileDialog.ShowDialog() == true)
                {
                    string appPath = AppDirectory;
                    Animal.Image.Path = "Images";

                    string filePath = FileManager.CopyFile(openFileDialog.FileName, System.IO.Path.Combine(appPath, Animal.Image.Path));
                    string extension = FileManager.GetExtension(filePath);
                    string newFileName = $"{Animal.AnimalId}{extension}";

                    Animal.Image.Name = newFileName;

                    FileManager.RenameFile(filePath, $"{Animal.Image.Name}");

                    var viewModel = (AnimalWindowViewModel)DataContext;
                    viewModel.ImagePath = @$"{System.IO.Path.Combine(System.IO.Path.Combine(appPath, Animal.Image.Path), $"{Animal.Image.Name}")}";
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show($"{ex.Message} Maybe the file is open in another application?", "Error");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Error");
            }
        }

        /// <summary>
        /// Rotates the animal image by the specified degrees.
        /// </summary>
        /// <param name="degrees">The number of degrees to rotate the image.</param>
        private void RotateImage(int degrees)
        {
            var viewModel = (AnimalWindowViewModel)DataContext;

            BitmapImage bitmapImage = new BitmapImage(new Uri(viewModel.ImagePath));
            Image image = new Image();
            image.Source = bitmapImage;
            image.RenderTransformOrigin = new Point(0.5, 0.5);
            image.RenderTransform = new RotateTransform(degrees);

            imgAnimal.Source = image.Source;
            imgAnimal.RenderTransformOrigin = image.RenderTransformOrigin;
            imgAnimal.RenderTransform = image.RenderTransform;
        }

        /// <summary>
        /// Handles the mouse down event of the window.
        /// </summary>
        /// <param name="sender">The window.</param>
        /// <param name="e">The event arguments.</param>
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                DragMove();
        }

        /// <summary>
        /// Handles the click event of the rotate 90 degrees button.
        /// </summary>
        /// <param name="sender">The rotate 90 degrees button.</param>
        /// <param name="e">The event arguments.</param>
        private void btnRotate90_Click(object sender, RoutedEventArgs e)
        {
            RotateImage(90);
        }

        /// <summary>
        /// Handles the click event of the rotate 180 degrees button.
        /// </summary>
        /// <param name="sender">The rotate 180 degrees button.</param>
        /// <param name="e">The event arguments.</param>
        private void btnRotate180_Click(object sender, RoutedEventArgs e)
        {
            RotateImage(180);
        }

        /// <summary>
        /// Handles the click event of the rotate -90 degrees button.
        /// </summary>
        /// <param name="sender">The rotate -90 degrees button.</param>
        /// <param name="e">The event arguments.</param>
        private void btnRotateNeg90_Click(object sender, RoutedEventArgs e)
        {
            RotateImage(-90);
        }

        /// <summary>
        /// Handles the click event of the rotate 0 degrees button.
        /// </summary>
        /// <param name="sender">The rotate 0 degrees button.</param>
        /// <param name="e">The event arguments.</param>
        private void btnRotateZero_Click(object sender, RoutedEventArgs e)
        {
            RotateImage(0);
        }
        #endregion
    }
}
