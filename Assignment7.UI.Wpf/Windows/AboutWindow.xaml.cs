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
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
