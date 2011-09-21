using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BeebMaze.Render
{
    public partial class DotNetMazeRenderScreen : BeebMaze.Render.MazeRenderScreen
    {
        public DotNetMazeRenderScreen()
        {
            InitializeComponent();
            rendererToolStripStatusLabel.Text = string.Format(rendererToolStripStatusLabel.Tag.ToString(),
                                                  ".NET Framework");

        }
    }
}
