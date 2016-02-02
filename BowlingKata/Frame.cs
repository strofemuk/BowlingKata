using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingKata
{
    public class Frame
    {
        public Frame(string firstThrow, string secondThrow, bool isBonus = false)
            : this(firstThrow, isBonus)
        {
            if (secondThrow == "/") secondThrow = (10 - FirstThrow).ToString();
            if (secondThrow == "-") secondThrow = "0";

            int intSecondThrow;
            bool parsed = int.TryParse(secondThrow, out intSecondThrow);
            if (!parsed) throw new ArgumentException("X, -, or numbers only.", "secondThrow");

            if (FirstThrow + intSecondThrow > 10)
                throw new ArgumentException("Total of must less than or equal to 10");

            if (intSecondThrow > 10 || intSecondThrow < 0)
                throw new ArgumentException("Must be between 0 and 10.", "secondThrow");
            SecondThrow = intSecondThrow;
        }

        public Frame(string firstThrow, bool isBonus = false)
        {
            if (firstThrow == "X" || firstThrow == "x") firstThrow = "10";
            if (firstThrow == "-") firstThrow = "0";

            int intFirstThrow;
            bool parsed = int.TryParse(firstThrow, out intFirstThrow);
            if (!parsed) throw new ArgumentException("X, -, or numbers only.", "firstThrow");

            if (intFirstThrow > 10 || intFirstThrow < 0)
                throw new ArgumentException("Must be between 0 and 10.", "firstThrow");

            FirstThrow = intFirstThrow;
            IsBonus = isBonus;
        }

        public Frame(int firstThrow, int secondThrow, bool isBonus = false)
            : this(firstThrow, isBonus)
        {
            if (FirstThrow + secondThrow > 10)
                throw new ArgumentException("Total of must less than or equal to 10");

            if (secondThrow > 10 || secondThrow < 0)
                throw new ArgumentException("Must be between 0 and 10.", "secondThrow");
            SecondThrow = secondThrow;
        }

        public Frame(int firstThrow, bool isBonus = false)
        {
            if (firstThrow > 10 || firstThrow < 0)
                throw new ArgumentException("Must be between 0 and 10.", "firstThrow");

            FirstThrow = firstThrow;
            IsBonus = isBonus;
        }

        public int FirstThrow { get; private set; }

        public int SecondThrow { get; private set; }

        public int FrameSum { get { return FirstThrow + SecondThrow; } }

        public bool IsStrike { get { return FirstThrow == 10; } }

        public bool IsBonus { get; private set; }

        public bool IsSpare
        {
            get
            {
                if (FirstThrow < 10)
                    return FirstThrow + SecondThrow == 10;
                else
                    return false;
            }
        }

    }
}
