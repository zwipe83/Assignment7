namespace Assignment7.UI.Forms.Forms
{
    partial class SightingForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            cmbAnimal = new ComboBox();
            dateTimePicker1 = new DateTimePicker();
            lblCount = new Label();
            txtCount = new TextBox();
            btnSave = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // cmbAnimal
            // 
            cmbAnimal.FormattingEnabled = true;
            cmbAnimal.Location = new Point(35, 33);
            cmbAnimal.Name = "cmbAnimal";
            cmbAnimal.Size = new Size(121, 23);
            cmbAnimal.TabIndex = 0;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(202, 33);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(200, 23);
            dateTimePicker1.TabIndex = 1;
            // 
            // lblCount
            // 
            lblCount.AutoSize = true;
            lblCount.Location = new Point(430, 39);
            lblCount.Name = "lblCount";
            lblCount.Size = new Size(38, 15);
            lblCount.TabIndex = 2;
            lblCount.Text = "label1";
            // 
            // txtCount
            // 
            txtCount.Location = new Point(485, 36);
            txtCount.Name = "txtCount";
            txtCount.Size = new Size(100, 23);
            txtCount.TabIndex = 3;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(615, 35);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 4;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(696, 35);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // SightingForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(txtCount);
            Controls.Add(lblCount);
            Controls.Add(dateTimePicker1);
            Controls.Add(cmbAnimal);
            Name = "SightingForm";
            Text = "SightingForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbAnimal;
        private DateTimePicker dateTimePicker1;
        private Label lblCount;
        private TextBox txtCount;
        private Button btnSave;
        private Button btnCancel;
    }
}