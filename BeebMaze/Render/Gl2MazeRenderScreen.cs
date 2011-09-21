using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Tao.OpenGl;

namespace BeebMaze.Render
{
    public partial class Gl2MazeRenderScreen : GlMazeRenderScreen
    {
        private const int WIDTH_WALL = 5,
                          WIDTH_CELL = 5;

        public override void render(Block[,] maze)
        {
            simpleOpenGlControl1.Invalidate();
        }


        public Gl2MazeRenderScreen()
        {
            InitializeComponent();
            rendererToolStripStatusLabel.Text = string.Format(rendererToolStripStatusLabel.Tag.ToString(),
                                                  "2D OpenGL");
            Gl.glViewport(0, 0, simpleOpenGlControl1.Size.Width, simpleOpenGlControl1.Size.Height);
            simpleOpenGlControl1.Paint += simpleOpenGlControl1_Paint;
        }

        void simpleOpenGlControl1_Paint(object sender, PaintEventArgs e)
        {
            // reset the projection and modelview matrices
            Gl.glMatrixMode(Gl.GL_PROJECTION_MATRIX);
            Gl.glLoadIdentity();

            Gl.glMatrixMode(Gl.GL_MODELVIEW_MATRIX);
            Gl.glLoadIdentity();

            Gl.glBegin(Gl.GL_POLYGON);

            Gl.glColor3f(1f, 0f, 0f);
            Gl.glVertex2f(0, 1);

            Gl.glColor3f(0f, 1f, 0f);
            Gl.glVertex2f(-1, -1);

            Gl.glColor3f(1f, 1f, 1f);
            Gl.glVertex2f(0,0);

            Gl.glColor3f(0f, 0f, 1f);
            Gl.glVertex2f(1, -1);

            Gl.glEnd();
        }



    }
}
