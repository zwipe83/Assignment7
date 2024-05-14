using Assignment7.Enums;
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
