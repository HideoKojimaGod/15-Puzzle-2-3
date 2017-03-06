using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15_puzzle
{
    class Puzzle2 : Puzzle
    {
        public Puzzle2(params int[] numberedSquare) : base(numberedSquare)
        {  
        }
        private void IllegalShift(int value1, int value2)
        {
            Position position1 = positions[value1];
            this[positions[value1].X, positions[value1].Y] = value2;
            this[positions[value2].X, positions[value2].Y] = value1;
            positions[value1] = positions[value2];
            positions[value2] = position1;
        }
        public virtual void Randomize()
        {
            var n = new Random().Next(SizeOfFrame * SizeOfFrame);
            var val = new Random();
            for (int i = 0; i < n; i++)
                IllegalShift(val.Next(SizeOfFrame * SizeOfFrame - 1),
                             val.Next(SizeOfFrame * SizeOfFrame - 1));
        }

        public static Puzzle2 CreateRandom(int sizeOfFrame)
        {
            int[] numberedSquare = new int[sizeOfFrame * sizeOfFrame];
            for (int i = 0; i < sizeOfFrame * sizeOfFrame; i++)
                numberedSquare[i] = i;
            var rPuzzle = new Puzzle2(numberedSquare);
            rPuzzle.Randomize();
            return rPuzzle;
        }
        public bool Win
        {
            get
            {
                for (int i = 0; i < SizeOfFrame; i++)
                {
                    for (int j = 0; j < SizeOfFrame; j++)
                    {
                        if (i == SizeOfFrame - 1 && j == SizeOfFrame - 1 && this[i, j] == 0)
                            continue;
                        else if (this[i, j] == i * SizeOfFrame + j + 1 && (i != SizeOfFrame - 1 || j != SizeOfFrame - 1))
                            continue;
                        else return false;
                    }
                }
                return true;
            }
        }
    }
}
