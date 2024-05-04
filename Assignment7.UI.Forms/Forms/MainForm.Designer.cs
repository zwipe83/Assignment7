namespace Assignment7.UI.Forms
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            btnAddSighting = new Button();
            btnAnimalManager = new Button();
            btnHistory = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 48F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(192, 59);
            label1.Name = "label1";
            label1.Size = new Size(403, 86);
            label1.TabIndex = 0;
            label1.Text = "WildSighting";
            // 
            // btnAddSighting
            // 
            btnAddSighting.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAddSighting.Location = new Point(202, 232);
            btnAddSighting.Name = "btnAddSighting";
            btnAddSighting.Size = new Size(372, 64);
            btnAddSighting.TabIndex = 1;
            btnAddSighting.Text = "Add Sighting";
            btnAddSighting.UseVisualStyleBackColor = true;
            btnAddSighting.Click += btnAddSighting_Click;
            // 
            // btnAnimalManager
            // 
            btnAnimalManager.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAnimalManager.Location = new Point(202, 302);
            btnAnimalManager.Name = "btnAnimalManager";
            btnAnimalManager.Size = new Size(372, 64);
            btnAnimalManager.TabIndex = 1;
            btnAnimalManager.Text = "Manage Animals";
            btnAnimalManager.UseVisualStyleBackColor = true;
            btnAnimalManager.Click += btnAnimalManager_Click;
            // 
            // btnHistory
            // 
            btnHistory.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnHistory.Location = new Point(202, 372);
            btnHistory.Name = "btnHistory";
            btnHistory.Size = new Size(372, 64);
            btnHistory.TabIndex = 1;
            btnHistory.Text = "History";
            btnHistory.UseVisualStyleBackColor = true;
            btnHistory.Click += btnHistory_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 561);
            Controls.Add(btnHistory);
            Controls.Add(btnAnimalManager);
            Controls.Add(btnAddSighting);
            Controls.Add(label1);
            Name = "MainForm";
            Text = "WildSighting by Samuel Jeffman";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnAddSighting;
        private Button btnAnimalManager;
        private Button btnHistory;
    }
}
