namespace Assignment7.UI.Forms.Forms
{
    public partial class SightingForm : Form
    {
        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        public SightingForm()
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
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
