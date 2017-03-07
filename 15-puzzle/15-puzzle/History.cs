using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15_puzzle
{
    class History
    {
        public int Value;
        public Position ShiftTo;
        public Position ShiftFrom;
        public History(int value, Position pos1, Position pos2)
        {
            Value = value;
            ShiftFrom = pos1;
            ShiftTo = pos2;
        }

        public override string ToString()
        {
            return string.Format("{0} with ({1};{2}) replaced to ({3};{4})",
                    this.Value, this.ShiftFrom.X, this.ShiftFrom.Y, this.ShiftTo.X, this.ShiftTo.Y);
        }
    }
}
