using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15_puzzle
{
    class Puzzle3 : Puzzle2
    {
        private List<History> history;
        private int currentStep;
        public Puzzle3(params int[] numberedSquare) : base(numberedSquare)
        {
            history = new List<History>();
            currentStep = 0;
        }
        public override void Shift(int value)
        {
            base.Shift(value);
            if (currentStep < history.Count)
            {
                for (int i = history.Count - 1; i > currentStep - 1; i--)
                    history.RemoveAt(i);
            }
            history.Add(new History(value, GetLocation(0), GetLocation(value)));
            currentStep++;
        }
        public void Redo(int amountOfSteps)
        {
            for (int i = 0; i < amountOfSteps; i++)
            {
                if (currentStep < history.Count)
                {
                    base.Shift(history[currentStep].Value);
                    currentStep++;
                }
                else throw new ArgumentOutOfRangeException("Невозможно вернуться вперед");
            }
        }
        public void Undo(int amountOfSteps)
        {
            for (int i = 0; i < amountOfSteps; i++)
            {
                if (currentStep != 0)
                {
                    base.Shift(history[currentStep - 1].Value);
                    currentStep--;
                }
                else throw new ArgumentOutOfRangeException("Невозможно вернуться назад");
            }
        }
        public void GetAllHistory()
        {
            for (int i = 0; i < history.Count; i++)
            {
                History step = history[i];
                Console.WriteLine("{0} with ({1};{2}) replaced to ({3};{4})",
                step.Value, step.ShiftFrom.X, step.ShiftFrom.Y, step.ShiftTo.X, step.ShiftTo.Y);
            }
        }
        public string GetStep(int value)
        {
            if (value <= currentStep)
            {
                History step = history[value - 1];
                return string.Format("{0} with ({1};{2}) replaced to ({3};{4})",
                    step.Value, step.ShiftFrom.X, step.ShiftFrom.Y, step.ShiftTo.X, step.ShiftTo.Y);
            }
            else return "Не существует шага";
        }

        public override void Randomize()
        {
            base.Randomize();
            currentStep = 0;
            history.Clear();
        }
        //откаты изменения
    }
}
