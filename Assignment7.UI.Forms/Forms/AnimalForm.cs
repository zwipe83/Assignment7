using Assignment7.Enums;
using static Assignment7.Helpers.EnumHelper;

namespace Assignment7.UI.Forms.Forms
{
    public partial class AnimalForm : Form
    {
        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        public AnimalForm()
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
