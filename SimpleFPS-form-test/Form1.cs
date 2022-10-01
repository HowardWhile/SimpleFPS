using aiRobots;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleFPS_form_test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private AverageFPS fps_tool = new AverageFPS();
        private void Form1_Load(object sender, EventArgs e)
        {
            this.timer1.Interval = 15;
            this.timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Text = $"Interval = {this.timer1.Interval}ms, FPS = {fps_tool.FPSUpdate():0.00}";
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            this.timer1.Interval = this.trackBar1.Value;
            this.Text = $"Interval = {this.timer1.Interval}ms";
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
