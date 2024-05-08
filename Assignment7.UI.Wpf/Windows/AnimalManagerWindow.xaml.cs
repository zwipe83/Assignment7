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
using Assignment7.Classes;
using Assignment7.Enums;

namespace Assignment7.UI.Wpf.Windows
{
    /// <summary>
    /// Interaction logic for AnimalManagerWindow.xaml
    /// </summary>
    public partial class AnimalManagerWindow : Window
    {
        #region Fields
        private AnimalManager _animalManager;
        private Animal _selectedAnimal;
        #endregion
        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public AnimalManager AnimalManager
        {
            get => _animalManager;
            private protected set => _animalManager = value;
        }

        private Animal SelectedAnimal
        {
            get => _selectedAnimal;
            set => _selectedAnimal = value;
        }
        #endregion
        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        public AnimalManagerWindow(AnimalManager animalManager)
        {
            InitializeComponent();

            this._animalManager = animalManager;

            InitGUI();
        }
        #endregion
        #region Private Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddAnimal_Click(object sender, RoutedEventArgs e)
        {
            AnimalWindow window = new AnimalWindow();
            window.ShowDialog();

            if(window.DialogResult.HasValue && window.DialogResult.Value)
            {
                AnimalManager.AddAnimal(window.Animal);
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
        private void btnEditAnimal_Click(object sender, RoutedEventArgs e)
        {
            Animal animalCopy = new Animal(SelectedAnimal);
            AnimalWindow window = new AnimalWindow(animalCopy, true);

            window.ShowDialog();

            if (window.DialogResult.HasValue && window.DialogResult.Value)
            {
                SelectedAnimal.Id = window.Animal.Id;
                SelectedAnimal.Name = window.Animal.Name;
                SelectedAnimal.Description = window.Animal.Description;
                SelectedAnimal.Image = window.Animal.Image;
                SelectedAnimal.AnimalType = window.Animal.AnimalType;
                AnimalManager.ChangeAnimal(SelectedAnimal);
                lstAnimals.Items.Refresh();
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
            DialogResult = true;
            this.Close();
        }

        /// <summary>
        /// Init GUI
        /// </summary>
        private void InitGUI()
        {
            InitListView();
        }

        /// <summary>
        /// Init listview
        /// </summary>
        private void InitListView()
        {
            //TODO: Make this more pretty
            lstAnimals.ItemsSource = AnimalManager.ListOfAnimals;   //your query result 
            GridViewColumn column = new GridViewColumn();
            column.Header = "Name";
            column.DisplayMemberBinding = new Binding("Name");
            column.Width = 150;
            GridViewControl.Columns.Add(column);
            GridViewColumn column2 = new GridViewColumn();
            column2.Header = "Type";
            column2.DisplayMemberBinding = new Binding("AnimalType");
            column2.Width = 150;
            GridViewControl.Columns.Add(column2);
            GridViewColumn column3 = new GridViewColumn();
            column3.Header = "Description";
            column3.DisplayMemberBinding = new Binding("Description");
            column3.Width = 150;
            GridViewControl.Columns.Add(column3);
        }
        #endregion


        private void lstAnimals_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (lstAnimals.SelectedItem != null)
            {
                Animal selectedAnimal = (Animal)lstAnimals.SelectedItem;
                
                SelectedAnimal = selectedAnimal;
            }

        }

        private void btnDeleteAnimal_Click(object sender, RoutedEventArgs e)
        {
            AnimalManager.DeleteAnimal(SelectedAnimal);
        }
    }
}
