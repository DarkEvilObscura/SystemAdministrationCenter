namespace SystemAdministrationCenter
{
    partial class Form_TaskErstellenBearbeiten
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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox_RunOnce = new System.Windows.Forms.CheckBox();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.textBox_FileParameter = new System.Windows.Forms.TextBox();
            this.button_OpenFileDialog = new System.Windows.Forms.Button();
            this.textBox_FileName = new System.Windows.Forms.TextBox();
            this.comboBox_Condition = new System.Windows.Forms.ComboBox();
            this.textBox_TaskName = new System.Windows.Forms.TextBox();
            this.button_Apply = new System.Windows.Forms.Button();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.checkBox_NoWindow = new System.Windows.Forms.CheckBox();
            this.comboBox_WindowMode = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox_WindowMode);
            this.groupBox1.Controls.Add(this.checkBox_NoWindow);
            this.groupBox1.Controls.Add(this.checkBox_RunOnce);
            this.groupBox1.Controls.Add(this.dateTimePicker);
            this.groupBox1.Controls.Add(this.textBox_FileParameter);
            this.groupBox1.Controls.Add(this.button_OpenFileDialog);
            this.groupBox1.Controls.Add(this.textBox_FileName);
            this.groupBox1.Controls.Add(this.comboBox_Condition);
            this.groupBox1.Controls.Add(this.textBox_TaskName);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(308, 174);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Task";
            // 
            // checkBox_RunOnce
            // 
            this.checkBox_RunOnce.AutoSize = true;
            this.checkBox_RunOnce.Location = new System.Drawing.Point(6, 147);
            this.checkBox_RunOnce.Name = "checkBox_RunOnce";
            this.checkBox_RunOnce.Size = new System.Drawing.Size(115, 17);
            this.checkBox_RunOnce.TabIndex = 7;
            this.checkBox_RunOnce.Text = "Einmalig ausführen";
            this.checkBox_RunOnce.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Enabled = false;
            this.dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePicker.Location = new System.Drawing.Point(224, 46);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.ShowUpDown = true;
            this.dateTimePicker.Size = new System.Drawing.Size(72, 20);
            this.dateTimePicker.TabIndex = 6;
            this.dateTimePicker.Value = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
            // 
            // textBox_FileParameter
            // 
            this.textBox_FileParameter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_FileParameter.ForeColor = System.Drawing.Color.Gray;
            this.textBox_FileParameter.Location = new System.Drawing.Point(6, 98);
            this.textBox_FileParameter.Name = "textBox_FileParameter";
            this.textBox_FileParameter.Size = new System.Drawing.Size(290, 20);
            this.textBox_FileParameter.TabIndex = 5;
            this.textBox_FileParameter.Text = "Programm-Parameter (optional)";
            this.textBox_FileParameter.Enter += new System.EventHandler(this.textBox_FileParameter_Enter);
            this.textBox_FileParameter.Leave += new System.EventHandler(this.textBox_FileParameter_Leave);
            this.textBox_FileParameter.MouseHover += new System.EventHandler(this.textBox_FileParameter_MouseHover);
            // 
            // button_OpenFileDialog
            // 
            this.button_OpenFileDialog.Location = new System.Drawing.Point(249, 70);
            this.button_OpenFileDialog.Name = "button_OpenFileDialog";
            this.button_OpenFileDialog.Size = new System.Drawing.Size(47, 23);
            this.button_OpenFileDialog.TabIndex = 4;
            this.button_OpenFileDialog.Text = "...";
            this.button_OpenFileDialog.UseVisualStyleBackColor = true;
            this.button_OpenFileDialog.Click += new System.EventHandler(this.button_OpenFileDialog_Click);
            // 
            // textBox_FileName
            // 
            this.textBox_FileName.Enabled = false;
            this.textBox_FileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_FileName.ForeColor = System.Drawing.Color.Gray;
            this.textBox_FileName.Location = new System.Drawing.Point(6, 72);
            this.textBox_FileName.Name = "textBox_FileName";
            this.textBox_FileName.Size = new System.Drawing.Size(237, 20);
            this.textBox_FileName.TabIndex = 3;
            this.textBox_FileName.Text = "Programm zur Ausführung";
            this.textBox_FileName.MouseHover += new System.EventHandler(this.textBox_FileName_MouseHover);
            // 
            // comboBox_Condition
            // 
            this.comboBox_Condition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Condition.FormattingEnabled = true;
            this.comboBox_Condition.Items.AddRange(new object[] {
            "Systemstart",
            "Zeitplan"});
            this.comboBox_Condition.Location = new System.Drawing.Point(6, 45);
            this.comboBox_Condition.Name = "comboBox_Condition";
            this.comboBox_Condition.Size = new System.Drawing.Size(212, 21);
            this.comboBox_Condition.TabIndex = 2;
            this.comboBox_Condition.SelectedIndexChanged += new System.EventHandler(this.comboBox_Condition_SelectedIndexChanged);
            // 
            // textBox_TaskName
            // 
            this.textBox_TaskName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_TaskName.ForeColor = System.Drawing.Color.Gray;
            this.textBox_TaskName.Location = new System.Drawing.Point(6, 19);
            this.textBox_TaskName.Name = "textBox_TaskName";
            this.textBox_TaskName.Size = new System.Drawing.Size(290, 20);
            this.textBox_TaskName.TabIndex = 1;
            this.textBox_TaskName.Text = "Name der Task";
            this.textBox_TaskName.Enter += new System.EventHandler(this.textBox_TaskName_Enter);
            this.textBox_TaskName.Leave += new System.EventHandler(this.textBox_TaskName_Leave);
            // 
            // button_Apply
            // 
            this.button_Apply.Enabled = false;
            this.button_Apply.Location = new System.Drawing.Point(234, 192);
            this.button_Apply.Name = "button_Apply";
            this.button_Apply.Size = new System.Drawing.Size(86, 23);
            this.button_Apply.TabIndex = 2;
            this.button_Apply.Text = "Übernehmen";
            this.button_Apply.UseVisualStyleBackColor = true;
            this.button_Apply.Click += new System.EventHandler(this.button_Apply_Click);
            // 
            // button_Cancel
            // 
            this.button_Cancel.Location = new System.Drawing.Point(144, 192);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(86, 23);
            this.button_Cancel.TabIndex = 3;
            this.button_Cancel.Text = "Abbrechen";
            this.button_Cancel.UseVisualStyleBackColor = true;
            this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
            // 
            // checkBox_NoWindow
            // 
            this.checkBox_NoWindow.AutoSize = true;
            this.checkBox_NoWindow.Location = new System.Drawing.Point(6, 124);
            this.checkBox_NoWindow.Name = "checkBox_NoWindow";
            this.checkBox_NoWindow.Size = new System.Drawing.Size(145, 17);
            this.checkBox_NoWindow.TabIndex = 8;
            this.checkBox_NoWindow.Text = "Im Hintergrund ausführen";
            this.checkBox_NoWindow.UseVisualStyleBackColor = true;
            this.checkBox_NoWindow.CheckedChanged += new System.EventHandler(this.checkBox_NoWindow_CheckedChanged);
            // 
            // comboBox_WindowMode
            // 
            this.comboBox_WindowMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_WindowMode.FormattingEnabled = true;
            this.comboBox_WindowMode.Items.AddRange(new object[] {
            "Normal",
            "Maximiert",
            "Minimiert"});
            this.comboBox_WindowMode.Location = new System.Drawing.Point(175, 122);
            this.comboBox_WindowMode.Name = "comboBox_WindowMode";
            this.comboBox_WindowMode.Size = new System.Drawing.Size(121, 21);
            this.comboBox_WindowMode.TabIndex = 9;
            // 
            // Form_TaskErstellenBearbeiten
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 227);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.button_Apply);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_TaskErstellenBearbeiten";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Neuen Task erstellen";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form_TaskErstellen_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox_TaskName;
        private System.Windows.Forms.Button button_Apply;
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.ComboBox comboBox_Condition;
        private System.Windows.Forms.Button button_OpenFileDialog;
        private System.Windows.Forms.TextBox textBox_FileName;
        private System.Windows.Forms.TextBox textBox_FileParameter;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.CheckBox checkBox_RunOnce;
        private System.Windows.Forms.ComboBox comboBox_WindowMode;
        private System.Windows.Forms.CheckBox checkBox_NoWindow;
    }
}