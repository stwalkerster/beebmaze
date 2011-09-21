using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BeebMaze.Render
{
    public partial class Gl2MazeRenderScreen : BeebMaze.Render.GlMazeRenderScreen
    {
        public Gl2MazeRenderScreen()
        {
            InitializeComponent();
            rendererToolStripStatusLabel.Text = string.Format(rendererToolStripStatusLabel.Tag.ToString(),
                                                  "2D OpenGL");

        }
    }
}
