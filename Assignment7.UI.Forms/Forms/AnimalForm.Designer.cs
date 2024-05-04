namespace Assignment7.UI.Forms.Forms
{
    partial class AnimalForm
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
            cmbAnimalType = new ComboBox();
            lblName = new Label();
            txtName = new TextBox();
            lblSelectImage = new Label();
            button1 = new Button();
            pictureBox1 = new PictureBox();
            btnSave = new Button();
            btnCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // cmbAnimalType
            // 
            cmbAnimalType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAnimalType.FormattingEnabled = true;
            cmbAnimalType.Location = new Point(44, 37);
            cmbAnimalType.Name = "cmbAnimalType";
            cmbAnimalType.Size = new Size(121, 23);
            cmbAnimalType.TabIndex = 0;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(234, 40);
            lblName.Name = "lblName";
            lblName.Size = new Size(39, 15);
            lblName.TabIndex = 1;
            lblName.Text = "Name";
            // 
            // txtName
            // 
            txtName.Location = new Point(289, 37);
            txtName.Name = "txtName";
            txtName.Size = new Size(100, 23);
            txtName.TabIndex = 2;
            // 
            // lblSelectImage
            // 
            lblSelectImage.AutoSize = true;
            lblSelectImage.Location = new Point(490, 40);
            lblSelectImage.Name = "lblSelectImage";
            lblSelectImage.Size = new Size(74, 15);
            lblSelectImage.TabIndex = 3;
            lblSelectImage.Text = "Select Image";
            // 
            // button1
            // 
            button1.Location = new Point(581, 35);
            button1.Name = "button1";
            button1.Size = new Size(26, 24);
            button1.TabIndex = 4;
            button1.Text = "...";
            button1.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(44, 112);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(701, 298);
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(581, 74);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 6;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(662, 74);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 6;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // AnimalForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(pictureBox1);
            Controls.Add(button1);
            Controls.Add(lblSelectImage);
            Controls.Add(txtName);
            Controls.Add(lblName);
            Controls.Add(cmbAnimalType);
            Name = "AnimalForm";
            Text = "AnimalForm2";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbAnimalType;
        private Label lblName;
        private TextBox txtName;
        private Label lblSelectImage;
        private Button button1;
        private PictureBox pictureBox1;
        private Button btnSave;
        private Button btnCancel;
    }
}