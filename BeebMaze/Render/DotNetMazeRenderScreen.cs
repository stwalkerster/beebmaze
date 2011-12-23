using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BeebMaze.Render
{
    public partial class DotNetMazeRenderScreen : BeebMaze.Render.MazeRenderScreen
    {
        public DotNetMazeRenderScreen()
        {
            InitializeComponent();
            rendererToolStripStatusLabel.Text = string.Format(rendererToolStripStatusLabel.Tag.ToString(),
                                                  "GDI+ Renderer (.NET Framework System.Drawing.Graphics)");
            panel1.Paint += new PaintEventHandler(panel1_Paint);
            panel1.PreviewKeyDown += Program.app.form1KeyDown;
        }

        // global eurgh!
        private Graphics paintGraphics;

        void panel1_Paint(object sender, PaintEventArgs e)
        {
            paintGraphics = e.Graphics;
            drawScene();
            paintGraphics = null;
        }

        private Color col = Color.White;
        private float _scaleX;
        private float _scaleY;

        public override void render(Maze pmaze)
        {
            this.maze = pmaze;
            panel1.Invalidate();


        }

        protected override void setColour(float r, float g, float b)
        {
            col = Color.FromArgb((int) (r*255), (int) (b*255), (int) (b*255));
        }
        protected override void setColour(float[] v)
        {
            col = Color.FromArgb((int)(v[0] * 255), (int)(v[1] * 255), (int)(v[2] * 255));
        }

        protected override void positionScene(int cols, int rows, float[,] xvertices, float[,] yvertices)
        {
            float maxX = xvertices[(2 * cols) + 1, (2 * rows) + 1];
            float maxY = yvertices[(2 * cols) + 1, (2 * rows) + 1];

            _scaleX = panel1.Width / maxX;
            _scaleY = panel1.Height / maxY;
        }

        protected override void performMove(Keys direction)
        {
            switch (direction)
            {
                case Keys.W:
                    maze.move(Maze.Direction.UP);
                    break;
                case Keys.A:
                    maze.move(Maze.Direction.LEFT);
                    break;
                case Keys.S:
                    maze.move(Maze.Direction.DOWN);
                    break;
                case Keys.D:
                    maze.move(Maze.Direction.RIGHT);
                    break;     
            }
        }

        protected override void drawCube(float x1, float y1, float x2, float y2, bool is3d = false)
        {
            paintGraphics.FillPolygon(
                new SolidBrush(col),
                new Point[]
                    {
                        new Point((int)(x1*_scaleX),(int)(y1*_scaleY)), 
                        new Point((int)(x2*_scaleX),(int)(y1*_scaleY)), 
                        new Point((int)(x2*_scaleX),(int)(y2*_scaleY)), 
                        new Point((int)(x1*_scaleX),(int)(y2*_scaleY)), 
                    }
                );
        }
    }
}
