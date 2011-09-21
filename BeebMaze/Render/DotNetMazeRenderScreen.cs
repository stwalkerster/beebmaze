using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BeebMaze
{
    public partial class DotNetMazeRenderScreen : MazeRenderScreen
    {
        public DotNetMazeRenderScreen()
        {
            InitializeComponent();
        }

        #region Overrides of MazeRenderScreen

        public override void render(Block[,] maze)
        {

        }

        #endregion
    }
}
