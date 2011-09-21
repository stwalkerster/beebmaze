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
    public abstract partial class MazeRenderScreen : UserControl
    {
        protected MazeRenderScreen()
        {
            InitializeComponent();
        }
    }
}
