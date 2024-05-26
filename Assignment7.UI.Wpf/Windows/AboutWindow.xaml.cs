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

            this.lblHeader.Content = "About WildSights";
            this.lblProductName.Content = "WildSights";
            this.lblVersion.Content = "Version 1.0";
            this.lblCopyright.Content = "Copyright 2024. No rights reserved.";
            this.lblCompanyName.Content = "No Company";
            this.txtBoxDescription.Text = "WildSights lets you manage animal encounters in the wild.";
        }
        #endregion

        #region Private Methods

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
