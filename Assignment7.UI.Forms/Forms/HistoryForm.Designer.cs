namespace Assignment7.UI.Forms.Forms
{
    partial class HistoryForm
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
            dateFrom = new DateTimePicker();
            dateTo = new DateTimePicker();
            btnPrint = new Button();
            listView1 = new ListView();
            SuspendLayout();
            // 
            // cmbAnimalType
            // 
            cmbAnimalType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAnimalType.FormattingEnabled = true;
            cmbAnimalType.Location = new Point(31, 29);
            cmbAnimalType.Name = "cmbAnimalType";
            cmbAnimalType.Size = new Size(121, 23);
            cmbAnimalType.TabIndex = 0;
            // 
            // dateFrom
            // 
            dateFrom.Location = new Point(192, 29);
            dateFrom.Name = "dateFrom";
            dateFrom.Size = new Size(200, 23);
            dateFrom.TabIndex = 1;
            // 
            // dateTo
            // 
            dateTo.Location = new Point(398, 29);
            dateTo.Name = "dateTo";
            dateTo.Size = new Size(200, 23);
            dateTo.TabIndex = 1;
            // 
            // btnPrint
            // 
            btnPrint.Location = new Point(676, 31);
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new Size(75, 23);
            btnPrint.TabIndex = 2;
            btnPrint.Text = "Print";
            btnPrint.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            listView1.Location = new Point(31, 104);
            listView1.Name = "listView1";
            listView1.Size = new Size(734, 317);
            listView1.TabIndex = 3;
            listView1.UseCompatibleStateImageBehavior = false;
            // 
            // HistoryForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(listView1);
            Controls.Add(btnPrint);
            Controls.Add(dateTo);
            Controls.Add(dateFrom);
            Controls.Add(cmbAnimalType);
            Name = "HistoryForm";
            Text = "HistoryForm";
            ResumeLayout(false);
        }

        #endregion

        private ComboBox cmbAnimalType;
        private DateTimePicker dateFrom;
        private DateTimePicker dateTo;
        private Button btnPrint;
        private ListView listView1;
    }
}