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
using Assignment7.UI;
using Assignment7.Enums;
using static Assignment7.Helpers.EnumHelper;
using Assignment7.Classes;
using Microsoft.Win32;
using static Assignment7.UI.Wpf.MainWindow;
using Assignment7.UI.Wpf.ViewModels;

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
        private AnimalManager _animalManager;

        /// <summary>
        /// 
        /// </summary>
        private Animal _animal;

        /// <summary>
        /// 
        /// </summary>
        private FileManager _fileManager;
        #endregion
        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public AnimalManager AnimalManager
        {
            get => _animalManager;
            protected set => _animalManager = value;
        }

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
        #endregion
        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        /// <param name="animalManager"></param>
        public AnimalWindow(AnimalManager animalManager)
        {
            InitializeComponent();

            DataContext = new AnimalWindowViewModel();

            AnimalManager = animalManager;
            FileManager = new FileManager();
            Animal = new Animal();

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
            AnimalManager.AddAnimal(Animal);
            DialogResult = true;
            this.Close();
        }
        #endregion

        private void btnSelectImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Jpeg files (*.jpg)|*.jpg";
            if (openFileDialog.ShowDialog() == true)
            { 
                string filePath = FileManager.CopyFile(openFileDialog.FileName, ImagesPath);
                string extension = System.IO.Path.GetExtension(filePath);
                string newFileName = $"{Animal.Id}{extension}";

                Animal.Image.Path = ImagesPath;
                Animal.Image.Name = newFileName;

                FileManager.RenameFile(filePath, $"{Animal.Image.Name}");


                var viewModel = (AnimalWindowViewModel)DataContext;
                viewModel.ImagePath = @$"{System.IO.Path.Combine(ImagesPath,$"{Animal.Image.Name}")}";
            }
        }
    }
}
