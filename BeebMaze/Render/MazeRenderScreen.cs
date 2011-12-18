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

        public virtual void render(Block[,] maze)
        {
           
            if(maze == null)
                maze = lastKnownMaze;
            if(maze == null)
                maze = new Block[0,0];

            if(maze.Length != 0)
                lastKnownMaze = maze;
       

        }

        internal static MazeRenderScreen Create()
        {
            return (MazeRenderScreen) Activator.CreateInstance(whatAmI(Settings.Default.DisplayDriver));
        }

        private void MazeRenderScreen_Paint(object sender, PaintEventArgs e)
        {
            render(lastKnownMaze);
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
