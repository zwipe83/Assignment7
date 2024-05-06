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

namespace Assignment7.UI.Wpf.Windows
{
    /// <summary>
    /// Interaction logic for AnimalManagerWindow.xaml
    /// </summary>
    public partial class AnimalManagerWindow : Window
    {
        #region Fields
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
        public AnimalManagerWindow(AnimalManager animalManager)
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
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddAnimal_Click(object sender, RoutedEventArgs e)
        {
            AnimalManager animalManagerCopy = new AnimalManager(animalManager);
            AnimalWindow window = new AnimalWindow(animalManagerCopy);
            window.ShowDialog();

            if(window.DialogResult.HasValue && window.DialogResult.Value)
            {
                animalManager = window.AnimalManager;
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
            AnimalManager animalManagerCopy = new AnimalManager();
            AnimalWindow window = new AnimalWindow(animalManagerCopy);
            window.ShowDialog();
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
            lstAnimals.ItemsSource = animalManager.ListOfAnimals;   //your query result 
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
            column3.Width = 450;
            GridViewControl.Columns.Add(column3);
        }
        #endregion
    }
}
