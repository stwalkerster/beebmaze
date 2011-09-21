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
    public partial class NullMazeRenderScreen : UserControl
    {
        public NullMazeRenderScreen()
        {
            InitializeComponent();
        }

        public virtual void render(Block[,] maze)
        {

        }

        internal static NullMazeRenderScreen Create()
        {
            return new NullMazeRenderScreen();
        }
    }
}
