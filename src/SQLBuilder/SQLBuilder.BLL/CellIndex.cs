using System;

namespace SQLBuilder.BLL
{
    public class CellIndex
    {
        public Int32 X
        {
            get;
            private set;
        }
        public Int32 Y
        {
            get;
            private set;
        }

        public CellIndex(Int32 x, Int32 y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}
