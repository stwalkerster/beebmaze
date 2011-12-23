using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using BeebMaze.Properties;
using BeebMaze.Render;

namespace BeebMaze
{
    public partial class MainForm : Form
    {
        private readonly object _mazeLock = new object();

        //private Block _exitBlock;
        //private int _height;
      //  private Block[,] _maze;
        private Maze _realMaze;
        private MazeRenderScreen _mazePanel;

        private Thread _regenerationThread;
        //private int _width;


        public MainForm()
        {
            InitializeComponent();
        }

        //private Block currentBlock { get; set; }

        private void form1Load(object sender, EventArgs e)
        {
            generationComplete += form1GenerationComplete;
            generateMaze(Settings.Default.MazeSize);
        }


        private void form1GenerationComplete(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                EventHandler eh = form1GenerationComplete;
                Invoke(eh, sender, e);
                return;
            }

            panel1.Controls.Add(_mazePanel);

            panel1.Visible = true;
        }

        private void generateMaze(int resolution)
        {
            panel1.Visible = false;
            panel1.Controls.Clear();
            
            updateData("Initialising thread...", -1);

            Thread.Sleep(100);

            var tsd = new ThreadStartData
                          {
                              height = panel1.Width / resolution,
                              width = panel1.Height / resolution,
                          };

            _regenerationThread = new Thread(regenerationThread_DoWork) {Priority = ThreadPriority.Lowest};
            _regenerationThread.Start(tsd);
        }

        private event EventHandler generationComplete;

        public void form1KeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Down && _realMaze.currentBlock.exitBottom)
            {
                _realMaze.currentBlock.currentState = Block.State.Visited;
                performRender();
                _realMaze.currentBlock = _realMaze.currentBlock.wBottom.getOpposite(_realMaze.currentBlock);
                _realMaze.currentBlock.currentState = Block.State.Current;
                performRender();
            }

            if (e.KeyCode == Keys.Up && _realMaze.currentBlock.exitTop)
            {
                _realMaze.currentBlock.currentState = Block.State.Visited;
                performRender();
                _realMaze.currentBlock = _realMaze.currentBlock.wTop.getOpposite(_realMaze.currentBlock);
                _realMaze.currentBlock.currentState = Block.State.Current;
                performRender();
            }

            if (e.KeyCode == Keys.Left && _realMaze.currentBlock.exitLeft)
            {
                _realMaze.currentBlock.currentState = Block.State.Visited;
                performRender();
                _realMaze.currentBlock = _realMaze.currentBlock.wLeft.getOpposite(_realMaze.currentBlock);
                _realMaze.currentBlock.currentState = Block.State.Current;
                performRender();
            }

            if (e.KeyCode == Keys.Right && _realMaze.currentBlock.exitRight)
            {
                _realMaze.currentBlock.currentState = Block.State.Visited;
                performRender();
                _realMaze.currentBlock = _realMaze.currentBlock.wRight.getOpposite(_realMaze.currentBlock);
                _realMaze.currentBlock.currentState = Block.State.Current;
                performRender();
            }

            if (_realMaze.currentBlock == _realMaze.exitBlock)
                _realMaze.solve();

        }

        public void performRender()
        {
            if(_mazePanel == null || (_mazePanel.GetType() != MazeRenderScreen.whatAmI(Settings.Default.DisplayDriver)))
            {
                panel1.Controls.Clear();
                _mazePanel = MazeRenderScreen.Create();
                _mazePanel.Dock = DockStyle.Fill;
                panel1.Controls.Add(_mazePanel);
            }

            lock (_mazeLock)
            {
                _mazePanel.render(_realMaze);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            generateMaze(Settings.Default.MazeSize);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            _realMaze.solve();
        }

        private void regenerationThread_DoWork(object startData)
        {
            var data = (ThreadStartData) startData;

            int width = data.width;
            int height = data.height;

            updateData("Generating maze", 0);

            Maze realMaze = new Maze(width, height);
            
            
            updateData("Rendering maze", 0);
            lock (_mazeLock)
            {
                this._realMaze = realMaze;
            }

            this.Invoke(new Action(performRender));

            updateData("Drawing completed maze", -1);

            generationComplete(this, new EventArgs());
        }

        private void updateData(string message = "", int percent = -2)
        {
            if (InvokeRequired)
            {
                //Thread.Sleep(10);
                UpdateDataDelegate udd = updateData;
                Invoke(udd, message, percent);
                return;
            }

            if (message != "")
            {
                label2.Text = message;
            }
            if (percent <= 100 && percent >= 0)
            {
                progressBar1.Style = ProgressBarStyle.Continuous;
                progressBar1.Value = percent;
            }
            if (percent == -1)
                progressBar1.Style = ProgressBarStyle.Marquee;
        }

        private void form1FormClosing(object sender, FormClosingEventArgs e)
        {
            _regenerationThread.Abort();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            new Options().ShowDialog();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            performRender();
        }

        private void form1Resize(object sender, EventArgs e)
        {
            performRender();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            new AboutBox1().ShowDialog();
        }

        #region Nested type: ThreadStartData

        private struct ThreadStartData
        {
            public int height;
            public int width;
        }

        #endregion

        #region Nested type: UpdateDataDelegate

        private delegate void UpdateDataDelegate(string message, int percent);

        #endregion
    }
}