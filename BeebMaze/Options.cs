using System;
using System.Windows.Forms;
using BeebMaze.Properties;

namespace BeebMaze
{
    public partial class Options : Form
    {
        public Options()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var mSender = (Button) sender;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                mSender.BackColor = colorDialog1.Color;
                groupBox3.Invalidate(true);
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.MazeSize = 16;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.MazeSize = 24;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.MazeSize = 32;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.MazeSize = 48;
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.MazeSize = 64;
        }

        private void optionsLoad(object sender, EventArgs e)
        {
            switch (Settings.Default.MazeSize)
            {
                case 16:
                    radioButton1.Checked = true;
                    break;
                case 24:
                    radioButton2.Checked = true;
                    break;
                case 32:
                    radioButton3.Checked = true;
                    break;
                case 48:
                    radioButton4.Checked = true;
                    break;
                case 64:
                    radioButton5.Checked = true;
                    break;
                default:
                    radioButton3.Checked = true;
                    break;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Settings.Default.Reset();
            Close();
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.DisplayDriver = Settings.DISPLAY_DRIVER_NET;
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.DisplayDriver = Settings.DISPLAY_DRIVER_GL2;
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.DisplayDriver = Settings.DISPLAY_DRIVER_GL3;
        }
    }
}