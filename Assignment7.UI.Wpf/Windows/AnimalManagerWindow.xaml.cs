using Assignment7.Classes;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace Assignment7.UI.Wpf.Windows
{
    /// <summary>
    /// Interaction logic for AnimalManagerWindow.xaml
    /// </summary>
    public partial class AnimalManagerWindow : Window
    {
        #region Fields

        /// <summary>
        /// The animal manager instance.
        /// </summary>
        private AnimalManager _animalManager;

        /// <summary>
        /// The currently selected animal.
        /// </summary>
        private Animal _selectedAnimal;
        #endregion
        #region Properties

        /// <summary>
        /// Gets the animal manager instance.
        /// </summary>
        public AnimalManager AnimalManager
        {
            get => _animalManager;
            private protected set => _animalManager = value;
        }

        /// <summary>
        /// Gets or sets the currently selected animal.
        /// </summary>
        private Animal SelectedAnimal
        {
            get => _selectedAnimal;
            set => _selectedAnimal = value;
        }
        #endregion
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AnimalManagerWindow"/> class.
        /// </summary>
        /// <param name="animalManager">The animal manager instance.</param>
        public AnimalManagerWindow(AnimalManager animalManager)
        {
            InitializeComponent();

            this._animalManager = animalManager;

            InitGUI();
        }
        #endregion
        #region Private Methods

        /// <summary>
        /// Handles the click event of the "Add Animal" button.
        /// </summary>
        /// <param name="sender">The button that raised the event.</param>
        /// <param name="e">The event arguments.</param>
        private void btnAddAnimal_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AnimalWindow window = new AnimalWindow();
                window.ShowDialog();

                if (window.DialogResult.HasValue && window.DialogResult.Value)
                {
                    AnimalManager.AddAnimal(window.Animal);
                    lstAnimals.ItemsSource = AnimalManager.ListOfAnimals.OrderBy(a => a.Name);
                }
                else
                {
                    // Do nothing...
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Handles the click event of the "Edit Animal" button.
        /// </summary>
        /// <param name="sender">The button that raised the event.</param>
        /// <param name="e">The event arguments.</param>
        private void btnEditAnimal_Click(object sender, RoutedEventArgs e)
        {
            Animal animalCopy = new Animal(SelectedAnimal);
            AnimalWindow window = new AnimalWindow(animalCopy, true);

            window.ShowDialog();

            if (window.DialogResult.HasValue && window.DialogResult.Value)
            {
                SelectedAnimal.AnimalId = window.Animal.AnimalId;
                SelectedAnimal.Name = window.Animal.Name;
                SelectedAnimal.Description = window.Animal.Description;
                SelectedAnimal.Image = window.Animal.Image;
                SelectedAnimal.AnimalType = window.Animal.AnimalType;
                AnimalManager.ChangeAnimal(SelectedAnimal);
                lstAnimals.Items.Refresh();
            }
            else
            {
                // Do nothing...
            }
        }

        /// <summary>
        /// Handles the click event of the "Cancel" button.
        /// </summary>
        /// <param name="sender">The button that raised the event.</param>
        /// <param name="e">The event arguments.</param>
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
        }

        /// <summary>
        /// Handles the click event of the "Save" button.
        /// </summary>
        /// <param name="sender">The button that raised the event.</param>
        /// <param name="e">The event arguments.</param>
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            this.Close();
        }

        /// <summary>
        /// Initializes the GUI.
        /// </summary>
        private void InitGUI()
        {
            InitListView();
        }

        /// <summary>
        /// Initializes the list view.
        /// </summary>
        private void InitListView()
        {
            lstAnimals.ItemsSource = AnimalManager.ListOfAnimals.OrderBy(a => a.Name);

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

        /// <summary>
        /// Handles the mouse up event of the list view.
        /// </summary>
        /// <param name="sender">The list view that raised the event.</param>
        /// <param name="e">The event arguments.</param>
        private void lstAnimals_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (lstAnimals.SelectedItem != null)
            {
                Animal selectedAnimal = (Animal)lstAnimals.SelectedItem;

                SelectedAnimal = selectedAnimal;
            }
        }

        /// <summary>
        /// Handles the click event of the "Delete Animal" button.
        /// </summary>
        /// <param name="sender">The button that raised the event.</param>
        /// <param name="e">The event arguments.</param>
        private void btnDeleteAnimal_Click(object sender, RoutedEventArgs e)
        {
            AnimalManager.DeleteAnimal(SelectedAnimal);
        }

        /// <summary>
        /// Handles the mouse double click event of the list view.
        /// </summary>
        /// <param name="sender">The list view that raised the event.</param>
        /// <param name="e">The event arguments.</param>
        private void lstAnimals_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            lstAnimals_MouseUp(sender, e);
            btnEditAnimal_Click(sender, e);
        }

        /// <summary>
        /// Handles the mouse down event of the window.
        /// </summary>
        /// <param name="sender">The window that raised the event.</param>
        /// <param name="e">The event arguments.</param>
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                DragMove();
        }
        #endregion
    }
}
