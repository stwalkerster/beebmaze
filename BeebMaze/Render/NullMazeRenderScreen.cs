using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BeebMaze.Render
{
    public partial class NullMazeRenderScreen : BeebMaze.Render.MazeRenderScreen
    {
        public NullMazeRenderScreen()
        {
            InitializeComponent();
        }

        public override void render(Block[,] maze)
        {
            base.render(maze);

            statX.Text = maze.GetLength(0).ToString();
            statY.Text = maze.GetLength(1).ToString();
            statRendered.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
        }
    }
}
