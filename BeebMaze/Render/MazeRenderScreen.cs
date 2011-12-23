using System;
using System.Drawing;
using System.Windows.Forms;
using BeebMaze.Properties;

namespace BeebMaze.Render
{
    public abstract partial class MazeRenderScreen : UserControl
    {
        protected MazeRenderScreen()
        {
            InitializeComponent();
            rendererToolStripStatusLabel.Text = string.Format(rendererToolStripStatusLabel.Tag.ToString(),
                                                  "Generic");
        }

        protected Maze lastKnownMaze;


        /// <summary>
        /// Draws the cube.
        /// </summary>
        /// <param name="x1">The x1.</param>
        /// <param name="y1">The y1.</param>
        /// <param name="x2">The x2.</param>
        /// <param name="y2">The y2.</param>
        /// <param name="is3d">if set to <c>true</c> [is3d].</param>
        protected abstract void drawCube(float x1, float y1, float x2, float y2, bool is3d = false);

        protected virtual float[] getColour(Color color)
        {
            float[] colvector = new float[3];

            colvector[0] = ((float)color.R / 255);
            colvector[1] = ((float)color.G / 255);
            colvector[2] = ((float)color.B / 255);

            return colvector;
        }
        protected Maze maze;
        protected abstract void positionScene(int cols, int rows, float[,] xvertices, float[,] yvertices);

        protected abstract void setColour(float r, float g, float b);

        protected abstract void setColour(float[] v);

        protected void drawScene()
        {
            int rows = this.maze.Height,
                cols = this.maze.Width;


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

            setColour(getColour(Settings.Default.ColorWalls));

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
                        setColour(getColour(Settings.Default.ColorWalls));

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
                        setColour(getColour(Settings.Default.ColorWalls));

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
                        setColour(getColour(Settings.Default.ColorWalls));

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
                        setColour(getColour(Settings.Default.ColorWalls));

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
                            setColour(getColour(Settings.Default.ColorCurrentBlock));
                            break;
                        case Block.State.Exit:
                            setColour(getColour(Settings.Default.ColorExitBlock));
                            break;
                        case Block.State.Unvisited:
                            setColour(
                                getColour(cell.hidden
                                              ? Settings.Default.ColorWalls
                                              : Settings.Default.ColorUnvisitedBlock));
                            break;
                        case Block.State.Visited:
                            setColour(
                                getColour(Settings.Default.ColorVisitedBlock)
                                );
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


        public virtual void render(Maze pmaze)
        {

            if (pmaze == null)
                pmaze = lastKnownMaze;
            else
                lastKnownMaze = pmaze;

            this.maze = pmaze;
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

                if (!maze.isSolved)
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
                    return Settings.Default.ColorDoors;
                case Block.State.Current:
                    return Settings.Default.ColorCurrentBlock;
                case Block.State.Visited:
                    return Settings.Default.ColorVisitedBlock;
                case Block.State.Exit:
                    return Settings.Default.ColorExitBlock;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

    }
}
