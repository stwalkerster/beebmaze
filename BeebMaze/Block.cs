using System.Drawing;
using System.Windows.Forms;
using BeebMaze.Properties;

namespace BeebMaze
{
    public partial class Block : UserControl
    {
        #region State enum

        public enum State
        {
            Unvisited,
            Current,
            Visited,
            Exit
        }

        #endregion

        public static int cornerSize = 3;
        public static int doorWidth = 3;

        private State _currentState = State.Unvisited;
        public bool isExit;

        public int positionX, positionY;

        public Block()
        {
            InitializeComponent();
        }


        public bool revealMaze { get; set; }

        public State currentState
        {
            get { return _currentState; }
            set { _currentState = isExit ? State.Exit : value; }
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

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Brush lineColor = new SolidBrush(Settings.Default.ColorWalls);
            Brush revealColor = new SolidBrush(Settings.Default.ColorUnvisitedBlock);
            Brush visitedColor = new SolidBrush(Settings.Default.ColorVisitedBlock);
            Brush passageColor = new SolidBrush(Settings.Default.ColorDoors);
            Brush exitColor = new SolidBrush(Settings.Default.ColorExitBlock);
            Brush currentColor = new SolidBrush(Settings.Default.ColorCurrentBlock);
            Brush errorColor = new SolidBrush(Settings.Default.ColorIncorrectBlock);

            if (currentState == State.Unvisited)
                e.Graphics.FillRectangle(revealMaze ? revealColor : lineColor, cornerSize, cornerSize,
                                         Width - cornerSize, Width - cornerSize);
            if (currentState == State.Visited)
                e.Graphics.FillRectangle(visitedColor, cornerSize, cornerSize, Width - cornerSize,
                                         Width - cornerSize);
            if (currentState == State.Current)
                e.Graphics.FillRectangle(currentColor, cornerSize, cornerSize, Width - cornerSize,
                                         Width - cornerSize);
            if (currentState == State.Exit)
                e.Graphics.FillRectangle(exitColor, cornerSize, cornerSize, Width - cornerSize,
                                         Width - cornerSize);

            if (!inMaze && currentState == State.Visited)
                e.Graphics.FillRectangle(errorColor, cornerSize, cornerSize, Width - cornerSize,
                                         Width - cornerSize);

            if (!inMaze && currentState == State.Unvisited)
                e.Graphics.FillRectangle(revealColor, cornerSize, cornerSize, Width - cornerSize,
                                         Width - cornerSize);


            e.Graphics.FillRectangle(
                exitTop && (currentState != State.Unvisited || revealMaze)
                    ? (revealMaze ? revealColor : passageColor)
                    : lineColor, 0, 0, Width, doorWidth);

            e.Graphics.FillRectangle(
                exitRight && (currentState != State.Unvisited || revealMaze)
                    ? (revealMaze ? revealColor : passageColor)
                    : lineColor, Width - doorWidth, 0, doorWidth, Width);

            e.Graphics.FillRectangle(
                exitBottom && (currentState != State.Unvisited || revealMaze)
                    ? (revealMaze ? revealColor : passageColor)
                    : lineColor, 0, Width - doorWidth, Width, doorWidth);

            e.Graphics.FillRectangle(
                exitLeft && (currentState != State.Unvisited || revealMaze)
                    ? (revealMaze ? revealColor : passageColor)
                    : lineColor, 0, 0, doorWidth, Width);

            e.Graphics.FillRectangle(lineColor, 0, 0, cornerSize, cornerSize);
            e.Graphics.FillRectangle(lineColor, Width - cornerSize, Width - cornerSize, Width, Width);
            e.Graphics.FillRectangle(lineColor, Width - cornerSize, 0, Width, cornerSize);
            e.Graphics.FillRectangle(lineColor, 0, Width - cornerSize, cornerSize, Width);
        }

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
    }
}