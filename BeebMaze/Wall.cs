namespace BeebMaze
{
    public class Wall
    {
        public BlockControl a;
        public BlockControl b;
        public bool present = true;

        public Wall(BlockControl a, BlockControl b, bool present)
        {
            this.a = a;
            this.b = b;
            this.present = present;
        }

        public BlockControl getOpposite(BlockControl x)
        {
            return x == a ? b : a;
        }
    }
}