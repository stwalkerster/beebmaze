using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BeebMaze.Render
{
    public partial class MazeRenderScreen : UserControl
    {
        public MazeRenderScreen()
        {
            InitializeComponent();
        }

        private Block[,] lastKnownMaze;

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
            return new NullMazeRenderScreen();
        }

        private void MazeRenderScreen_Paint(object sender, PaintEventArgs e)
        {
            render(lastKnownMaze);
        }
    }
}
