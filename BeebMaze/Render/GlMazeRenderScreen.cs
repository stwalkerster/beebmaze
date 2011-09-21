using System;
using System.Collections.Generic;
using System.Drawing;
using Tao.OpenGl;
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

        private void simpleOpenGlControl1_SizeChanged(object sender, EventArgs e)
        {
            Gl.glViewport(0, 0, simpleOpenGlControl1.Size.Width, simpleOpenGlControl1.Size.Height);
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
        }

    }
}
