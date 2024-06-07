using System.Windows;
using System.Windows.Input;

namespace Assignment7.UI.Wpf.Windows
{
    /// <summary>
    /// Interaction logic for AboutWindow.xaml
    /// </summary>
    public partial class AboutWindow : Window
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AboutWindow"/> class.
        /// </summary>
        public AboutWindow()
        {
            InitializeComponent();

            InitGUI();
        }
        #endregion
        #region Private Methods

        /// <summary>
        /// Initializes the GUI elements in the AboutWindow.
        /// </summary>
        private void InitGUI()
        {
            SetAssemblyInfo();
        }

        /// <summary>
        /// Sets the assembly information in the GUI elements.
        /// </summary>
        private void SetAssemblyInfo()
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            System.Diagnostics.FileVersionInfo fvi = System.Diagnostics.FileVersionInfo.GetVersionInfo(assembly.Location);
            string version = fvi.FileVersion;
            string copyright = fvi.LegalCopyright;
            string company = fvi.CompanyName;
            string product = fvi.ProductName;

            this.lblHeader.Content = "About WildSights";
            this.lblProductName.Content = product;
            this.lblVersion.Content = version;
            this.lblCopyright.Content = copyright;
            this.lblCompanyName.Content = company;
            this.txtBoxDescription.Text = "WildSights lets you manage animal encounters in the wild.";
        }

        /// <summary>
        /// Handles the MouseDown event of the Window control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseButtonEventArgs"/> instance containing the event data.</param>
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }

        /// <summary>
        /// Handles the Click event of the btnClose control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
