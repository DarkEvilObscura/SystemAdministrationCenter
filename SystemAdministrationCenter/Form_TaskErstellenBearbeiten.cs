using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace SystemAdministrationCenter
{
    public partial class Form_TaskErstellenBearbeiten : Form
    {
        private const int CB_SETCUEBANNER = 0x1703;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);
        
        string filePath = string.Empty;
        string fileName = string.Empty;

        public TaskErstellenBearbeiten Task { get; private set; }

        public Form_TaskErstellenBearbeiten(TaskErstellenBearbeiten task = null)
        {
            InitializeComponent();
            Task = task;
        }

        private void Form_TaskErstellen_Load(object sender, EventArgs e)
        {
            Init();
        }

        void Init()
        {
            if(Task != null)
            {
                this.Text = string.Format("Task '{0}' bearbeiten", Task.TaskName);
                SetTextBoxesToDefault();

                textBox_TaskName.Text = Task.TaskName;
                comboBox_Condition.SelectedIndex = (int)Task.TaskCondition;
                if(Task.TaskCondition == TaskErstellenBearbeiten.Condition.Uhrzeit)
                {
                    dateTimePicker.Value = Task.TaskConditionTime;
                }

                List<KeyValuePair<string, string>> list = Task.TaskExecution;
                this.filePath = Path.GetDirectoryName(list[0].Value);
                this.fileName = list[0].Value.Replace(string.Concat(this.filePath, "\\"), string.Empty);
                textBox_FileName.Text = list[0].Value;
                textBox_FileParameter.Text = list[1].Value;

                checkBox_RunOnce.Checked = Task.RunOnce;
            }
            else
            {
                SendMessage(this.comboBox_Condition.Handle, CB_SETCUEBANNER, 0, "Bedingung");
                SendMessage(this.comboBox_WindowMode.Handle, CB_SETCUEBANNER, 0, "Fenstermodus");
            }
        }

        void SetTextBoxesToDefault()
        {
            foreach (Control item in this.groupBox1.Controls)
            {
                if(item.GetType() == typeof(TextBox))
                {
                    item.Text = string.Empty;
                    item.Font = new Font(new FontFamily("Microsoft Sans Serif"), 8.25f, FontStyle.Regular);
                    item.ForeColor = Color.Black;
                }
            }
        }

        #region textBox_Events

        private void textBox_TaskName_Enter(object sender, EventArgs e)
        {
            Enter(ref textBox_TaskName, "Name der Task");
            ValidateFields();
        }

        private void textBox_TaskName_Leave(object sender, EventArgs e)
        {
            Leave(ref textBox_TaskName, "Name der Task");
            ValidateFields();
        }

        private void textBox_FileParameter_Enter(object sender, EventArgs e)
        {
            Enter(ref textBox_FileParameter, "Programm-Parameter (optional)");
            ValidateFields();
        }

        private void textBox_FileParameter_Leave(object sender, EventArgs e)
        {
            Leave(ref textBox_FileParameter, "Programm-Parameter (optional)");
            ValidateFields();
        }

        private void textBox_FileName_MouseHover(object sender, EventArgs e)
        {
            string text = string.Format("Pfad: {0}\nProgramm: {1}", filePath, fileName);
            toolTip.Show(text, textBox_FileName, 10000);
        }

        private void textBox_FileParameter_MouseHover(object sender, EventArgs e)
        {
            toolTip.Show(textBox_FileParameter.Text, textBox_FileParameter, 10000);
        }

        #endregion //textBox_Events

        private void comboBox_Condition_SelectedIndexChanged(object sender, EventArgs e)
        {
            dateTimePicker.Enabled = comboBox_Condition.SelectedIndex == 1;
            ValidateFields();
        }

        #region button_Events

        private void button_OpenFileDialog_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Datei auswählen";
            dialog.Filter = "Ausführbare Dateien (.exe)|*.exe";
            dialog.Multiselect = false;
            DialogResult dialogResult = dialog.ShowDialog(this);
            if (dialogResult == DialogResult.OK)
            {
                textBox_FileName.Enabled = true;
                textBox_FileName.ReadOnly = true;
                textBox_FileName.Font = new Font(new FontFamily("Microsoft Sans Serif"), 8.25f, FontStyle.Regular);
                filePath = Path.GetDirectoryName(dialog.FileName);
                fileName = dialog.SafeFileName;
                textBox_FileName.Text = dialog.FileName;
                ValidateFields();
            }
        }

        private void button_Apply_Click(object sender, EventArgs e)
        {
            Apply();
        }

        void Apply()
        {
            TaskErstellenBearbeiten task = new TaskErstellenBearbeiten();
            List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();

            task.TaskName = textBox_TaskName.Text;
            task.TaskCondition = (TaskErstellenBearbeiten.Condition)comboBox_Condition.SelectedIndex;
            if (comboBox_Condition.SelectedIndex == (int)TaskErstellenBearbeiten.Condition.Uhrzeit)
            {
                task.TaskConditionTime = dateTimePicker.Value;
            }

            list.Add(new KeyValuePair<string, string>("Programm", textBox_FileName.Text));
            list.Add(new KeyValuePair<string, string>("Parameter", 
                (textBox_FileParameter.Text.Length > 0 && textBox_FileParameter.ForeColor != Color.Gray) ?
                        textBox_FileParameter.Text : string.Empty));
            task.TaskExecution = list;

            task.StatusText = TaskErstellenBearbeiten.StatusTyp.NochNichtAusgefuehrt;
            task.RunOnce = checkBox_RunOnce.Checked;

            this.Task = task;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        #endregion //button_Events

        //Wenn ein Textfeld den Focus bekommt
        void Enter(ref TextBox textBox, string defaultText)
        {
            if (textBox.Text == defaultText)
            {
                textBox.Text = string.Empty;
                textBox.Font = new Font(FontFamily.GenericSansSerif, 8.25f, FontStyle.Regular);
                textBox.ForeColor = Color.Black;
            }
        }

        //Wenn ein Textfeld den Focus verliert
        void Leave(ref TextBox textBox, string defaultText)
        {
            if (textBox.TextLength == 0)
            {
                textBox.Text = defaultText;
                textBox.Font = new Font(FontFamily.GenericSansSerif, 8.25f, FontStyle.Italic);
                textBox.ForeColor = Color.Gray;
            }
        }

        //Wenn alle Felder gesetzt sind, wird der Button 'Übernehmen' freigegeben
        void ValidateFields()
        {
            button_Apply.Enabled = (textBox_TaskName.TextLength > 0 &&
                                    comboBox_Condition.SelectedIndex > -1 &&
                                    textBox_TaskName.ForeColor == Color.Black &&
                                    fileName.Length > 0 && filePath.Length > 0);
        }

        private void checkBox_NoWindow_CheckedChanged(object sender, EventArgs e)
        {
            comboBox_WindowMode.Enabled = !checkBox_NoWindow.Checked;
        }
    }
}
