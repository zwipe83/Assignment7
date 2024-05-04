using Assignment7.UI.Forms.Forms;

namespace Assignment7.UI.Forms
{
    public partial class MainForm : Form
    {
        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
        }
        #endregion
        #region Private Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddSighting_Click(object sender, EventArgs e)
        {
            SightingForm form = new SightingForm();
            form.ShowDialog();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAnimalManager_Click(object sender, EventArgs e)
        {
            AnimalManagerForm form = new AnimalManagerForm();
            form.ShowDialog();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHistory_Click(object sender, EventArgs e)
        {
            HistoryForm form = new HistoryForm();
            form.ShowDialog();
        }
        #endregion
    }
}
