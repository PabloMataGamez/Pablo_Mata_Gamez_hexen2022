    public struct HexPosition 
    {
        private readonly int _q;
        private readonly int _r;
        public int Q => _q;
        public int R => _r;

        public HexPosition(int q, int r)
        {
            _q = q;
            _r = r;

        }

        public override string ToString()
        {
            return $"Position(Q: {_q}, R: {_r})";
        }
    }