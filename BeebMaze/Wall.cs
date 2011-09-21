namespace BeebMaze
{
    public class Wall
    {
        public Block a;
        public Block b;
        public bool present = true;

        public Wall(Block a, Block b, bool present)
        {
            this.a = a;
            this.b = b;
            this.present = present;
        }

        public Block getOpposite(Block x)
        {
            return x == a ? b : a;
        }
    }
}