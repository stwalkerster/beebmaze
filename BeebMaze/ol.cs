using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Tao.OpenGl;

namespace BeebMaze
{
    public partial class ol : Form
    {
        public ol()
        {
            InitializeComponent();
            simpleOpenGlControl1.InitializeContexts();
        }

        private void simpleOpenGlControl1_Load(object sender, EventArgs e)
        {
            // Clear the window
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);

            // Specify polygon to be drawn and vertices of polygon
            Gl.glBegin(Gl.GL_POLYGON);
            Gl.glColor3f(1f, 1f, 1f);
            Gl.glVertex2f(-0.5f, -0.5f);
            Gl.glColor3f(1f, 0f, 0f);
            Gl.glVertex2f(-0.5f, 0.5f);
            Gl.glColor3f(0f, 1f, 0f);
            Gl.glVertex2f(0.5f, 0.5f);
            Gl.glColor3f(0f, 0f, 1f);
            Gl.glVertex2f(0.5f, -0.5f);
            Gl.glEnd();

            // Flush the buffer to force drawing of all objects thus far
            Gl.glFlush();

        }   

        ~ol()
        {
            simpleOpenGlControl1.DestroyContexts();
        }
    }
}
