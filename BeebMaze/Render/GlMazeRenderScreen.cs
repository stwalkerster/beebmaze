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

        protected virtual void simpleOpenGlControl1_SizeChanged(object sender, EventArgs e)
        {
            Gl.glViewport(0, 0, simpleOpenGlControl1.Size.Width, simpleOpenGlControl1.Size.Height);
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
        }


        protected void drawGridlines()
        {
            Gl.glColor3f(1, 0, 0);
            Gl.glBegin(Gl.GL_LINES);
            Gl.glVertex3f(-10, 0, 0);
            Gl.glVertex3f(10, 0, 0);
            Gl.glEnd();
            Gl.glColor3f(0, 1, 0);
            Gl.glBegin(Gl.GL_LINES);
            Gl.glVertex3f(0, -10, 0);
            Gl.glVertex3f(0, 10, 0);
            Gl.glEnd();
            Gl.glColor3f(0, 0, 1);
            Gl.glBegin(Gl.GL_LINES);
            Gl.glVertex3f(0, 0, -10);
            Gl.glVertex3f(0, 0, 10);
            Gl.glEnd();
        }
    }
}
