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
        public Gl2MazeRenderScreen()
        {
            InitializeComponent();
            rendererToolStripStatusLabel.Text = string.Format(rendererToolStripStatusLabel.Tag.ToString(),
                                                              "2D OpenGL");
            Gl.glMatrixMode(Gl.GL_MODELVIEW);

            simpleOpenGlControl1.Paint += simpleOpenGlControl1_Paint;
            simpleOpenGlControl1.PreviewKeyDown += Program.app.form1KeyDown;
        }

        /// <summary>
        /// Handles the Paint event of the simpleOpenGlControl1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.PaintEventArgs"/> instance containing the event data.</param>
        void simpleOpenGlControl1_Paint(object sender, PaintEventArgs e)
        {
            if (maze == null) maze = lastKnownMaze;

            if (maze == null) return;

            Gl.glLoadIdentity();
            //background - use unvisitedblock
            float[] clearCol = getColour(Color.Magenta);
            Gl.glClearColor(clearCol[0], clearCol[1], clearCol[2], 1f);

            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);

            Gl.glPushMatrix();
            {
                drawScene();
            }
            Gl.glPopMatrix();

        }

        protected override void performMove(Keys direction)
        {
            switch (direction)
            {
                case Keys.W:
                    maze.move(Maze.Direction.UP);
                    break;
                case Keys.A:
                    maze.move(Maze.Direction.LEFT);
                    break;
                case Keys.S:
                    maze.move(Maze.Direction.DOWN);
                    break;
                case Keys.D:
                    maze.move(Maze.Direction.RIGHT);
                    break;
            }
        }

   }
}
