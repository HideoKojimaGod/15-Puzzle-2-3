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
                if (currentStep > 0)
                {
                    base.Shift(history[currentStep - 1].Value);
                    currentStep--;
                }
                else throw new ArgumentOutOfRangeException("Невозможно вернуться назад");
            }
        }
        public List<string> GetAllHistory()
        {
            List<string> steps = new List<string>();
            for (int i = 0; i < currentStep; i++)
            {
                steps.Add(history[i].ToString());
            }
            return steps;
        }
        public string GetStep(int value)
        {
            if (value <= currentStep)
            {
                return history[value - 1].ToString();
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
