using System;
using System.Windows.Forms;

namespace Nutritracker
{
    public partial class progBarWait : Form
    {
        public progBarWait()
        {
            InitializeComponent();
        }

        public void setTitle(string _title)
        {
            if (this.InvokeRequired)
                this.Invoke(new MethodInvoker(delegate { this.Text = _title; }));
            else
                this.Text = _title;
        }

        int buffer = 50;
        public void setProgMax(int max, int _buffer)
        {
            buffer = _buffer;
            if (this.InvokeRequired)
                this.Invoke(new MethodInvoker(delegate { progBar.Maximum = max; }));
            else
                progBar.Maximum = max;
        }


        public void incProgVal()
        {
            if (this.InvokeRequired)
                this.Invoke(new MethodInvoker(delegate { doInc(); }));
            else
                doInc();
        }
        void doInc()
        {
            progBar.Value++;
            try
            {
                if (progBar.Value >= progBar.Maximum - 1)
                {
                    finished = true;
                    this.Close();
                    return;
                }
            }
            catch (Exception e) { eReporter.catchEx(e, nameof(progBarWait), nameof(incProgVal)); }
        }
        public bool finished;
        public void setLblCurObj(string text)
        {
            if (finished || abort)
                return;
            incProgVal();
            if (progBar.Value > buffer && progBar.Value % buffer == 0)
                try
                {
                    if (this.InvokeRequired)
                        this.Invoke(new MethodInvoker(delegate { lblProgress.Text = $"Current object: {text}"; }));
                    else
                        lblProgress.Text = $"Current object: {text}";
                    Application.DoEvents();
                }
                catch (Exception e) { eReporter.catchEx(e, nameof(progBarWait), nameof(setLblCurObj)); }
        }


        public bool ready;
        private void progBarWait_Activated(object sender, EventArgs e)
        {
            ready = true;
        }

        public bool abort;
        private void btnAbort_Click(object sender, EventArgs e)
        {
            abort = true;
            this.Close();
        }
    }
}