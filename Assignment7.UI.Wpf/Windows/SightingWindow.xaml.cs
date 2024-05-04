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
using Assignment7;

namespace Assignment7.UI.Wpf.Windows
{
    /// <summary>
    /// Interaction logic for SightingWindow.xaml
    /// </summary>
    public partial class SightingWindow : Window
    {
        #region Fields

        /// <summary>
        /// 
        /// </summary>
        MapManager mapManager = new();
        #endregion
        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        public SightingWindow()
        {
            InitializeComponent();
            InitGUI();
        }
        #endregion
        #region Private Methods

        /// <summary>
        /// 
        /// </summary>
        private void InitGUI()
        {
            mapManager.Map.CreateMapAsync();
            mapManager.MapControl.MapControlObj.Map = mapManager.Map.MapObj;
            contentMap.Content = mapManager.MapControl.MapControlObj;
        }
        #endregion
    }
}
