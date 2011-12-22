using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BeebMaze.Properties;

namespace BeebMaze.Render
{
    public partial class MazeRenderScreen : UserControl
    {
        public MazeRenderScreen()
        {
            InitializeComponent();
            rendererToolStripStatusLabel.Text = string.Format(rendererToolStripStatusLabel.Tag.ToString(),
                                                  "Generic");
        }

        protected Block[,] lastKnownMaze;


        /// <summary>
        /// Draws the cube.
        /// </summary>
        /// <param name="x1">The x1.</param>
        /// <param name="y1">The y1.</param>
        /// <param name="x2">The x2.</param>
        /// <param name="y2">The y2.</param>
        /// <param name="is3d">if set to <c>true</c> [is3d].</param>
        protected virtual void drawCube(float x1, float y1, float x2, float y2, bool is3d = false)
        {
            throw new NotImplementedException();
        }

        protected virtual float[] getColour(Color color)
        {
            float[] colvector = new float[3];

            colvector[0] = ((float)((uint)color.R) / 255);
            colvector[1] = ((float)((uint)color.G) / 255);
            colvector[2] = ((float)((uint)color.B) / 255);

            return colvector;
        }
        protected Block[,] maze = new Block[0, 0];
        protected virtual void positionScene(int cols, int rows, float[,] xvertices, float[,] yvertices)
        {
            throw new NotImplementedException();
        }

        protected virtual void setColour(float r, float g, float b)
        {
            throw new NotImplementedException();
        }
        protected virtual void setColour(float[] v)
        {
            throw new NotImplementedException();
        }

        protected void drawScene()
        {
            int rows = this.maze.GetUpperBound(1) + 1,
                cols = this.maze.GetUpperBound(0) + 1;


            // x,y
            float[,] xvertices = new float[(2 * cols) + 2, (2 * rows) + 2];
            float[,] yvertices = new float[(2 * cols) + 2, (2 * rows) + 2];


            const float cellWidth = 0.3f;
            const float cellHeight = 0.3f;

            const float wallWidth = 0.1f;
            const float wallHeight = 0.1f;

            float xval = 0;
            for (int x = 0; x < (2 * cols) + 2; x++)
            {
                if (x != 0) xval += x % 2 == 0 ? cellWidth : wallWidth;

                float yval = 0;
                for (int y = 0; y < (2 * rows) + 2; y++)
                {
                    if (y != 0) yval += y % 2 == 0 ? cellHeight : wallHeight;

                    xvertices[x, y] = xval;
                    yvertices[x, y] = yval;
                }
            }

            positionScene(cols, rows, xvertices, yvertices);

            setColour(getColour(Properties.Settings.Default.ColorWalls));

            #region wall corners

            for (int x = 0; x <= cols; x++)
            {
                for (int y = 0; y <= rows; y++)
                {
                    drawCube(
                        xvertices[x * 2, y * 2],
                        yvertices[x * 2, y * 2],
                        xvertices[(x * 2) + 1, (y * 2) + 1],
                        yvertices[(x * 2) + 1, (y * 2) + 1],
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
                        setColour(getColour(Properties.Settings.Default.ColorWalls));

                        drawCube(
                            xvertices[(x * 2) + 1, y * 2],
                            yvertices[(x * 2) + 1, y * 2],
                            xvertices[(x * 2) + 2, (y * 2) + 1],
                            yvertices[(x * 2) + 2, (y * 2) + 1],
                            true
                            );
                    }
                    else
                    {
                        setColour(getColour(getDoorColour(cell.wTop, cell)));
                        drawCube(
                            xvertices[(x * 2) + 1, y * 2],
                            yvertices[(x * 2) + 1, y * 2],
                            xvertices[(x * 2) + 2, (y * 2) + 1],
                            yvertices[(x * 2) + 2, (y * 2) + 1]
                            );
                    }

                    if (!cell.exitLeft)
                    {
                        setColour(getColour(Properties.Settings.Default.ColorWalls));

                        drawCube(
                            xvertices[x * 2, (y * 2) + 1],
                            yvertices[x * 2, (y * 2) + 1],
                            xvertices[(x * 2) + 1, (y * 2) + 2],
                            yvertices[(x * 2) + 1, (y * 2) + 2],
                            true
                            );
                    }
                    else
                    {
                        setColour(getColour(getDoorColour(cell.wLeft, cell)));
                        drawCube(
                            xvertices[x * 2, (y * 2) + 1],
                            yvertices[x * 2, (y * 2) + 1],
                            xvertices[(x * 2) + 1, (y * 2) + 2],
                            yvertices[(x * 2) + 1, (y * 2) + 2]
                            );
                    }

                    if ((x + 1) == cols)
                    {
                        setColour(getColour(Properties.Settings.Default.ColorWalls));

                        drawCube(
                            xvertices[(x * 2) + 2, (y * 2) + 1],
                            yvertices[(x * 2) + 2, (y * 2) + 1],
                            xvertices[(x * 2) + 3, (y * 2) + 2],
                            yvertices[(x * 2) + 3, (y * 2) + 2],
                            true
                            );

                    }

                    if ((y + 1) == rows)
                    {
                        setColour(getColour(Properties.Settings.Default.ColorWalls));

                        drawCube(
                            xvertices[(x * 2) + 1, (y * 2) + 2],
                            yvertices[(x * 2) + 1, (y * 2) + 2],
                            xvertices[(x * 2) + 2, (y * 2) + 3],
                            yvertices[(x * 2) + 3, (y * 2) + 3],
                            true
                            );

                    }

                    #endregion

                    #region cells

                    switch (cell.currentState)
                    {
                        case Block.State.Current:
                            setColour(getColour(Properties.Settings.Default.ColorCurrentBlock));
                            break;
                        case Block.State.Exit:
                            setColour(getColour(Properties.Settings.Default.ColorExitBlock));
                            break;
                        case Block.State.Unvisited:
                            setColour(
                                getColour(cell.hidden
                                              ? Properties.Settings.Default.ColorWalls
                                              : Properties.Settings.Default.ColorUnvisitedBlock));
                            break;
                        case Block.State.Visited:
                            setColour(
                                getColour(cell.inMaze
                                              ? Properties.Settings.Default.ColorVisitedBlock
                                              : Properties.Settings.Default.ColorIncorrectBlock));
                            break;
                    }
                    drawCube(
                        xvertices[(x * 2) + 1, (y * 2) + 1],
                        yvertices[(x * 2) + 1, (y * 2) + 1],
                        xvertices[(x * 2) + 2, (y * 2) + 2],
                        yvertices[(x * 2) + 2, (y * 2) + 2]
                        );

                    #endregion
                }
            }

        }


