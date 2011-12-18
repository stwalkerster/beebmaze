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

        private Block _exitBlock;
        private int _height;
        private Block[,] _maze;
        private MazeRenderScreen _mazePanel;

        private Thread _regenerationThread;
        private int _width;

        private int lastRenderType = Settings.Default.DisplayDriver;
        
        public MainForm()
        {
            InitializeComponent();
        }

        private Block currentBlock { get; set; }

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
            currentBlock = null;
            _exitBlock = null;

            _width = panel1.Width/resolution;
            _height = panel1.Height/resolution;
            _maze = null;

            updateData("Initialising thread...", -1);

            Thread.Sleep(100);

            var tsd = new ThreadStartData
                          {
                              height = _height,
                              width = _width,
                              useMax = Settings.Default.PrimsRandomUseMax,
                              randommaximum = (int) Settings.Default.PrimsRandomMaximum,
                          };

            _regenerationThread = new Thread(regenerationThread_DoWork) {Priority = ThreadPriority.Lowest};
            _regenerationThread.Start(tsd);
        }

        private event EventHandler generationComplete;

        public void form1KeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Down && currentBlock.exitBottom)
            {
                currentBlock.currentState = Block.State.Visited;
                performRender();
                currentBlock = currentBlock.wBottom.getOpposite(currentBlock);
                currentBlock.currentState = Block.State.Current;
                performRender();
            }

            if (e.KeyCode == Keys.Up && currentBlock.exitTop)
            {
                currentBlock.currentState = Block.State.Visited;
                performRender();
                currentBlock = currentBlock.wTop.getOpposite(currentBlock);
                currentBlock.currentState = Block.State.Current;
                performRender();
            }

            if (e.KeyCode == Keys.Left && currentBlock.exitLeft)
            {
                currentBlock.currentState = Block.State.Visited;
                performRender();
                currentBlock = currentBlock.wLeft.getOpposite(currentBlock);
                currentBlock.currentState = Block.State.Current;
                performRender();
            }

            if (e.KeyCode == Keys.Right && currentBlock.exitRight)
            {
                currentBlock.currentState = Block.State.Visited;
                performRender();
                currentBlock = currentBlock.wRight.getOpposite(currentBlock);
                currentBlock.currentState = Block.State.Current;
                performRender();
            }

            if (currentBlock == _exitBlock)
                solveMaze();
        }

        private void performRender()
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
                _mazePanel.render(_maze);
            }
        }

        private void solveMaze()
        {
            bool changed;

            do
            {
                changed = false;
                for (int x = 0; x < _width; x++)
                {
                    for (int y = 0; y < _height; y++)
                    {
                        Block block = _maze[x, y];

                        if (!block.inMaze) continue;

                        if (block.countEffectiveWalls() != 3) continue;

                        block.inMaze = false;
                        changed = true;
                    }
                }
            } while (changed);

            for (int x = 0; x < _width; x++)
            {
                for (int y = 0; y < _height; y++)
                {
                    if (_maze[x, y].inMaze)
                    {
                        _maze[x, y].currentState = Block.State.Current;
                        performRender();
                    }
                    else
                    {
                        //if(_maze[x,y].currentState == Block.State.Visited)
                        performRender();
                    }
                }
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            generateMaze(Settings.Default.MazeSize);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            solveMaze();
        }

        private void regenerationThread_DoWork(object startData)
        {
            var data = (ThreadStartData) startData;

            int width = data.width;
            int height = data.height;


            var maze = new Block[width,height];

            updateData("Generating blocks...");

            for (int x = 0; x < width; x++)
            {
                updateData(percent: x/width);
                for (int y = 0; y < height; y++)
                {
                    maze[x, y] = new Block();

                    Wall w;

                    if (x != 0)
                    {
                        w = new Wall(maze[x, y], maze[x - 1, y], true);
                        maze[x, y].wLeft = w;
                        maze[x - 1, y].wRight = w;
                    }

                    if (y != 0)
                    {
                        w = new Wall(maze[x, y], maze[x, y - 1], true);
                        maze[x, y].wTop = w;
                        maze[x, y - 1].wBottom = w;
                    }
                }
            }

            updateData("Starting Prim's", 0/((width*height*2) + width + height));

            // start randomised prim's algorithm

            // using 0,0 as initial maze block

            var walls = new List<KeyValuePair<Wall, Block>>();

            Block startBlock = maze[0, 0];

            startBlock.inMaze = true;
            startBlock.isExit = true;

            if (startBlock.wTop != null)
                walls.Add(new KeyValuePair<Wall, Block>(startBlock.wTop, startBlock));
            if (startBlock.wRight != null)
                walls.Add(new KeyValuePair<Wall, Block>(startBlock.wRight, startBlock));
            if (startBlock.wBottom != null)
                walls.Add(new KeyValuePair<Wall, Block>(startBlock.wBottom, startBlock));
            if (startBlock.wLeft != null)
                walls.Add(new KeyValuePair<Wall, Block>(startBlock.wLeft, startBlock));

            var rnd = new Random();

            // While there are walls in the list:
            int maxWalls = 400;
            while (walls.Count > 0)
            {
                maxWalls = walls.Count > maxWalls ? walls.Count : maxWalls;
                updateData("Running Prim's: " + walls.Count + " / " + maxWalls + " = " + walls.Count*100/maxWalls,
                           walls.Count*100/maxWalls);
                // Pick a random wall from the list. If the cell on the opposite side isn't in the maze yet:
                int wallId = rnd.Next(0,
                                      data.useMax
                                          ? walls.Count
                                          : (walls.Count > data.randommaximum ? data.randommaximum : walls.Count));

                Block newBlock = walls[wallId].Key.getOpposite(walls[wallId].Value);

                if (!newBlock.inMaze)
                {
                    // Make the wall a passage and mark the cell on the opposite side as part of the maze.
                    walls[wallId].Key.present = false;
                    newBlock.inMaze = true;

                    // Add the neighboring walls of the cell to the wall list.
                    if (newBlock.wLeft != null)
                        walls.Add(new KeyValuePair<Wall, Block>(newBlock.wLeft, newBlock));
                    if (newBlock.wRight != null)
                        walls.Add(new KeyValuePair<Wall, Block>(newBlock.wRight, newBlock));
                    if (newBlock.wTop != null)
                        walls.Add(new KeyValuePair<Wall, Block>(newBlock.wTop, newBlock));
                    if (newBlock.wBottom != null)
                        walls.Add(new KeyValuePair<Wall, Block>(newBlock.wBottom, newBlock));
                }

                walls.RemoveAt(wallId);
            }


            _exitBlock = maze[width - 1, height - 1];
            _exitBlock.isExit = true;
            _exitBlock.currentState = Block.State.Exit;

            currentBlock = startBlock;
            currentBlock.currentState = Block.State.Current;


            updateData("Rendering maze", 0);
            lock (_mazeLock)
            {
                _maze = maze;
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
            public int randommaximum;
            public bool useMax;
            public int width;
        }

        #endregion

        #region Nested type: UpdateDataDelegate

        private delegate void UpdateDataDelegate(string message, int percent);

        #endregion
    }
}