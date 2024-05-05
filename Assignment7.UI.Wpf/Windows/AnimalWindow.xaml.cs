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
        private AnimalManager animalManager;
        #endregion
        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public AnimalManager AnimalManager
        {
            get => animalManager;
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

            this.animalManager = animalManager;

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
            Animal animal = new Animal((AnimalType)cmbAnimalType.SelectedIndex, txtName.Text); //TODO: Add image object
            AnimalManager.AddAnimal(animal);
            DialogResult = true;
            this.Close();
        }
        #endregion
    }
}
