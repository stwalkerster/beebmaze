using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BeebMaze.Properties;

namespace BeebMaze
{
    class Maze
    {
        public  Maze(int width, int height)
        {
            this.Height = height;
            this.Width = width;

            this.generate();
        }

        private void generate()
        {
            mazeBlocks = new Block[this.Width,this.Height];

            for (int x = 0; x < this.Width; x++)
            {
                for (int y = 0; y < this.Height; y++)
                {
                    mazeBlocks[x, y] = new Block();
                    Wall w;

                    if (x != 0)
                    {
                        w = new Wall(mazeBlocks[x, y], mazeBlocks[x - 1, y], true);
                        mazeBlocks[x, y].wLeft = w;
                        mazeBlocks[x - 1, y].wRight = w;
                    }

                    if (y != 0)
                    {
                        w = new Wall(mazeBlocks[x, y], mazeBlocks[x, y - 1], true);
                        mazeBlocks[x, y].wTop = w;
                        mazeBlocks[x, y - 1].wBottom = w;
                    }

                    mazeBlocks[x, y].hidden = !Settings.Default.RevealMaze;
                }
            }


            var walls = new List<KeyValuePair<Wall, Block>>();
            Block startBlock = mazeBlocks[0, 0];

            startBlock.isExit = true;
            startBlock.inMaze = true;

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
                // Pick a random wall from the list. If the cell on the opposite side isn't in the maze yet:
                int wallId = rnd.Next(0, walls.Count);

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


            this.exitBlock = mazeBlocks[this.Width - 1, this.Height - 1];
            this.exitBlock.isExit = true;
            this.exitBlock.currentState = Block.State.Exit;

            currentBlock = startBlock;
            currentBlock.currentState = Block.State.Current;
        }

        private Block[,] mazeBlocks;

        private Block exitBlock;

        public Block currentBlock { get; set; }
        public bool isSolved { get; set; }

        public int Width
        {
            get;
            private set;
        }
        public int Height
        {
            get; private set;
        }

        public Block this[int x, int y]
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public void solve()
        {
            
        }

        [Obsolete]
        public void importMaze(Block[,] maze)
        {
            mazeBlocks = maze;
        }

        [Obsolete]
        public Block[,] exportMaze()
        {
            return mazeBlocks;
        }
    }
}