        public virtual void render(Block[,] maze)
        {
           
            if(maze == null)
                maze = lastKnownMaze;
            if(maze == null)
                maze = new Block[0,0];

            if(maze.Length != 0)
                lastKnownMaze = maze;

            this.maze = maze;
        }

        internal static MazeRenderScreen Create()
        {
            return (MazeRenderScreen) Activator.CreateInstance(whatAmI(Settings.Default.DisplayDriver));
        }

        private void MazeRenderScreen_Paint(object sender, PaintEventArgs e)
        {
            //render(lastKnownMaze);
        }

        internal static Type whatAmI(int identifier)
        {
            switch (identifier)
            {
                case Settings.DISPLAY_DRIVER_NULL:
                    return typeof(NullMazeRenderScreen);
                case Settings.DISPLAY_DRIVER_NET:
                    return typeof (DotNetMazeRenderScreen);
                case Settings.DISPLAY_DRIVER_GL2:
                    return typeof (Gl2MazeRenderScreen);
                case Settings.DISPLAY_DRIVER_GL3:
                    return typeof (Gl3MazeRenderScreen);
                default:
                    return null;
            }
        }

        internal static int whatAmI(Type identifier)
        {
            throw new NotImplementedException();
        }

        protected Color getDoorColour(Wall w, Block currentCell)
        {
            Block.State doorState = Block.State.Unvisited;

            if (currentCell.hidden && w.getOpposite(currentCell).hidden)
                return Settings.Default.ColorWalls;

            if (!Settings.Default.UseFancyDoors) return Settings.Default.ColorDoors;


            if (w.getOpposite(currentCell).currentState != currentCell.currentState)
            { // check exit and current states

                // use non-current state for when it's next to each other
                if (currentCell.currentState == Block.State.Current)
                    doorState = w.getOpposite(currentCell).currentState;
                if (w.getOpposite(currentCell).currentState == Block.State.Current)
                    doorState = currentCell.currentState;

                if (currentCell.currentState == Block.State.Exit)
                    doorState = w.getOpposite(currentCell).currentState;
                if (w.getOpposite(currentCell).currentState == Block.State.Exit)
                    doorState = currentCell.currentState;

                if (!Program.app.solvedMaze)
                {
                    if (currentCell.currentState == Block.State.Exit
                        && w.getOpposite(currentCell).currentState == Block.State.Current)
                        doorState = Block.State.Unvisited;
                    if (currentCell.currentState == Block.State.Current
                        && w.getOpposite(currentCell).currentState == Block.State.Exit)
                        doorState = Block.State.Visited;
                }
                else
                {
                    if (currentCell.currentState == Block.State.Exit
                         && w.getOpposite(currentCell).currentState == Block.State.Current)
                        doorState = Block.State.Current;
                    if (currentCell.currentState == Block.State.Current
                        && w.getOpposite(currentCell).currentState == Block.State.Exit)
                        doorState = Block.State.Current;
                }
            }
            else
            { // same state, mark as same colour
                doorState = currentCell.currentState;
            }

            switch (doorState)
            {
                case Block.State.Unvisited:
                    return Properties.Settings.Default.ColorDoors;
                case Block.State.Current:
                    return Properties.Settings.Default.ColorCurrentBlock;
                case Block.State.Visited:
                    return Properties.Settings.Default.ColorVisitedBlock;
                case Block.State.Exit:
                    return Properties.Settings.Default.ColorExitBlock;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

    }
}
