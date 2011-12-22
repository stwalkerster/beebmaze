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
            Gl.glEnable(Gl.GL_DEPTH_TEST);
            Gl.glEnable(Gl.GL_NORMALIZE);
            Gl.glEnable(Gl.GL_COLOR_MATERIAL);
        }

        void gluPerspective(double fovy, double aspect, double zNear, double zFar)
        {
            double xmin, xmax, ymin, ymax;

            ymax = zNear * Math.Tan(fovy * Math.PI / 360.0);
            ymin = -ymax;
            xmin = ymin * aspect;
            xmax = ymax * aspect;


            Gl.glFrustum(xmin, xmax, ymin, ymax, zNear, zFar);
        }

        protected override void simpleOpenGlControl1_SizeChanged(object sender, EventArgs e)
        {
            Gl.glViewport(0, 0, simpleOpenGlControl1.Size.Width, simpleOpenGlControl1.Size.Height);
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            gluPerspective(90, ((double)simpleOpenGlControl1.Size.Width / (double)simpleOpenGlControl1.Size.Height), 0.1, 7);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
        }

        void simpleOpenGlControl1_Paint(object sender, PaintEventArgs e)
        {
            if (maze == null) maze = lastKnownMaze;

            if (maze == null) return;

            Gl.glLoadIdentity();

            //background
            float[] clearCol = getColour(Color.Magenta);
            Gl.glClearColor(clearCol[0], clearCol[1], clearCol[2], 1f);

            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);

            doLighting();


            Gl.glTranslatef(0, 0, -3);

            // view control
            Gl.glRotatef(yaw, 0, 1, 0);
            Gl.glRotatef(pitch, 1, 0, 0);

           // drawGridlines();

            Gl.glPushMatrix();
            {
                drawScene();
            }
            Gl.glPopMatrix();

        }

        private void doLighting()
        {
            if (Properties.Settings.Default.UseLighting)
            {
                Gl.glEnable(Gl.GL_LIGHTING);
                Gl.glEnable(Gl.GL_LIGHT0);
            }
            else
            {
                Gl.glDisable(Gl.GL_LIGHTING);
                Gl.glDisable(Gl.GL_LIGHT0);
                return;
            }

            // Configure position, diffuse light and specular light of light 0
            float[] light0_position = {-2, 2, 2, 1};
            float[] light0_diffuse = {0.7f, 0.7f, 0.7f, 1};
            float[] light0_specular = {0.9f, 0.9f, 0.9f, 1};
            // Set the scene ambient light to a low level
            float[] lightscene_ambience = {0.4f, 0.4f, 0.4f, 1};
            // Set the material specular reflectivity
            float[] material_specular = {1, 1, 1, 1};

            // Actually configure the scene ambient light
            Gl.glLightModelfv(Gl.GL_LIGHT_MODEL_AMBIENT, lightscene_ambience);

            // Actually configure the light, and enable it
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_POSITION, light0_position);
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_DIFFUSE, light0_diffuse);
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_SPECULAR, light0_specular);

            // Set the material specularity and shininess factor
            Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_SPECULAR, material_specular);
            Gl.glMaterialf(Gl.GL_FRONT, Gl.GL_SHININESS, 25);
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

        protected override void drawCube(float x1, float y1, float x2, float y2, bool is3d = false)
        {
            base.drawCube(x1, y1, x2, y2, is3d);
            if (is3d)
            {
                float height = 0.3f;

                Gl.glBegin(Gl.GL_TRIANGLE_STRIP);
                {
                    Gl.glVertex3f(x1, y2, 0);
                    Gl.glVertex3f(x1, y1, 0);
                    Gl.glVertex3f(x1, y2, height);
                    Gl.glVertex3f(x1, y1, height);
                    Gl.glVertex3f(x2, y2, height);
                    Gl.glVertex3f(x2, y1, height);
                    Gl.glVertex3f(x2, y2, 0);
                    Gl.glVertex3f(x2, y1, 0);
                }
                Gl.glEnd();

                Gl.glBegin(Gl.GL_POLYGON);
                {
                    Gl.glVertex3f(x1, y1, 0);
                    Gl.glVertex3f(x2, y1, 0);
                    Gl.glVertex3f(x2, y1, height);
                    Gl.glVertex3f(x1, y1, height);
                }
                Gl.glEnd();

                Gl.glBegin(Gl.GL_POLYGON);
                {
                    Gl.glVertex3f(x2, y2, 0);
                    Gl.glVertex3f(x1, y2, 0);
                    Gl.glVertex3f(x1, y2, height);
                    Gl.glVertex3f(x2, y2, height);
                }
                Gl.glEnd();

            }
        }

        protected override void positionScene(int cols, int rows, float[,] xvertices, float[,] yvertices)
        {
            float maxX = xvertices[(2 * cols) + 1, (2 * rows) + 1];
            float maxY = yvertices[(2 * cols) + 1, (2 * rows) + 1];

            float moveX = maxX/2;
            float moveY = maxY/2;

            Gl.glTranslatef(-moveX, moveY, 0);
            Gl.glScalef(1, -1, 1);
        }
    }
}
