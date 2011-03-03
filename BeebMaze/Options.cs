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
            var w1 = new Wall(block1, block2, false);
            var w2 = new Wall(block2, block4, false);
            var w3 = new Wall(block3, block4, false);
            var w4 = new Wall(block3, block1, true);

            var w5 = new Wall(block8, block7, false);
            var w6 = new Wall(block7, block5, false);
            var w7 = new Wall(block6, block5, false);
            var w8 = new Wall(block8, block6, true);
            block1.wBottom = w4;
            block1.wRight = w1;
            block2.wBottom = w2;
            block2.wLeft = w1;
            block3.wRight = w3;
            block3.wTop = w4;
            block4.wLeft = w3;
            block4.wTop = w2;

            block8.wBottom = w8;
            block8.wRight = w5;
            block7.wBottom = w6;
            block7.wLeft = w5;
            block6.wRight = w7;
            block6.wTop = w8;
            block5.wLeft = w7;
            block5.wTop = w6;
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
    }
}