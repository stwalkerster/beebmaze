using System;
using System.Windows.Forms;

namespace BeebMaze.Render
{
    public partial class NullMazeRenderScreen : MazeRenderScreen
    {
        public NullMazeRenderScreen()
        {
            InitializeComponent();
            rendererToolStripStatusLabel.Text = string.Format(rendererToolStripStatusLabel.Tag.ToString(),
                                                  "Null");

        }

        public override void render(Maze pmaze)
        {
            base.render(pmaze);
            
            statX.Text = pmaze.Width.ToString();
            statY.Text = pmaze.Height.ToString();
            statRendered.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
        }

        #region Overrides of MazeRenderScreen

        protected override void performMove(Keys direction)
        {
            
        }

        /// <summary>
        /// Draws the cube.
        /// </summary>
        /// <param name="x1">The x1.</param>
        /// <param name="y1">The y1.</param>
        /// <param name="x2">The x2.</param>
        /// <param name="y2">The y2.</param>
        /// <param name="is3d">if set to <c>true</c> [is3d].</param>
        protected override void drawCube(float x1, float y1, float x2, float y2, bool is3d = false)
        {
            throw new NotImplementedException();
        }

        protected override void positionScene(int cols, int rows, float[,] xvertices, float[,] yvertices)
        {
            throw new NotImplementedException();
        }

        protected override void setColour(float r, float g, float b)
        {
            throw new NotImplementedException();
        }

        protected override void setColour(float[] v)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
