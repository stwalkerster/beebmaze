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
    public partial class Gl3MazeRenderScreen : BeebMaze.Render.Gl2MazeRenderScreen
    {
        public Gl3MazeRenderScreen()
        {
            InitializeComponent();
            rendererToolStripStatusLabel.Text = string.Format(rendererToolStripStatusLabel.Tag.ToString(),
                                                  "3D OpenGL");
            simpleOpenGlControl1.MouseWheel += new MouseEventHandler(simpleOpenGlControl1_MouseWheel);
            simpleOpenGlControl1.MouseDown += new MouseEventHandler(simpleOpenGlControl1_MouseDown);
            simpleOpenGlControl1.MouseMove += new MouseEventHandler(simpleOpenGlControl1_MouseMove);
            simpleOpenGlControl1.MouseUp += new MouseEventHandler(simpleOpenGlControl1_MouseUp);
            simpleOpenGlControl1.Paint += new PaintEventHandler(simpleOpenGlControl1_Paint);
        }

        protected override void simpleOpenGlControl1_SizeChanged(object sender, EventArgs e)
        {
            Gl.glViewport(0, 0, simpleOpenGlControl1.Size.Width, simpleOpenGlControl1.Size.Height);
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Glu.gluPerspective(60, ((double)simpleOpenGlControl1.Size.Width / (double)simpleOpenGlControl1.Size.Height), 1, 5);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
        }

        void simpleOpenGlControl1_Paint(object sender, PaintEventArgs e)
        {
            if (maze == null) maze = lastKnownMaze;

            if (maze == null) return;

            Gl.glLoadIdentity();
            //background - use unvisitedblock
            float[] clearCol = getColour(Color.Magenta);
            Gl.glClearColor(clearCol[0], clearCol[1], clearCol[2], 1f);

            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
   
            Gl.glTranslatef(0, 0, -3);

            // view control
            Gl.glRotatef(yaw, 0, 1, 0);
            Gl.glRotatef(pitch, 1, 0, 0);

            drawGridlines();

            drawScene();
            
        }

        void simpleOpenGlControl1_MouseUp(object sender, MouseEventArgs e)
        {
            isdown = false;
        }

        private bool isdown = false;
        private int x;
        private int y;
        private float yaw = 0, pitch = 0;
        void simpleOpenGlControl1_MouseDown(object sender, MouseEventArgs e)
        {
            isdown = true;
            x = e.X;
            y = e.Y;
        }

        void simpleOpenGlControl1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isdown)
            {
                yaw += (e.X - x);
                pitch += (e.Y - y);
                simpleOpenGlControl1.Invalidate();
                x = e.X;
                y = e.Y;
            }
        }

        void simpleOpenGlControl1_MouseWheel(object sender, MouseEventArgs e)
        {
            //  e.Delta
        }
    }
}
