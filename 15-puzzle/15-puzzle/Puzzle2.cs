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
        protected List<int> CheckVarinatsOfReplace()
        {
            var variants = new List<int>();
            if (GetLocation(0).X != SizeOfFrame - 1)
                variants.Add(this[GetLocation(0).X + 1, GetLocation(0).Y]);
            if (GetLocation(0).X != 0)
                variants.Add(this[GetLocation(0).X - 1, GetLocation(0).Y]);
            if (GetLocation(0).Y != SizeOfFrame - 1)
                variants.Add(this[GetLocation(0).X, GetLocation(0).Y + 1]);
            if (GetLocation(0).Y != 0)
                variants.Add(this[GetLocation(0).X, GetLocation(0).Y - 1]);
            return variants;
        }

        public virtual void Randomize()
        {
            var n = SizeOfFrame * SizeOfFrame;
            var rand = new Random();
            for (int i = 0; i < n; i++)
            {
                var variants = CheckVarinatsOfReplace();
                Shift(variants[rand.Next(variants.Count - 1)]);
            }
               
        }

        public static Puzzle2 CreateRandom(int sizeOfFrame)
        {
            int[] numberedSquare = new int[sizeOfFrame * sizeOfFrame];
            for (int i = 0; i < sizeOfFrame * sizeOfFrame; i++)
                numberedSquare[i] = i;
            var randomPuzzle = new Puzzle2(numberedSquare);
            randomPuzzle.Randomize();
            return randomPuzzle;
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
