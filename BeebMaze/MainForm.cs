﻿using System;
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
            solvedMaze = false;

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

            solvedMaze = true;

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
                        block.hidden = false;
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

        public bool solvedMaze
        {
            get; private set;
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

            updateData("Generating maze", 0);

            var maze = new Maze(width, height).exportMaze();



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