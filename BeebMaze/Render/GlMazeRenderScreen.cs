using System;
using System.Collections.Generic;
using System.Drawing;

namespace BeebMaze.Render
{
    public partial class GlMazeRenderScreen : BeebMaze.Render.MazeRenderScreen
    {
        public GlMazeRenderScreen()
        {
            InitializeComponent();
            rendererToolStripStatusLabel.Text = string.Format(rendererToolStripStatusLabel.Tag.ToString(),
                                                              "Generic OpenGL");
            simpleOpenGlControl1.InitializeContexts();
        }

        ~GlMazeRenderScreen()
        {
            simpleOpenGlControl1.DestroyContexts();
        }

    }
}
