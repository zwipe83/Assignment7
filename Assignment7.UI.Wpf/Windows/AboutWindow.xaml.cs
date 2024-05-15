using System.Windows;

namespace Assignment7.UI.Wpf.Windows
{
    /// <summary>
    /// Interaction logic for AboutWindow.xaml
    /// </summary>
    public partial class AboutWindow : Window
    {
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
    }
}
