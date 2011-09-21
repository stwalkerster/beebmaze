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
    }
}
