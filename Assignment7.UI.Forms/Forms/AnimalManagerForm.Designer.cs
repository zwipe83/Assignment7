namespace Assignment7.UI.Forms.Forms
{
    partial class AnimalManagerForm
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
            btnAdd = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            btnClose = new Button();
            lstAnimals = new ListView();
            SuspendLayout();
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(57, 37);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(90, 39);
            btnAdd.TabIndex = 0;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(153, 37);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(90, 39);
            btnEdit.TabIndex = 0;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(249, 37);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(90, 39);
            btnDelete.TabIndex = 0;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(1066, 75);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(90, 39);
            btnClose.TabIndex = 0;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // lstAnimals
            // 
            lstAnimals.Location = new Point(57, 175);
            lstAnimals.Name = "lstAnimals";
            lstAnimals.Size = new Size(1099, 396);
            lstAnimals.TabIndex = 1;
            lstAnimals.UseCompatibleStateImageBehavior = false;
            // 
            // AnimalManagerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1218, 622);
            Controls.Add(lstAnimals);
            Controls.Add(btnClose);
            Controls.Add(btnDelete);
            Controls.Add(btnEdit);
            Controls.Add(btnAdd);
            Name = "AnimalManagerForm";
            Text = "AnimalmanagerForm";
            ResumeLayout(false);
        }

        #endregion

        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private Button btnClose;
        private ListView lstAnimals;
    }
}