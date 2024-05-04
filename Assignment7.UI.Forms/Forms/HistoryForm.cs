using Assignment7.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Assignment7.Helpers.EnumHelper;

namespace Assignment7.UI.Forms.Forms
{
    public partial class HistoryForm : Form
    {
        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        public HistoryForm()
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
            InitComboBox();
        }

        /// <summary>
        /// 
        /// </summary>
        private void InitComboBox()
        {
            cmbAnimalType.Items.Clear();
            string[] descriptions = GetDescriptions<AnimalType>();
            cmbAnimalType.Items.AddRange(descriptions);
            cmbAnimalType.SelectedIndex = (int)AnimalType.Mammal;
        }
        #endregion
    }
}
