using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment7.UI.Forms.Forms
{
    public partial class AnimalManagerForm : Form
    {
        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        public AnimalManagerForm()
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
        private void btnAdd_Click(object sender, EventArgs e)
        {
            AnimalForm form = new AnimalForm();
            form.ShowDialog();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            AnimalForm form = new AnimalForm();
            form.ShowDialog();
        }
        #endregion
    }
}
