using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeebMaze
{
    public class Block
    {
        public enum State
        {
            Unvisited,
            Current,
            Visited,
            Exit
        }

        public bool hidden { get; set; }

        private State _currentState = State.Unvisited;
        public bool isExit;
        public State currentState
        {
            get { return _currentState; }
            set
            {
                if(value == State.Current)
                    hidden = false;
                _currentState = isExit ? State.Exit : value;
            }
        }

        public bool inMaze { get; set; }

        public bool exitLeft
        {
            get
            {
                if (wLeft == null)
                    return false;
                return !wLeft.present;
            }
        }

        public bool exitTop
        {
            get
            {
                if (wTop == null)
                    return false;
                return !wTop.present;
            }
        }

        public bool exitRight
        {
            get
            {
                if (wRight == null)
                    return false;
                return !wRight.present;
            }
        }

        public bool exitBottom
        {
            get
            {
                if (wBottom == null)
                    return false;
                return !wBottom.present;
            }
        }

        public Wall wTop { get; set; }
        public Wall wRight { get; set; }
        public Wall wLeft { get; set; }
        public Wall wBottom { get; set; }

        public int countEffectiveWalls()
        {
            if (currentState == State.Exit)
                return 0;

            int count = 0;
            if (wTop != null)
            {
                if (wTop.present) count++;
                else if (!wTop.getOpposite(this).inMaze) count++;
            }
            else count++;
            if (wBottom != null)
            {
                if (wBottom.present) count++;
                else if (!wBottom.getOpposite(this).inMaze) count++;
            }
            else count++;
            if (wLeft != null)
            {
                if (wLeft.present) count++;
                else if (!wLeft.getOpposite(this).inMaze) count++;
            }
            else count++;
            if (wRight != null)
            {
                if (wRight.present) count++;
                else if (!wRight.getOpposite(this).inMaze) count++;
            }
            else count++;

            return count;
        }

  
        public int positionX, positionY;
    }
}
