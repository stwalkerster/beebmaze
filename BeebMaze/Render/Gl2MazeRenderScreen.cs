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
        protected Block[,] maze = new Block[0,0];

        public override void render(Block[,] pmaze)
        {
            this.maze = pmaze;
            this.lastKnownMaze = pmaze;
            simpleOpenGlControl1.Invalidate();
        }


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
   

            drawScene();

        }

        protected void drawScene()
        {
            Gl.glPushMatrix();
            {
                int rows = this.maze.GetUpperBound(1) + 1,
                    cols = this.maze.GetUpperBound(0) + 1;


                // x,y
                float[,] xvertices = new float[(2*cols) + 2,(2*rows) + 2];
                float[,] yvertices = new float[(2*cols) + 2,(2*rows) + 2];


                const float cellWidth = 0.3f;
                const float cellHeight = 0.3f;

                const float wallWidth = 0.1f;
                const float wallHeight = 0.1f;

                float xval = 0;
                for (int x = 0; x < (2*cols) + 2; x++)
                {
                    if (x != 0) xval += x%2 == 0 ? cellWidth : wallWidth;

                    float yval = 0;
                    for (int y = 0; y < (2*rows) + 2; y++)
                    {
                        if (y != 0) yval += y%2 == 0 ? cellHeight : wallHeight;

                        xvertices[x, y] = xval;
                        yvertices[x, y] = yval;
                    }
                }

                positionScene(cols, rows, xvertices, yvertices);

                Gl.glColor3fv(getColour(Properties.Settings.Default.ColorWalls));

                #region wall corners

                for (int x = 0; x <= cols; x++)
                {
                    for (int y = 0; y <= rows; y++)
                    {
                        drawCube(
                            xvertices[x*2, y*2],
                            yvertices[x*2, y*2],
                            xvertices[(x*2) + 1, (y*2) + 1],
                            yvertices[(x*2) + 1, (y*2) + 1],
                            true
                            );
                    }
                }

                #endregion


                for (int x = 0; x < cols; x++)
                {
                    for (int y = 0; y < rows; y++)
                    {
                        Block cell = maze[x, y];

                        #region walls

                        if (!cell.exitTop)
                        {
                            Gl.glColor3fv(getColour(Properties.Settings.Default.ColorWalls));

                            drawCube(
                                xvertices[(x*2) + 1, y*2],
                                yvertices[(x*2) + 1, y*2],
                                xvertices[(x*2) + 2, (y*2) + 1],
                                yvertices[(x*2) + 2, (y*2) + 1],
                                true
                                );
                        }
                        else
                        {
                            Gl.glColor3fv(getColour(getDoorColour(cell.wTop,cell)));
                            drawCube(
                                xvertices[(x*2) + 1, y*2],
                                yvertices[(x*2) + 1, y*2],
                                xvertices[(x*2) + 2, (y*2) + 1],
                                yvertices[(x*2) + 2, (y*2) + 1]
                                );
                        }

                        if (!cell.exitLeft)
                        {
                            Gl.glColor3fv(getColour(Properties.Settings.Default.ColorWalls));

                            drawCube(
                                xvertices[x*2, (y*2) + 1],
                                yvertices[x*2, (y*2) + 1],
                                xvertices[(x*2) + 1, (y*2) + 2],
                                yvertices[(x * 2) + 1, (y * 2) + 2],
                                true
                                );
                        }
                        else
                        {
                            Gl.glColor3fv(getColour(getDoorColour(cell.wLeft, cell)));
                            drawCube(
                                xvertices[x*2, (y*2) + 1],
                                yvertices[x*2, (y*2) + 1],
                                xvertices[(x*2) + 1, (y*2) + 2],
                                yvertices[(x*2) + 1, (y*2) + 2]
                                );
                        }

                        if ((x + 1) == cols)
                        {
                            Gl.glColor3fv(getColour(Properties.Settings.Default.ColorWalls));

                            drawCube(
                                xvertices[(x*2) + 2, (y*2) + 1],
                                yvertices[(x*2) + 2, (y*2) + 1],
                                xvertices[(x*2) + 3, (y*2) + 2],
                                yvertices[(x * 2) + 3, (y * 2) + 2],
                                true
                                );

                        }

                        if ((y + 1) == rows)
                        {
                            Gl.glColor3fv(getColour(Properties.Settings.Default.ColorWalls));

                            drawCube(
                                xvertices[(x*2) + 1, (y*2) + 2],
                                yvertices[(x*2) + 1, (y*2) + 2],
                                xvertices[(x*2) + 2, (y*2) + 3],
                                yvertices[(x * 2) + 3, (y * 2) + 3],
                                true
                                );

                        }

                        #endregion

                        #region cells

                        switch (cell.currentState)
                        {
                            case Block.State.Current:
                                Gl.glColor3fv(getColour(Properties.Settings.Default.ColorCurrentBlock));
                                break;
                            case Block.State.Exit:
                                Gl.glColor3fv(getColour(Properties.Settings.Default.ColorExitBlock));
                                break;
                            case Block.State.Unvisited:
                                Gl.glColor3fv(getColour(cell.hidden ? Properties.Settings.Default.ColorWalls : Properties.Settings.Default.ColorUnvisitedBlock));
                                break;
                            case Block.State.Visited:
                                Gl.glColor3fv(
                                    getColour(cell.inMaze
                                                  ? Properties.Settings.Default.ColorVisitedBlock
                                                  : Properties.Settings.Default.ColorIncorrectBlock));
                                break;
                        }
                        drawCube(
                            xvertices[(x*2) + 1, (y*2) + 1],
                            yvertices[(x*2) + 1, (y*2) + 1],
                            xvertices[(x*2) + 2, (y*2) + 2],
                            yvertices[(x*2) + 2, (y*2) + 2]
                            );

                        #endregion
                    }
                }
            }
            Gl.glPopMatrix();
        }

        protected virtual void positionScene(int cols, int rows, float[,] xvertices, float[,] yvertices)
        {
            float maxX = xvertices[(2*cols) + 1, (2*rows) + 1];
            float maxY = yvertices[(2*cols) + 1, (2*rows) + 1];

            float scaleX = 2/maxX;
            float scaleY = 2/maxY;

            Gl.glTranslatef(-1, 1, 0);
            Gl.glScalef(scaleX, -scaleY, 1);
        }

        protected virtual void drawCube(float x1, float y1, float x2, float y2, bool is3d = false)
        {
            Gl.glBegin(Gl.GL_POLYGON);
            Gl.glVertex3f(x1, y1, 0f);
            Gl.glVertex3f(x2, y1, 0f);
            Gl.glVertex3f(x2, y2, 0f);
            Gl.glVertex3f(x1, y2, 0f);


            Gl.glEnd();
        }

        protected float[] getColour(Color color)
        {
            float[] colvector = new float[3];

            colvector[0] = ((float) ((uint) color.R)/255);
            colvector[1] = ((float) ((uint) color.G)/255);
            colvector[2] = ((float) ((uint) color.B)/255);

            return colvector;
        }
    }
}
