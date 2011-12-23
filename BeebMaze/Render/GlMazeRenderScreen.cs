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

        public override void render(Maze pmaze)
        {
            base.render(pmaze);
            simpleOpenGlControl1.Invalidate();
        }

        protected override void setColour(float r, float g, float b)
        {
            Gl.glColor3f(r, g, b);
        }
        protected override void setColour(float[] v)
        {
            Gl.glColor3fv(v);
        }

        protected override void positionScene(int cols, int rows, float[,] xvertices, float[,] yvertices)
        {
            float maxX = xvertices[(2 * cols) + 1, (2 * rows) + 1];
            float maxY = yvertices[(2 * cols) + 1, (2 * rows) + 1];

            float scaleX = 2 / maxX;
            float scaleY = 2 / maxY;

            Gl.glTranslatef(-1, 1, 0);
            Gl.glScalef(scaleX, -scaleY, 1);
        }

        protected override void drawCube(float x1, float y1, float x2, float y2, bool is3d = false)
        {
            Gl.glBegin(Gl.GL_POLYGON);
            Gl.glVertex3f(x1, y1, 0f);
            Gl.glVertex3f(x2, y1, 0f);
            Gl.glVertex3f(x2, y2, 0f);
            Gl.glVertex3f(x1, y2, 0f);


            Gl.glEnd();
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
