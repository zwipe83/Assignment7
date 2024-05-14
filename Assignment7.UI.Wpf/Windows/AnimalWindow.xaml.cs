using Assignment7.Classes;
using Assignment7.Enums;
using Assignment7.UI.Wpf.ViewModels;
using Microsoft.Win32;
using System.Windows;
using System.Windows.Input;
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
        /// 
        /// </summary>
        private Animal _animal;

        /// <summary>
        /// 
        /// </summary>
        private FileManager _fileManager;

        /// <summary>
        /// 
        /// </summary>
        private bool _editAnimal;
        #endregion
        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public Animal Animal
        {
            get => _animal;
            protected set => _animal = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public FileManager FileManager
        {
            get => _fileManager;
            protected set => _fileManager = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public bool EditAnimal
        {
            get => _editAnimal;
            set => _editAnimal = value;
        }
        #endregion
        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        /// <param name="animalManager"></param>
        public AnimalWindow() : this(new Animal(), false)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="animalManager"></param>
        /// <param name="animal"></param>
        public AnimalWindow(Animal animal, bool editAnimal)
        {
            InitializeComponent();

            DataContext = new AnimalWindowViewModel();

            FileManager = new FileManager();

            Animal = animal;
            EditAnimal = editAnimal;

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

            if (EditAnimal)
            {
                cmbAnimalType.SelectedIndex = (int)Animal.AnimalType;
                txtName.Text = Animal.Name;
                txtDescription.Text = Animal.Description;

                var viewModel = (AnimalWindowViewModel)DataContext;
                viewModel.ImagePath = @$"{System.IO.Path.Combine(System.IO.Path.Combine(AppDirectory, Animal.Image.Path), $"{Animal.Image.Name}")}";
            }

            txtAnimalId.Text = Animal.AnimalId.ToString();
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
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Animal.AnimalType = (AnimalType)cmbAnimalType.SelectedIndex;
            Animal.Name = txtName.Text;
            Animal.Description = txtDescription.Text;

            DialogResult = true;
            this.Close();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Jpeg files (*.jpg)|*.jpg";
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
        #endregion

    }
}
