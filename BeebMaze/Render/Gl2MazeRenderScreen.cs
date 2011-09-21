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
        private const float WIDTH_WALL = 5f,
                            WIDTH_CELL = 5f,
                            GL_SIZE = 2f;

        private Block[,] maze = new Block[0,0];

        public override void render(Block[,] maze)
        {
            this.maze = maze;
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

        /// <summary>
        /// Handles the Paint event of the simpleOpenGlControl1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.PaintEventArgs"/> instance containing the event data.</param>
        void simpleOpenGlControl1_Paint(object sender, PaintEventArgs e)
        {
            // reset the projection and modelview matrices
            Gl.glMatrixMode(Gl.GL_PROJECTION_MATRIX);
            Gl.glLoadIdentity();

            Gl.glMatrixMode(Gl.GL_MODELVIEW_MATRIX);
            Gl.glLoadIdentity();

            // draw a polygon for the wall corners
            //drawQuad(0.1f);

            int cols = 10;
            int rows = 30;

            //work out how much we have to scale this model by
            float xscalingfactor = getScalingFactor(cols),
                  yscalingfactor = getScalingFactor(rows);

            float point = -1;
            Gl.glBegin(Gl.GL_LINES);
            Gl.glColor3f(1,0,0);
            for (int i = 0; i < 10; i++)
            {
                Gl.glVertex2f(-1, point);
                Gl.glVertex2f(1, point);
                point += (WIDTH_WALL*yscalingfactor);
                Gl.glVertex2f(-1, point);
                Gl.glVertex2f(1, point);
                point += (WIDTH_CELL * yscalingfactor);
            }
            Gl.glVertex2f(-1, point);
            Gl.glVertex2f(1, point);
            Gl.glEnd();

            Gl.glBegin(Gl.GL_LINES);
            Gl.glColor3f(0, 1, 0);
            for (int i = 0; i < 20; i++)
            {
                Gl.glVertex2f(point,-1);
                Gl.glVertex2f(point, 1);
                point += (WIDTH_WALL * xscalingfactor);
                Gl.glVertex2f(point, -1);
                Gl.glVertex2f(point, 1);
                point += (WIDTH_CELL * xscalingfactor);
            }
            Gl.glVertex2f(point, -1);
            Gl.glVertex2f(point, 1);
            Gl.glEnd();

            Gl.glFlush();
        }

        private float getScalingFactor(int cells)
        {
            return GL_SIZE/((WIDTH_WALL*(cells + 1)) + (cells*WIDTH_CELL));
        }

        void drawQuad(float size)
        {
            size = size/2;

            Gl.glBegin(Gl.GL_POLYGON);

            Gl.glColor3f(1f, 1f, 1f);

            Gl.glVertex2f(-size, size);
            Gl.glVertex2f(-size, -size);
            Gl.glVertex2f(size, -size);
            Gl.glVertex2f(size, size);

            Gl.glEnd();
        }
    }
}
