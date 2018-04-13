using System;
using System.Windows.Forms;

namespace Nutritracker
{
    public partial class setReminder : Form
    {
        public setReminder()
        {
            InitializeComponent();
        }

        private void setReminder_Load(object sender, EventArgs e)
        {
            _didSet = false;
            dateTimePicker1.Value = DateTime.Now + TimeSpan.FromDays(14);
        }

        public static bool _didSet = false;
        public static DateTime reminderDate;
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _didSet = true;
            reminderDate = dateTimePicker1.Value;
            this.Close();
        }
    }
}
